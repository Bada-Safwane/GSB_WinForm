using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB2.Models
{
    public class Medicine
    {

        // ceci est une propriété permet de lire et d'écrire les attribue de la classe
        public int Id_Medicine { get; set; }
        public int Id_Users { get; set; }
        public string Dosage { get; set; }
        public string Names { get; set; }
        public string Description { get; set; }
        public string Molecule { get; set; }


        // ceci est le constructeur, permet d'accédr aux méthode et propriété de notre class
        public Medicine()
        {

        }

        // ceci est une surcharge du constructeur elle permer la création d'un objet user avec les champ passé en param
        public Medicine(int id_medicine, int id_users, string dosage, string names, string description, string molecule)
        {
            Id_Medicine = id_medicine;
            Id_Users = id_users;
            Dosage = dosage;
            Names = names;
            Description = description;
            Molecule = molecule;
        }
    }
}
