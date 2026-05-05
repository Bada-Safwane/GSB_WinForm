namespace GSB2.Models
{
    // SB: Modèle représentant un patient
    public class Patients
    {
        public int    Id_Patients { get; set; }
        public int    Id_Users    { get; set; }
        public string Name        { get; set; }
        public int    Age         { get; set; }
        public string Firstname   { get; set; }
        public string Gender      { get; set; }

        // SB: Constructeur vide utilisé pour l'initialisation via les propriétés
        public Patients() { }

        // SB: Constructeur principal utilisé lors de la lecture en base de données
        public Patients(int id_patients, int id_users, string name, int age, string firstname, string gender)
        {
            Id_Patients = id_patients;
            Id_Users    = id_users;
            Name        = name;
            Age         = age;
            Firstname   = firstname;
            Gender      = gender;
        }
    }
}
