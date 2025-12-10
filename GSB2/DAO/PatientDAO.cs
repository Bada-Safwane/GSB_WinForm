using GSB2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB2.DAO
{
    public class PatientDAO
    {
        private readonly Database db = new Database();

        // ✅ Récupérer un patient par son ID
        public Patients? GetPatientById(int id_patient)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Patients WHERE id_patients = @id_patients;";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id_patients", id_patient);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Patients(
                                reader.GetInt32("id_patients"),
                                reader.GetInt32("id_users"),
                                reader.GetString("name"),
                                reader.GetInt32("age"),
                                reader.GetString("firstname"),
                                reader.GetString("gender")
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur GetPatientById : " + ex.Message);
                }
            }
            return null;
        }

        // ✅ Créer un nouveau patient
        public bool CreatePatient(int id_users, string name, int age, string firstname, string gender)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO patients (id_users, name, age, firstname, gender) 
                                     VALUES (@id_users, @name, @age, @firstname, @gender);";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id_users", id_users);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@gender", gender);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur CreatePatient : " + ex.Message);
                    return false;
                }
            }
        }
        public bool Insert(Patients patient)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"
                INSERT INTO patients (id_users, name, firstname, age, gender)
                VALUES (@id_users, @name, @firstname, @age, @gender);
            ";

                    using MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id_users", patient.Id_Users);
                    cmd.Parameters.AddWithValue("@name", patient.Name);
                    cmd.Parameters.AddWithValue("@firstname", patient.Firstname);
                    cmd.Parameters.AddWithValue("@age", patient.Age);
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);

                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de l'insertion du patient : {ex.Message}");
                    return false;
                }
            }
        }

        // ✅ Récupérer tous les patients
        public List<dynamic> GetAllPatients()
        {
            List<dynamic> patients = new List<dynamic>();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    p.id_patients,
                    p.name AS patient_name,
                    p.firstname AS patient_firstname,
                    p.age,
                    p.gender,
                    u.firstname AS doctor_firstname,
                    u.name AS doctor_name
                FROM patients p
                INNER JOIN users u ON p.id_users = u.id_users
                ORDER BY p.id_patients ASC;
            ";

                    using MySqlCommand cmd = new MySqlCommand(query, connection);
                    using var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        patients.Add(new
                        {
                            Id = reader.GetInt32("id_patients"),
                            Name = reader["patient_name"].ToString(),
                            Firstname = reader["patient_firstname"].ToString(),
                            Age = reader.GetInt32("age"),
                            Gender = reader["gender"].ToString(),
                            Doctor = $"{reader["doctor_firstname"]} {reader["doctor_name"]}"
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("💥 Erreur GetAllPatients : " + ex.Message);
                }
            }

            return patients;
        }

        public List<Patients> GetPatientsForComboBox()
        {
            List<Patients> patients = new List<Patients>();
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                    SELECT id_patients,id_users, name, age, firstname, gender
                    FROM Patients
                    ORDER BY name, firstname ASC;
                    ";
                    using MySqlCommand cmd = new MySqlCommand(query, connection);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        patients.Add(new Patients(
                            reader.GetInt32("id_patients"),
                            reader.GetInt32("id_users"),
                            reader["name"].ToString(),
                            reader.GetInt32("age"),
                            reader["firstname"].ToString(),
                            reader["gender"].ToString()
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("💥 Erreur GetPatientsForComboBox : " + ex.Message);
                }
            }
            return patients;
        }


        // ✅ Supprimer un patient
        public bool DeletePatient(int id_patient)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM patients WHERE id_patients = @id_patient;";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id_patient", id_patient);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur DeletePatient : " + ex.Message);
                    return false;
                }
            }
        }

        // ✅ Mettre à jour un patient
        public bool UpdatePatient(Patients patient)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE patients 
                                     SET id_users = @id_users, 
                                         name = @name, 
                                         age = @age, 
                                         firstname = @firstname, 
                                         gender = @gender
                                     WHERE id_patients = @id_patient;";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id_users", patient.Id_Users);
                    cmd.Parameters.AddWithValue("@name", patient.Name);
                    cmd.Parameters.AddWithValue("@age", patient.Age);
                    cmd.Parameters.AddWithValue("@firstname", patient.Firstname);
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@id_patient", patient.Id_Patients);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur UpdatePatient : " + ex.Message);
                    return false;
                }
            }
        }
    }
}
