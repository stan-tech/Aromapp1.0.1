using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class Client
    {
        public string C_CL { get; set; }
        public string Nom { get; set; }
        public string Activite { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public double Debts { get; set; }


        public string DatAjout { get; set; }
        public string NIS { get; set; }
        public string NIF { get; set; }

        public Client()
        {

        }

        public Client(string name, string phone, string addr, string email, string fax)
        {
            this.Nom = name;
            this.Tel = phone;
            this.Adresse = addr;
            this.Email = email;
            this.Fax = fax;
        }
    }
}
