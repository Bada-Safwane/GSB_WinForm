namespace GSB2.Models
{
    // SB: Modèle représentant un médicament
    public class Medicine
    {
        public int    Id_Medicine  { get; set; }
        public int    Id_Users     { get; set; }
        public string Dosage       { get; set; }
        public string Names        { get; set; }
        public string Description  { get; set; }
        public string Molecule     { get; set; }

        // SB: Constructeur vide utilisé pour l'initialisation via les propriétés
        public Medicine() { }

        // SB: Constructeur principal utilisé lors de la lecture en base de données
        public Medicine(int id_medicine, int id_users, string dosage, string names, string description, string molecule)
        {
            Id_Medicine = id_medicine;
            Id_Users    = id_users;
            Dosage      = dosage;
            Names       = names;
            Description = description;
            Molecule    = molecule;
        }
    }

    // SB: DTO utilisé pour l'affichage des médicaments dans le DataGridView (liaison forte requise pour la génération auto des colonnes)
    public class MedicineView
    {
        public int    Id_medicine  { get; set; }
        public int    Id_users     { get; set; }
        public string Dosage       { get; set; }
        public string Name         { get; set; }
        public string Description  { get; set; }
        public string Molecule     { get; set; }
        public string User         { get; set; }
    }
}
