using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class AccountItemModel
    {
        public AccountItemModel()
        {
        }

        public AccountItemModel(string ID, string Name, double amount)
        {
            this.Name = Name;
            this.Amount = amount.ToString();
            this.ID = ID;
        }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string ID { get; set; }
    }
}
