using GSB2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB2.DAO
{
    public class PrescriptionDAO
    {
        private readonly Database db = new Database();

        // 🔹 Récupérer une prescription par son ID
        public Prescription? GetPrescriptionById(int id_prescription)
        {
            using var connection = db.GetConnection();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(
                    @"SELECT id_prescription, id_users, id_patients, validity
                      FROM Prescription 
                      WHERE id_prescription = @id_prescription;", connection);
                cmd.Parameters.AddWithValue("@id_prescription", id_prescription);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Prescription(
                        reader.GetInt32("id_prescription"),
                        reader.GetInt32("id_users"),
                        reader.GetInt32("id_patients"),
                        reader.GetDateTime("validity").ToString("yyyy-MM-dd")
                    );
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur dans GetPrescriptionById : " + ex.Message);
                return null;
            }
        }

        // 🔹 Créer une prescription simple
        public bool CreatePrescription(Prescription prescription)
        {
            using var connection = db.GetConnection();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(
                    @"INSERT INTO Prescription (id_users, id_patient, validity)
                      VALUES (@id_users, @id_patient, @validity);", connection);
                cmd.Parameters.AddWithValue("@id_users", prescription.Id_users);
                cmd.Parameters.AddWithValue("@id_patient", prescription.Id_patients);
                cmd.Parameters.AddWithValue("@validity", prescription.Validity);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur dans CreatePrescription : " + ex.Message);
                return false;
            }
        }

        // 🔹 Créer prescription + médicaments/quantités
        public bool CreatePrescriptionWithMedicines(Prescription prescription, List<(int Id_medicine, int Quantity)> medicines)
        {
            using var connection = db.GetConnection();
            MySqlTransaction? transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand(
                    @"INSERT INTO Prescription (id_users, id_patient, validity)
                      VALUES (@id_users, @id_patient, @validity);", connection, transaction);
                cmd.Parameters.AddWithValue("@id_users", prescription.Id_users);
                cmd.Parameters.AddWithValue("@id_patient", prescription.Id_patients);
                cmd.Parameters.AddWithValue("@validity", prescription.Validity);
                cmd.ExecuteNonQuery();
                long newPrescriptionId = cmd.LastInsertedId;

                foreach (var med in medicines)
                {
                    MySqlCommand medCmd = new MySqlCommand(
                        @"INSERT INTO liai_medicine_prescription (id_prescription, id_medicine, quantity)
                          VALUES (@id_prescription, @id_medicine, @quantity);", connection, transaction);
                    medCmd.Parameters.AddWithValue("@id_prescription", newPrescriptionId);
                    medCmd.Parameters.AddWithValue("@id_medicine", med.Id_medicine);
                    medCmd.Parameters.AddWithValue("@quantity", med.Quantity);
                    medCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur CreatePrescriptionWithMedicines : " + ex.Message);
                try { transaction?.Rollback(); } catch { }
                return false;
            }
        }

        // 🔹 Récupérer toutes les prescriptions
        public List<dynamic> GetAllPrescriptions()
        {
            var prescriptions = new List<dynamic>();
            using var connection = db.GetConnection();
            try
            {
                connection.Open();
                string query = @"
                    SELECT 
                        p.id_prescription, p.validity,
                        u.firstname AS doctor_firstname, u.name AS doctor_name,
                        pa.firstname AS patient_firstname, pa.name AS patient_name, pa.age AS patient_age,
                        GROUP_CONCAT(CONCAT(m.names, ' (', a.quantity, ')') SEPARATOR ', ') AS medicines
                    FROM Prescription p
                    INNER JOIN Users u ON p.id_users = u.id_users
                    INNER JOIN Patients pa ON p.id_patients = pa.id_patients
                    LEFT JOIN liai_medicine_prescription a ON p.id_prescription = a.id_prescrition
                    LEFT JOIN Medicine m ON a.id_medicine = m.id_medicine
                    GROUP BY p.id_prescription, p.validity, u.firstname, u.name, pa.firstname, pa.name, pa.age
                    ORDER BY p.id_prescription ASC;";

                using var cmd = new MySqlCommand(query, connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prescriptions.Add(new
                    {
                        Id = reader.GetInt32("id_prescription"),
                        Validité = reader.GetDateTime("validity").ToString("yyyy-MM-dd"),
                        Docteur = $"{reader["doctor_firstname"]} {reader["doctor_name"]}",
                        Patient = $"{reader["patient_firstname"]} {reader["patient_name"]} ({reader["patient_age"]} ans)",
                        Médicaments = reader["medicines"] != DBNull.Value ? reader["medicines"].ToString() : "Aucun"
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur GetAllPrescriptions : " + ex.Message);
            }
            return prescriptions;
        }

        // 🔹 Récupérer médicaments + quantités d'une prescription
        public List<(int Id_medicine, int Quantity)> GetMedicinesWithQuantities(int id_prescription)
        {
            var list = new List<(int, int)>();
            using var connection = db.GetConnection();
            try
            {
                connection.Open();
                string query = @"SELECT id_medicine, quantity FROM liai_medicine_prescription WHERE id_prescription = @id";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id_prescription);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add((reader.GetInt32("id_medicine"), reader.GetInt32("quantity")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur GetMedicinesWithQuantities : " + ex.Message);
            }
            return list;
        }

        // 🔹 Modifier prescription (date + médicaments/quantités)
        public bool UpdatePrescription(int id_prescription, string newValidity, List<(int Id_medicine, int Quantity)> medicines)
        {
            using var connection = db.GetConnection();
            MySqlTransaction? transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                // 1️⃣ Update date
                MySqlCommand cmd = new MySqlCommand(
                    @"UPDATE Prescription SET validity = @validity WHERE id_prescription = @id;", connection, transaction);
                cmd.Parameters.AddWithValue("@validity", newValidity);
                cmd.Parameters.AddWithValue("@id", id_prescription);
                cmd.ExecuteNonQuery();

                // 2️⃣ Supprimer anciennes lignes Appartient
                MySqlCommand delCmd = new MySqlCommand(
                    @"DELETE FROM liai_medicine_prescription WHERE id_prescription = @id;", connection, transaction);
                delCmd.Parameters.AddWithValue("@id", id_prescription);
                delCmd.ExecuteNonQuery();

                // 3️⃣ Ré-inserer nouvelles quantités
                foreach (var med in medicines)
                {
                    MySqlCommand medCmd = new MySqlCommand(
                        @"INSERT INTO liai_medicine_prescription (id_prescription, id_medicine, quantity)
                          VALUES (@id_prescription, @id_medicine, @quantity);", connection, transaction);
                    medCmd.Parameters.AddWithValue("@id_prescription", id_prescription);
                    medCmd.Parameters.AddWithValue("@id_medicine", med.Id_medicine);
                    medCmd.Parameters.AddWithValue("@quantity", med.Quantity);
                    medCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur UpdatePrescription : " + ex.Message);
                try { transaction?.Rollback(); } catch { }
                return false;
            }
        }

        // 🔹 Supprimer une prescription
        public bool DeletePrescription(int id_prescription)
        {
            using var connection = db.GetConnection();
            MySqlTransaction? transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                // 1️⃣ Supprimer lignes Appartient
                MySqlCommand delAppCmd = new MySqlCommand(
                    @"DELETE FROM liai_medicine_prescription WHERE id_prescription = @id;", connection, transaction);
                delAppCmd.Parameters.AddWithValue("@id", id_prescription);
                delAppCmd.ExecuteNonQuery();

                // 2️⃣ Supprimer prescription
                MySqlCommand delPrescCmd = new MySqlCommand(
                    @"DELETE FROM Prescription WHERE id_prescription = @id;", connection, transaction);
                delPrescCmd.Parameters.AddWithValue("@id", id_prescription);
                delPrescCmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur DeletePrescription : " + ex.Message);
                try { transaction?.Rollback(); } catch { }
                return false;
            }
        }
    }
}
