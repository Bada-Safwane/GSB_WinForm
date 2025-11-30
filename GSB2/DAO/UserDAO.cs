using GSB2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GSB2.DAO
{
    public class UserDAO
    {
        private readonly Database db = new Database();

        // ----------------------------------------------------------
        // LOGIN
        // ----------------------------------------------------------
        public Users GetUsers(string email, string password)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(
                    @"SELECT id_users, firstname, name, email, role 
                      FROM users 
                      WHERE email = @email AND password = SHA2(@password, 256);",
                    connection);

                    cmd.Parameters.AddWithValue("@email", email);
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


        // ----------------------------------------------------------
        // REGISTER
        // ----------------------------------------------------------
        public bool Register(string email, string password, string name, string firstname)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Check duplicates
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

                    string query = @"INSERT INTO users 
                        (email, password, name, firstname, role)
                        VALUES (@Email, SHA2(@Password, 256), @Name, @Firstname, false);";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Name", name);
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

        public bool CreateUser(string email, string password, string name, string firstname, bool role)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO Users (email, password, name, firstname, role)
                        VALUES (@Email, SHA2(@Password, 256), @Name, @Firstname, @Role);";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Firstname", firstname);
                        cmd.Parameters.AddWithValue("@Role", role);

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
        // ----------------------------------------------------------
        // GET ALL USERS
        // ----------------------------------------------------------
        public List<Users> GetAllUsers()
        {
            var users = new List<Users>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id_user, name, firstname, email, role FROM users;";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new Users(
                                reader.GetInt32("id_user"),
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


        // ----------------------------------------------------------
        // UPDATE USER
        // ----------------------------------------------------------
        public bool UpdateUser(Users user)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"UPDATE users
                        SET name = @Name, firstname = @Firstname, email = @Email, role = @Role
                        WHERE id_user = @Id;";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", user.Name);
                        cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Role", user.Role);
                        cmd.Parameters.AddWithValue("@Id", user.Id_Users);

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


        // ----------------------------------------------------------
        // DELETE USER
        // ----------------------------------------------------------
        public bool DeleteUser(int userId)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM users WHERE id_user = @Id;";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", userId);
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
    }
}
