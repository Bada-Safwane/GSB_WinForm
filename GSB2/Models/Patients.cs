using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GSB2.Models
{
    public class Patients
    {


        // ceci est une propriété permet de lire et d'écrire les attribue de la classe
        public int Id_Patients { get; set; }
        public int Id_Users { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Firstname { get; set; }
        public bool Gender { get; set; }

        // ceci est une surcharge du constructeur elle permer la création d'un objet user avec les champ passé en param
        public Patients(int id_patients, int id_users, string name, int age, string firstname, bool gender)
        {
            Id_Users = id_users;
            Id_Patients = id_patients;
            Name = name;
            Age = age;
            Firstname = firstname;
            Gender = gender;
        }
    }
}
