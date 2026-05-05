namespace GSB2.Models
{
    // SB: Modèle représentant une prescription médicale
    public class Prescription
    {
        public int    Id_prescription { get; set; }
        public int    Id_users        { get; set; }
        public int    Id_patients     { get; set; }
        public string Validity        { get; set; }

        // SB: Constructeur principal utilisé lors de la lecture en base de données
        public Prescription(int id_prescription, int id_users, int id_patients, string validity)
        {
            Id_prescription = id_prescription;
            Id_users        = id_users;
            Id_patients     = id_patients;
            Validity        = validity;
        }
    }

    // SB: DTO utilisé pour l'affichage des prescriptions dans le DataGridView (liaison forte requise pour la génération auto des colonnes)
    public class PrescriptionView
    {
        public int    Id          { get; set; }
        public string Validite    { get; set; }
        public string Docteur     { get; set; }
        public string Patient     { get; set; }
        public string Medicaments { get; set; }
    }
}
