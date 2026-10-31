using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp.Models
{
    public class PriceChangingProps
    {
        public string  SaleRef { get; set; }
        public string ProdRef {  get; set; }
        public double TotalBulk { get; set; }
        public double TotalRetail { get; set; }
        public double Quantity { get; set; }
        public double NewPrice { get; set; }

        public bool IsRetail { get; set; }
        public PriceChangingProps()
        {
            
        }


    }
}
