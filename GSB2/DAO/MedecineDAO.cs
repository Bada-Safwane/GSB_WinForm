using GSB2;
using GSB2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GSB2.DAO
{
    public class MedicineDAO
    {
        private readonly Database db = new Database();

        // SB: Récupère tous les médicaments avec les informations de l'utilisateur qui les a créés
        public List<MedicineView> GetAll()
        {
            var medicines = new List<MedicineView>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            m.id_medicine,
                            m.id_users,
                            m.dosage,
                            m.names       AS medicine_name,
                            m.description,
                            m.molecule,
                            u.firstname   AS user_firstname,
                            u.name        AS user_name
                        FROM medicine m
                        LEFT JOIN users u ON m.id_users = u.id_users;";

                    using var cmd    = new MySqlCommand(query, connection);
                    using var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        medicines.Add(new MedicineView
                        {
                            Id_medicine = reader.GetInt32("id_medicine"),
                            Id_users    = reader.IsDBNull(reader.GetOrdinal("id_users")) ? 0 : reader.GetInt32("id_users"),
                            Dosage      = reader["dosage"]?.ToString()       ?? "",
                            Name        = reader["medicine_name"]?.ToString() ?? "",
                            Description = reader["description"]?.ToString()   ?? "",
                            Molecule    = reader["molecule"]?.ToString()       ?? "",
                            User        = $"{reader["user_firstname"]} {reader["user_name"]}".Trim()
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la récupération des médicaments : {ex.Message}");
                    throw;
                }
            }

            return medicines;
        }

        // SB: Récupère uniquement l'ID et le nom de tous les médicaments, utilisé pour les listes déroulantes
        public List<Medicine> GetAllMedicines()
        {
            var medicines = new List<Medicine>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id_medicine, names, dosage FROM medicine ORDER BY names;";

                    using var cmd    = new MySqlCommand(query, connection);
                    using var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        medicines.Add(new Medicine
                        {
                            Id_Medicine = reader.GetInt32("id_medicine"),
                            Names       = reader.GetString("names"),
                            Dosage      = reader.GetString("dosage")
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur dans GetAllMedicines : " + ex.Message);
                }
            }

            return medicines;
        }

        // SB: Récupère un médicament complet par son identifiant, avec les informations du créateur
        public Medicine? GetById(int id)
        {
            Medicine? med = null;

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            m.id_medicine,
                            m.id_users,
                            m.dosage,
                            m.names       AS medicine_name,
                            m.description,
                            m.molecule,
                            u.name        AS user_name,
                            u.firstname   AS user_firstname
                        FROM medicine m
                        LEFT JOIN users u ON m.id_users = u.id_users
                        WHERE m.id_medicine = @id;";

                    using var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        med = new Medicine(
                            reader.GetInt32("id_medicine"),
                            reader.IsDBNull(reader.GetOrdinal("id_users")) ? 0 : reader.GetInt32("id_users"),
                            reader["dosage"]?.ToString()        ?? "",
                            reader["medicine_name"]?.ToString() ?? "",
                            reader["description"]?.ToString()   ?? "",
                            reader["molecule"]?.ToString()      ?? ""
                        );

                        string userFirst = reader["user_firstname"]?.ToString() ?? "";
                        string userName  = reader["user_name"]?.ToString()      ?? "";
                        med.Description += $" (Ajouté par {userFirst} {userName})";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la récupération du médicament : {ex.Message}");
                }
            }

            return med;
        }

        // SB: Insère un nouveau médicament en base de données
        public bool Insert(Medicine med)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO medicine (id_users, dosage, names, description, molecule)
                        VALUES (@id_users, @dosage, @names, @description, @molecule);";

                    using var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id_users",     med.Id_Users);
                    cmd.Parameters.AddWithValue("@dosage",       med.Dosage);
                    cmd.Parameters.AddWithValue("@names",        med.Names);
                    cmd.Parameters.AddWithValue("@description",  med.Description);
                    cmd.Parameters.AddWithValue("@molecule",     med.Molecule);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de l'insertion du médicament : {ex.Message}");
                    return false;
                }
            }
        }

        // SB: Met à jour les informations d'un médicament existant
        public bool Update(Medicine med)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"
                        UPDATE medicine
                        SET id_users    = @id_users,
                            dosage      = @dosage,
                            names       = @names,
                            description = @description,
                            molecule    = @molecule
                        WHERE id_medicine = @id_medicine;";

                    using var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id_medicine",  med.Id_Medicine);
                    cmd.Parameters.AddWithValue("@id_users",     med.Id_Users);
                    cmd.Parameters.AddWithValue("@dosage",       med.Dosage);
                    cmd.Parameters.AddWithValue("@names",        med.Names);
                    cmd.Parameters.AddWithValue("@description",  med.Description);
                    cmd.Parameters.AddWithValue("@molecule",     med.Molecule);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la mise à jour du médicament : {ex.Message}");
                    return false;
                }
            }
        }

        // SB: Supprime un médicament de la base de données par son identifiant
        public bool Delete(int id)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    using var cmd = new MySqlCommand(
                        "DELETE FROM medicine WHERE id_medicine = @id;", connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la suppression du médicament : {ex.Message}");
                    return false;
                }
            }
        }
    }
}
