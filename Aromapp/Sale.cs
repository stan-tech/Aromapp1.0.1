using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class Sale
    {
        public string N { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string C_Prod { get; set; }
        public string C_CL { get; set; }
        public decimal TotalHT { get; set; }
        public string ModeReglement { get; set; }
        public decimal Timbre { get; set; }
        public string Regler { get; set; }
        public decimal MontantRegler { get; set; }
        public decimal MontantRest { get; set; }
        public decimal RemiseTotal { get; set; }

        // Constructor with all fields
        public Sale(string n, string type, string date, string c_CL, decimal totalHT,
            string modeReglement, decimal timbre, string regler, decimal montantRegler, decimal montantRest)
        {
            N = n;
            Type = type;
            Date = date;
            C_CL = c_CL;
            TotalHT = totalHT;
            ModeReglement = modeReglement;
            Timbre = timbre;
            Regler = regler;
            MontantRegler = montantRegler;
            MontantRest = montantRest;
        }
        public Sale()
        {

        }
    }
}
