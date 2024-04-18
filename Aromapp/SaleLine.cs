using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class SaleLine
    {
        public string N { get; set; }
        public string Type { get; set; }
        public DateTime DateA { get; set; }
        public string C_CL { get; set; }
        public string C_PR { get; set; }
        public string NomClient { get; set; }

        public string Nomproduit { get; set; }
        public double Quantité { get; set; }
        public double PrixHT { get; set; }
        public double Marge { get; set; }
        public long TVA { get; set; }
        public double Remise { get; set; }

        public double BuyingPrice { get; set; }

        public string Unit { get; set; }
        public double MontantHT { get; set; }

        // Constructor
        public SaleLine(string n, string type, DateTime dateA, string c_CL, string nomFour,
                             string c_PR, string nomproduits, long quantité, double prixHT,
                             long marge, long tva, long remise)
        {
            N = n;
            Type = type;
            DateA = dateA;
            C_CL = c_CL;
            C_PR = c_PR;
            Nomproduit = nomproduits;
            Quantité = quantité;
            PrixHT = prixHT;
            Marge = marge;
            TVA = tva;
            Remise = remise;
        }

        public SaleLine()
        {

        }
    }
}
