using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class User
    {

        public string Name { get; set; }
        public string BarCode { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string ID { get; set; }
        public bool isActive { get; set; }


        public User() { }

        public User(string name, string barcode, string password, bool isAdmin)
        {
            Name = name;
            BarCode = barcode;
            Password = password;
            IsAdmin = isAdmin;

        }
        public User(string name, string id)
        {
            Name = name;
            ID = id;

        }
    }
}
