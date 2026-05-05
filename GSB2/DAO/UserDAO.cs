using GSB2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GSB2.DAO
{
    public class UserDAO
    {
        private readonly Database db = new Database();

        // SB: Vérifie les identifiants et retourne l'utilisateur correspondant, ou null si non trouvé
        public Users GetUsers(string email, string password)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    var cmd = new MySqlCommand(
                        @"SELECT id_users, firstname, name, email, role
                          FROM users
                          WHERE email = @email AND password = SHA2(@password, 256);",
                        connection);
                    cmd.Parameters.AddWithValue("@email",    email);
                    cmd.Parameters.AddWithValue("@password", password);

                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Users(
                            reader.GetInt32("id_users"),
                            reader.GetString("firstname"),
                            reader.GetString("name"),
                            reader.GetString("email"),
                            reader.GetBoolean("role")
                        );
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur de connexion : {ex.Message}");
                    return null;
                }
            }
        }

        // SB: Crée un nouveau compte utilisateur avec le rôle Médecin (role=false) après vérification de l'email
        public bool Register(string email, string password, string name, string firstname)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @Email;";
                    using (var checkCmd = new MySqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Cet email est déjà utilisé.");
                            return false;
                        }
                    }

                    string query = @"INSERT INTO users (email, password, name, firstname, role)
                                     VALUES (@Email, SHA2(@Password, 256), @Name, @Firstname, false);";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email",     email);
                        cmd.Parameters.AddWithValue("@Password",  password);
                        cmd.Parameters.AddWithValue("@Name",      name);
                        cmd.Parameters.AddWithValue("@Firstname", firstname);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur SQL : {ex.Message}");
                    return false;
                }
            }
        }

        // SB: Crée un nouvel utilisateur avec un rôle défini (utilisé par les administrateurs)
        public bool CreateUser(string email, string password, string name, string firstname, bool role)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO users (email, password, name, firstname, role)
                                     VALUES (@Email, SHA2(@Password, 256), @Name, @Firstname, @Role);";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email",     email);
                        cmd.Parameters.AddWithValue("@Password",  password);
                        cmd.Parameters.AddWithValue("@Name",      name);
                        cmd.Parameters.AddWithValue("@Firstname", firstname);
                        cmd.Parameters.AddWithValue("@Role",      role);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la création : {ex.Message}", "Erreur SQL",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // SB: Retourne la liste de tous les utilisateurs enregistrés en base de données
        public List<Users> GetAllUsers()
        {
            var users = new List<Users>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id_users, name, firstname, email, role FROM users;";
                    using (var cmd    = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new Users(
                                reader.GetInt32("id_users"),
                                reader.GetString("firstname"),
                                reader.GetString("name"),
                                reader.GetString("email"),
                                reader.GetBoolean("role")
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}");
                }
            }

            return users;
        }

        // SB: Met à jour les informations d'un utilisateur existant
        public bool UpdateUser(Users user)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"UPDATE users
                                     SET name      = @Name,
                                         firstname = @Firstname,
                                         email     = @Email,
                                         role      = @Role
                                     WHERE id_users = @Id;";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name",      user.Name);
                        cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                        cmd.Parameters.AddWithValue("@Email",     user.Email);
                        cmd.Parameters.AddWithValue("@Role",      user.Role);
                        cmd.Parameters.AddWithValue("@Id",        user.Id_Users);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}");
                    return false;
                }
            }
        }

        // SB: Supprime un utilisateur de la base de données par son identifiant
        public bool DeleteUser(int userId)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    using var cmd = new MySqlCommand(
                        "DELETE FROM users WHERE id_users = @Id;", connection);
                    cmd.Parameters.AddWithValue("@Id", userId);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}");
                    return false;
                }
            }
        }
    }
}
