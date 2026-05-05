using GSB2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GSB2.DAO
{
    public class PrescriptionDAO
    {
        private readonly Database db = new Database();

        // SB: Récupère une prescription complète par son identifiant
        public Prescription? GetPrescriptionById(int id_prescription)
        {
            using var connection = db.GetConnection();
            try
            {
                connection.Open();

                var cmd = new MySqlCommand(
                    @"SELECT id_prescription, id_users, id_patients, validity
                      FROM prescription
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

        // SB: Crée une prescription simple sans médicaments associés
        public bool CreatePrescription(Prescription prescription)
        {
            using var connection = db.GetConnection();
            try
            {
                connection.Open();

                var cmd = new MySqlCommand(
                    @"INSERT INTO prescription (id_users, id_patients, validity)
                      VALUES (@id_users, @id_patients, @validity);", connection);
                cmd.Parameters.AddWithValue("@id_users",    prescription.Id_users);
                cmd.Parameters.AddWithValue("@id_patients", prescription.Id_patients);
                cmd.Parameters.AddWithValue("@validity",    prescription.Validity);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur dans CreatePrescription : " + ex.Message);
                return false;
            }
        }

        // SB: Crée une prescription et insère en une seule transaction tous les médicaments avec leurs quantités
        public bool CreatePrescriptionWithMedicines(Prescription prescription, List<(int Id_medicine, int Quantity)> medicines)
        {
            using var connection = db.GetConnection();
            MySqlTransaction? transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                var cmd = new MySqlCommand(
                    @"INSERT INTO prescription (id_users, id_patients, validity)
                      VALUES (@id_users, @id_patients, @validity);", connection, transaction);
                cmd.Parameters.AddWithValue("@id_users",    prescription.Id_users);
                cmd.Parameters.AddWithValue("@id_patients", prescription.Id_patients);
                cmd.Parameters.AddWithValue("@validity",    prescription.Validity);
                cmd.ExecuteNonQuery();
                long newPrescriptionId = cmd.LastInsertedId;

                foreach (var med in medicines)
                {
                    var medCmd = new MySqlCommand(
                        @"INSERT INTO liai_medicine_prescription (id_prescription, id_medicine, quantity)
                          VALUES (@id_prescription, @id_medicine, @quantity);", connection, transaction);
                    medCmd.Parameters.AddWithValue("@id_prescription", newPrescriptionId);
                    medCmd.Parameters.AddWithValue("@id_medicine",     med.Id_medicine);
                    medCmd.Parameters.AddWithValue("@quantity",        med.Quantity);
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

        // SB: Récupère toutes les prescriptions avec les informations patient, médecin et médicaments pour l'affichage
        public List<PrescriptionView> GetAllPrescriptions()
        {
            var prescriptions = new List<PrescriptionView>();
            using var connection = db.GetConnection();
            try
            {
                connection.Open();

                string query = @"
                    SELECT
                        p.id_prescription,
                        p.validity,
                        u.firstname  AS doctor_firstname,
                        u.name       AS doctor_name,
                        pa.firstname AS patient_firstname,
                        pa.name      AS patient_name,
                        pa.age       AS patient_age,
                        GROUP_CONCAT(CONCAT(m.names, ' (', a.quantity, ')') SEPARATOR ', ') AS medicines
                    FROM prescription p
                    LEFT JOIN users    u  ON p.id_users    = u.id_users
                    LEFT JOIN patients pa ON p.id_patients = pa.id_patients
                    LEFT JOIN liai_medicine_prescription a ON p.id_prescription = a.id_prescription
                    LEFT JOIN medicine m ON a.id_medicine = m.id_medicine
                    GROUP BY p.id_prescription, p.validity, u.firstname, u.name, pa.firstname, pa.name, pa.age
                    ORDER BY p.id_prescription ASC;";

                using var cmd    = new MySqlCommand(query, connection);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    prescriptions.Add(new PrescriptionView
                    {
                        Id          = reader.GetInt32("id_prescription"),
                        Validite    = reader.GetDateTime("validity").ToString("yyyy-MM-dd"),
                        Docteur     = $"{reader["doctor_firstname"]} {reader["doctor_name"]}",
                        Patient     = $"{reader["patient_firstname"]} {reader["patient_name"]} ({reader["patient_age"]} ans)",
                        Medicaments = reader["medicines"] != DBNull.Value ? reader["medicines"].ToString() : "Aucun"
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur GetAllPrescriptions : " + ex.Message);
                throw;
            }

            return prescriptions;
        }

        // SB: Récupère la liste des médicaments et leurs quantités pour une prescription donnée
        public List<(int Id_medicine, int Quantity)> GetMedicinesWithQuantities(int id_prescription)
        {
            var list = new List<(int, int)>();
            using var connection = db.GetConnection();
            try
            {
                connection.Open();

                string query = @"SELECT id_medicine, quantity
                                 FROM liai_medicine_prescription
                                 WHERE id_prescription = @id;";
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

        // SB: Met à jour la date de validité d'une prescription et remplace tous ses médicaments en une seule transaction
        public bool UpdatePrescription(int id_prescription, string newValidity, List<(int Id_medicine, int Quantity)> medicines)
        {
            using var connection = db.GetConnection();
            MySqlTransaction? transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                // SB: Mise à jour de la date
                var cmd = new MySqlCommand(
                    @"UPDATE prescription SET validity = @validity WHERE id_prescription = @id;",
                    connection, transaction);
                cmd.Parameters.AddWithValue("@validity", newValidity);
                cmd.Parameters.AddWithValue("@id",       id_prescription);
                cmd.ExecuteNonQuery();

                // SB: Suppression des anciens médicaments
                var delCmd = new MySqlCommand(
                    @"DELETE FROM liai_medicine_prescription WHERE id_prescription = @id;",
                    connection, transaction);
                delCmd.Parameters.AddWithValue("@id", id_prescription);
                delCmd.ExecuteNonQuery();

                // SB: Insertion des nouveaux médicaments avec quantités
                foreach (var med in medicines)
                {
                    var medCmd = new MySqlCommand(
                        @"INSERT INTO liai_medicine_prescription (id_prescription, id_medicine, quantity)
                          VALUES (@id_prescription, @id_medicine, @quantity);", connection, transaction);
                    medCmd.Parameters.AddWithValue("@id_prescription", id_prescription);
                    medCmd.Parameters.AddWithValue("@id_medicine",     med.Id_medicine);
                    medCmd.Parameters.AddWithValue("@quantity",        med.Quantity);
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

        // SB: Supprime une prescription et toutes ses liaisons médicaments en une seule transaction
        public bool DeletePrescription(int id_prescription)
        {
            using var connection = db.GetConnection();
            MySqlTransaction? transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                // SB: Suppression des liaisons médicaments
                var delAppCmd = new MySqlCommand(
                    @"DELETE FROM liai_medicine_prescription WHERE id_prescription = @id;",
                    connection, transaction);
                delAppCmd.Parameters.AddWithValue("@id", id_prescription);
                delAppCmd.ExecuteNonQuery();

                // SB: Suppression de la prescription
                var delPrescCmd = new MySqlCommand(
                    @"DELETE FROM prescription WHERE id_prescription = @id;",
                    connection, transaction);
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
