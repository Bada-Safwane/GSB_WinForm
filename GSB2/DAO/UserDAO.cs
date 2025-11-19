using GSB2.Models;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GSB2.DAO
{
    internal class UserDAO
    {
        private readonly Database db = new Database();
            public Users GetUsers(string email,string password)
            {
                using(var connection = db.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        // create a MySQL command and set the SQL statement with parameters
                        MySqlCommand myCommand = new MySqlCommand();
                        myCommand.Connection = connection;
                        myCommand.CommandText = @"SELECT * FROM users WHERE email = @email AND password = SHA2(@password, 256);";
                        myCommand.Parameters.AddWithValue("@email", email);
                        myCommand.Parameters.AddWithValue("@password", password);

                        using var myReader = myCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            int id_Users = myReader.GetInt32("id_Users");
                            string name = myReader.GetString("name");
                            string firstname = myReader.GetString("firstname");
                            bool role = myReader.GetBoolean("role");
                            connection.Close();
                            return new Users(id_Users, name, firstname, email, role);
                        }

                        connection.Close();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur de connexion : {ex.Message}", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
            }
        }
    }
}
