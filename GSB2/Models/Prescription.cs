using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB2.Models
{
    public class Prescription
    {


        // ceci est une propriété permet de lire et d'écrire les attribue de la classe
        public int Id_Prescription { get; set; }
        public int Id_Patients { get; set; }
        public int Id_Users { get; set; }
        public string Quantity { get; set; }
        public string Validity { get; set; }


        // ceci est le constructeur, permet d'accédr aux méthode et propriété de notre class
        public Prescription()
        {

        }

        // ceci est une surcharge du constructeur elle permer la création d'un objet user avec les champ passé en param
        public Prescription(int id_patients, int id_users, int id_prescription, string quantity, string validty)
        {
            Id_Users = id_users;
            Id_Patients = id_patients;
            Id_Prescription = id_prescription;
            Quantity = quantity;
            Validity = validty;
        }




    }
}
