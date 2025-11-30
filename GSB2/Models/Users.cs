using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GSB2.Models
{
    public class Users
    {
        // ceci est une propriété permet de lire et d'écrire les attribue de la classe
        public int Id_Users { get; set; }
        public string Firstname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }


        // ceci est le constructeur, permet d'accédr aux méthode et propriété de notre class
        //public Users()
        //{

        //}

        // ceci est une surcharge du constructeur elle permer la création d'un objet user avec les champ passé en param
        //public Users(int id_Users, string firstname, string name, string email, string password, bool role)
        //{
        //    Id_Users = id_Users;
        //    Firstname = firstname;
        //    Name = name;
        //    Email = email;
        //    Password = password;
        //    Role = role;
        //}

        public Users(int id_Users, string firstname, string name, string email, bool role)
        {
            Id_Users = id_Users;
            Name = name;
            Firstname = firstname;
            Email = email;
            Role = role;
        }
    }
}
