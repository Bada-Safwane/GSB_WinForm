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
        public int Id_prescription { get; set; }
        public int Id_users { get; set; }
        public int Id_patients { get; set; }
        //public string Quantity { get; set; }
        public string Validity { get; set; }

        // ceci est le constructeur, permet d'accédr aux méthode et propriété de notre class
        public Prescription(int id_prescription, int id_users, int id_patients, string validity)
        {
            Id_prescription = id_prescription;
            Id_users = id_users;
            Id_patients = id_patients;
            // Quantity = quantity;
            Validity = validity;
        }




    }
}
