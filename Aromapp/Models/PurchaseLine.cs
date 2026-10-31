using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class PurchaseLine
    {
        public string N { get; set; }
        public string Type { get; set; }
        public DateTime DateA { get; set; }
        public string C_FR { get; set; }
        public string NomFour { get; set; }
        public string C_PR { get; set; }
        public string Nomproduit { get; set; }
        public double Quantité { get; set; }
        public double PrixHT { get; set; }
        public long Marge { get; set; }
        public long TVA { get; set; }
        public long Remise { get; set; }
        public bool avendre { get; set; }
        public double PrixVG { get; set; }
        public double PrixVD { get; set; }
        public string Unit { get; set; }
        public double MontantHT { get; set; }

        // Constructor
        public PurchaseLine(string n, string type, DateTime dateA, string c_FR, string nomFour,
                             string c_PR, string nomproduits, long quantité, double prixHT,
                             long marge, long tva, long remise, bool avendre)
        {
            N = n;
            Type = type;
            DateA = dateA;
            C_FR = c_FR;
            NomFour = nomFour;
            C_PR = c_PR;
            Nomproduit = nomproduits;
            Quantité = quantité;
            PrixHT = prixHT;
            Marge = marge;
            TVA = tva;
            Remise = remise;
            this.avendre = avendre;
        }

        public PurchaseLine()
        {

        }
    }
}
