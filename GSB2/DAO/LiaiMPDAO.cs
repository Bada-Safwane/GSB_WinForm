using MySql.Data.MySqlClient;
using GSB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB2.DAO
{
    public class LiaiMPDAO
    {
        private readonly Database db = new Database();

        // 🔹 Récupérer toutes les associations
        public List<LiaiMP> GetAll()
        {
            List<LiaiMP> list = new List<LiaiMP>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        @"SELECT id_prescription, id_medicine, quantity FROM LiaiMP;", connection);

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LiaiMP a = new LiaiMP(
                            reader.GetInt32("id_medicine"),
                            reader.GetInt32("id_prescription"),
                            reader.IsDBNull(reader.GetOrdinal("quantity")) ? 0 : reader.GetInt32("quantity")
                        );
                        list.Add(a);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur GetAll LiaiMP : {ex.Message}");
                }
            }

            return list;
        }

        // 🔹 Récupérer les médicaments d’une prescription
        public List<LiaiMP> GetByPrescriptionId(int id_prescription)
        {
            List<LiaiMP> list = new List<LiaiMP>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        @"SELECT id_prescription, id_medicine, quantity 
                          FROM LiaiMP 
                          WHERE id_prescription = @id_prescription;", connection);

                    cmd.Parameters.AddWithValue("@id_prescription", id_prescription);

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LiaiMP a = new LiaiMP(
                            reader.GetInt32("id_medicine"),
                            reader.GetInt32("id_prescription"),
                            reader.IsDBNull(reader.GetOrdinal("quantity")) ? 0 : reader.GetInt32("quantity")
                        );
                        list.Add(a);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur GetByPrescriptionId : {ex.Message}");
                }
            }

            return list;
        }

        // 🔹 Récupérer les prescriptions liées à un médicament
        public List<LiaiMP> GetByMedicineId(int id_medicine)
        {
            List<LiaiMP> list = new List<LiaiMP>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        @"SELECT id_prescription, id_medicine, quantity 
                          FROM LiaiMP 
                          WHERE id_medicine = @id_medicine;", connection);

                    cmd.Parameters.AddWithValue("@id_medicine", id_medicine);

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LiaiMP a = new LiaiMP(
                            reader.GetInt32("id_medicine"),
                            reader.GetInt32("id_prescription"),
                            reader.IsDBNull(reader.GetOrdinal("quantity")) ? 0 : reader.GetInt32("quantity")
                        );
                        list.Add(a);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur GetByMedicineId : {ex.Message}");
                }
            }

            return list;
        }

        // 🔹 Ajouter une association
        public bool Insert(LiaiMP a)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(@"
                        INSERT INTO LiaiMP (id_prescription, id_medicine, quantity)
                        VALUES (@id_prescription, @id_medicine, @quantity);
                    ", connection);

                    cmd.Parameters.AddWithValue("@id_prescription", a.Id_prescription);
                    cmd.Parameters.AddWithValue("@id_medicine", a.Id_medicine);
                    cmd.Parameters.AddWithValue("@quantity", a.Quantity);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur Insert LiaiMP : {ex.Message}");
                    return false;
                }
            }
        }

        // 🔹 Supprimer une association
        public bool Delete(int id_prescription, int id_medicine)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(@"
                        DELETE FROM LiaiMP
                        WHERE id_prescription = @id_prescription AND id_medicine = @id_medicine;
                    ", connection);

                    cmd.Parameters.AddWithValue("@id_prescription", id_prescription);
                    cmd.Parameters.AddWithValue("@id_medicine", id_medicine);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur Delete LiaiMP : {ex.Message}");
                    return false;
                }
            }
        }

        // 🔹 Supprimer toutes les associations d’une prescription
        public bool DeleteByPrescriptionId(int id_prescription)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(@"
                        DELETE FROM LiaiMP WHERE id_prescription = @id_prescription;
                    ", connection);

                    cmd.Parameters.AddWithValue("@id_prescription", id_prescription);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur DeleteByPrescriptionId LiaiMP : {ex.Message}");
                    return false;
                }
            }
        }
    }
}
