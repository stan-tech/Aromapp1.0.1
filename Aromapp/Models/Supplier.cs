using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public  class Supplier
    {
        public Supplier()
        {

        }

        public Supplier(string c_fr, string name)
        {
            C_fr = c_fr;
            Nom = name;
        }
        public string C_fr { get; set; }
        public string Nom { get; set; }

        public string Activite { get; set; }
        public string Adresse { get; set; }

        public string Tel { get; set; }
        public string Email { get; set; }

        public string DateAjout { get; set; }
        public double Debts { get; set; }

        public string RC { get; set; }
        public string NIS { get; set; }
        public string NIF { get; set; }
        public string Fax { get; set; }

        public Supplier(string c_FR, string nom, string activite, string adresse,
            string tel, string fax, string email, string nis, string nif, string dateAjout)
        {
            C_fr = c_FR;
            Nom = nom;
            Activite = activite;
            Adresse = adresse;
            Tel = tel;
            Fax = fax;
            Email = email;
            NIS = nis;
            NIF = nif;
            DateAjout = dateAjout;
        }
    }
}
