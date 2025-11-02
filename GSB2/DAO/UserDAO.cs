using GSB2.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
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
                        myCommand.CommandText = @"SELECT * FROM users WHERE email = @email AND password = @password;";
                        myCommand.Parameters.AddWithValue("@email", email);
                        myCommand.Parameters.AddWithValue("@password", password);

                        int id = 0;
                        string name = "";

                        // execute the command and read the results
                        using var myReader = myCommand.ExecuteReader();
                        {
                        

                            if (myReader.Read())
                            {
                                id = myReader.GetInt32("id_users");
                                name = myReader.GetString("name");
                            }
                             
                        }
                        connection.Close();
                        Users user = new Users(id, name);
                        return user;

                    }

                    catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}
