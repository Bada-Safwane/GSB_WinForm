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

        // 🔹 Récupérer toutes les medicines avec leur utilisateur associé
        public List<dynamic> GetAll()
        {
            var medicines = new List<dynamic>();

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
                    m.names AS medicine_name,
                    m.description,
                    m.molecule,
                    u.firstname AS user_firstname,
                    u.name AS user_name
                    FROM Medicine m
                    INNER JOIN users u ON m.id_users = u.id_users;
            ";

                    using var cmd = new MySqlCommand(query, connection);
                    using var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        medicines.Add(new
                        {
                            Id_medicine = reader.GetInt32("id_medicine"),
                            Id_user = reader.GetInt32("id_user"),
                            Dosage = reader["dosage"].ToString(),
                            Name = reader["medicine_name"].ToString(),
                            Description = reader["description"].ToString(),
                            Molecule = reader["molecule"].ToString(),
                            User = $"{reader["user_firstname"]} {reader["user_name"]}" // Résolution de l'utilisateur
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la récupération des médicaments : {ex.Message}");
                }
            }

            return medicines;
        }

        public List<Medicine> GetAllMedicines()
        {
            List<Medicine> medicines = new List<Medicine>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id_medicine, names FROM Medicine ORDER BY names;";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        medicines.Add(new Medicine
                        {
                            Id_Medicine = reader.GetInt32("id_medicine"),
                            Names = reader.GetString("names")
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


        // 🔹 Récupérer un médicament par ID
        public Medicine? GetById(int id)
        {
            Medicine? med = null;

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand myCommand = new MySqlCommand(@"
                SELECT 
                    m.id_medicine,
                    m.id_users,
                    m.dosage,
                    m.names AS medicine_name,
                    m.description,
                    m.molecule,
                    u.names AS user_name,
                    u.firstname AS user_firstname
                FROM Medicine m
                INNER JOIN Users u ON m.id_users = u.id_users
                WHERE m.id_medicine = @id;
            ", connection);

                    myCommand.Parameters.AddWithValue("@id", id);

                    using var myReader = myCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // Lecture sécurisée (évite tous les NULL)
                        string dosage = myReader["dosage"]?.ToString() ?? "";
                        string name = myReader["medicine_name"]?.ToString() ?? "";
                        string description = myReader["description"]?.ToString() ?? "";
                        string molecule = myReader["molecule"]?.ToString() ?? "";

                        med = new Medicine(
                            myReader.GetInt32("id_medicine"),
                            myReader.GetInt32("id_users"),
                            dosage,
                            name,
                            description,
                            molecule
                        );

                        // Ajout des infos du créateur (safe également)
                        string userFirst = myReader["user_firstname"]?.ToString() ?? "";
                        string userName = myReader["user_name"]?.ToString() ?? "";

                        med.Description = (med.Description ?? "") +
                                          $" (Ajouté par {userFirst} {userName})";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la récupération du médicament : {ex.Message}");
                }
            }

            return med;
        }


        // 🔹 Ajouter un médicament
        public bool Insert(Medicine med)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand myCommand = new MySqlCommand(@"
                        INSERT INTO Medicine (id_users, dosage, names, description, molecule)
                        VALUES (@id_users, @dosage, @names, @description, @molecule);
                    ", connection);

                    myCommand.Parameters.AddWithValue("@id_users", med.Id_Users);
                    myCommand.Parameters.AddWithValue("@dosage", med.Dosage);
                    myCommand.Parameters.AddWithValue("@names", med.Names);
                    myCommand.Parameters.AddWithValue("@description", med.Description);
                    myCommand.Parameters.AddWithValue("@molecule", med.Molecule);

                    int rows = myCommand.ExecuteNonQuery();
                    connection.Close();

                    return rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de l'insertion du médicament : {ex.Message}");
                    return false;
                }
            }
        }

        // 🔹 Mettre à jour un médicament
        public bool Update(Medicine med)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand myCommand = new MySqlCommand(@"
                        UPDATE Medicine
                        SET id_users = @id_users,
                            dosage = @dosage,
                            names = @names,
                            description = @description,
                            molecule = @molecule
                        WHERE id_medicine = @id_medicine;
                    ", connection);

                    myCommand.Parameters.AddWithValue("@id_medicine", med.Id_Medicine);
                    myCommand.Parameters.AddWithValue("@id_users", med.Id_Users);
                    myCommand.Parameters.AddWithValue("@dosage", med.Dosage);
                    myCommand.Parameters.AddWithValue("@name", med.Names);
                    myCommand.Parameters.AddWithValue("@description", med.Description);
                    myCommand.Parameters.AddWithValue("@molecule", med.Molecule);

                    int rows = myCommand.ExecuteNonQuery();
                    connection.Close();

                    return rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la mise à jour du médicament : {ex.Message}");
                    return false;
                }
            }
        }

        // 🔹 Supprimer un médicament
        public bool Delete(int id)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand myCommand = new MySqlCommand(
                        "DELETE FROM Medicine WHERE id_medicine = @id;", connection);
                    myCommand.Parameters.AddWithValue("@id", id);

                    int rows = myCommand.ExecuteNonQuery();
                    connection.Close();

                    return rows > 0;
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