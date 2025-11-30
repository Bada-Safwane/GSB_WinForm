using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB2.Models
{
    public class LiaiMP
    {
        public int Id_medicine { get; set; }
        public int Id_prescription { get; set; }
        public int Quantity { get; set; }
        public LiaiMP(int id_medicine, int id_prescription, int quantity)
        {
            Id_medicine = id_medicine;
            Id_prescription = id_prescription;
            Quantity = quantity;
        }
    }
}
