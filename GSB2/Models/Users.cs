namespace GSB2.Models
{
    // SB: Modèle représentant un utilisateur (médecin ou administrateur)
    public class Users
    {
        public int    Id_Users  { get; set; }
        public string Firstname { get; set; }
        public string Name      { get; set; }
        public string Email     { get; set; }
        public string Password  { get; set; }
        public bool   Role      { get; set; }

        // SB: Constructeur principal utilisé lors de la lecture en base de données
        public Users(int id_Users, string firstname, string name, string email, bool role)
        {
            Id_Users  = id_Users;
            Firstname = firstname;
            Name      = name;
            Email     = email;
            Role      = role;
        }
    }
}
