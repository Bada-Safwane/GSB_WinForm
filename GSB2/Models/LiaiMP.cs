namespace GSB2.Models
{
    // SB: Modèle représentant l'association entre un médicament et une prescription avec sa quantité
    public class LiaiMP
    {
        public int Id_medicine    { get; set; }
        public int Id_prescription { get; set; }
        public int Quantity        { get; set; }

        // SB: Constructeur principal utilisé lors de la lecture en base de données
        public LiaiMP(int id_medicine, int id_prescription, int quantity)
        {
            Id_medicine    = id_medicine;
            Id_prescription = id_prescription;
            Quantity        = quantity;
        }
    }
}
