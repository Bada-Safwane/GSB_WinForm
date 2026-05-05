using MySql.Data.MySqlClient;
using GSB2.Models;
using System;
using System.Collections.Generic;

namespace GSB2.DAO
{
    public class LiaiMPDAO
    {
        private readonly Database db = new Database();

        // SB: Récupère toutes les associations médicament-prescription de la base de données
        public List<LiaiMP> GetAll()
        {
            var list = new List<LiaiMP>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    using var cmd = new MySqlCommand(
                        @"SELECT id_prescription, id_medicine, quantity
                          FROM liai_medicine_prescription;", connection);

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new LiaiMP(
                            reader.GetInt32("id_medicine"),
                            reader.GetInt32("id_prescription"),
                            reader.IsDBNull(reader.GetOrdinal("quantity")) ? 0 : reader.GetInt32("quantity")
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur GetAll LiaiMP : {ex.Message}");
                }
            }

            return list;
        }

        // SB: Récupère tous les médicaments associés à une prescription donnée
        public List<LiaiMP> GetByPrescriptionId(int id_prescription)
        {
            var list = new List<LiaiMP>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    using var cmd = new MySqlCommand(
                        @"SELECT id_prescription, id_medicine, quantity
                          FROM liai_medicine_prescription
                          WHERE id_prescription = @id_prescription;", connection);
                    cmd.Parameters.AddWithValue("@id_prescription", id_prescription);

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new LiaiMP(
                            reader.GetInt32("id_medicine"),
                            reader.GetInt32("id_prescription"),
                            reader.IsDBNull(reader.GetOrdinal("quantity")) ? 0 : reader.GetInt32("quantity")
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur GetByPrescriptionId : {ex.Message}");
                }
            }

            return list;
        }

        // SB: Récupère toutes les prescriptions associées à un médicament donné
        public List<LiaiMP> GetByMedicineId(int id_medicine)
        {
            var list = new List<LiaiMP>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    using var cmd = new MySqlCommand(
                        @"SELECT id_prescription, id_medicine, quantity
                          FROM liai_medicine_prescription
                          WHERE id_medicine = @id_medicine;", connection);
                    cmd.Parameters.AddWithValue("@id_medicine", id_medicine);

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new LiaiMP(
                            reader.GetInt32("id_medicine"),
                            reader.GetInt32("id_prescription"),
                            reader.IsDBNull(reader.GetOrdinal("quantity")) ? 0 : reader.GetInt32("quantity")
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur GetByMedicineId : {ex.Message}");
                }
            }

            return list;
        }

        // SB: Insère une nouvelle association médicament-prescription en base de données
        public bool Insert(LiaiMP a)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    using var cmd = new MySqlCommand(
                        @"INSERT INTO liai_medicine_prescription (id_prescription, id_medicine, quantity)
                          VALUES (@id_prescription, @id_medicine, @quantity);", connection);
                    cmd.Parameters.AddWithValue("@id_prescription", a.Id_prescription);
                    cmd.Parameters.AddWithValue("@id_medicine",     a.Id_medicine);
                    cmd.Parameters.AddWithValue("@quantity",        a.Quantity);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur Insert LiaiMP : {ex.Message}");
                    return false;
                }
            }
        }

        // SB: Supprime une association médicament-prescription par couple d'identifiants
        public bool Delete(int id_prescription, int id_medicine)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    using var cmd = new MySqlCommand(
                        @"DELETE FROM liai_medicine_prescription
                          WHERE id_prescription = @id_prescription
                            AND id_medicine     = @id_medicine;", connection);
                    cmd.Parameters.AddWithValue("@id_prescription", id_prescription);
                    cmd.Parameters.AddWithValue("@id_medicine",     id_medicine);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur Delete LiaiMP : {ex.Message}");
                    return false;
                }
            }
        }

        // SB: Supprime toutes les associations médicaments liées à une prescription
        public bool DeleteByPrescriptionId(int id_prescription)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    using var cmd = new MySqlCommand(
                        @"DELETE FROM liai_medicine_prescription
                          WHERE id_prescription = @id_prescription;", connection);
                    cmd.Parameters.AddWithValue("@id_prescription", id_prescription);

                    return cmd.ExecuteNonQuery() > 0;
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

