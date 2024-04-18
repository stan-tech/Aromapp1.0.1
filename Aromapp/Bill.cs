using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class Bill
    {
        public string N { get; set; }
        public string Type { get; set; }
        public DateTime DateA { get; set; }
        public string C_CL { get; set; }
        public double TotalTTC { get; set; }
        public double TotalRemise { get; set; }
        public double ModeReglement { get; set; }
        public string Regler { get; set; }
        public double MontantRegler { get; set; }
        public double MontantRest { get; set; }
        public double TauxTVA { get; set; }
        public string User { get; set; }
        public double Benefice { get; set; }
        public int N_Ligne { get; set; }
        public Client ClientObj { get; set; }


        public Bill()
        {

        }
    }
}
