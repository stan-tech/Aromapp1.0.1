using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class Product
    {

        public string Name { get; set; }
        public string ID { get; set; }

        public double Quantity { get; set; }
        public double PriceG { get; set; }
        public double PriceD { get; set; }
        public int Index { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public double PriceP { get; set; }
        public string BarCode { get; internal set; }
        public double StockAlert { get; set; }
        
        public string c_fr { get; set;}
        public string SupplierName { get; set; }

        public Product() { }
    }
}
