using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class produits
    {
        public string Nomproduits { get; set; }
        public double Quantité { get; set; }
        public double PrixHT { get; set; }
        public double Marge { get; set; }
        public long TVA { get; set; }
        public double Remise { get; set; }
        public double MontantHT { get; set; }

        // Constructor with all fields
        public produits(string nomproduits, double quantité, double prixHT, long marge, double remise)
        {
            Nomproduits = nomproduits;
            Quantité = quantité;
            PrixHT = prixHT;
            Marge = marge;
            Remise = remise;
        }
        public produits() { }
    }
}
