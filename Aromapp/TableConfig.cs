using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public class TableConfig
    {
        public string SourceTable { get; set; }
        public string DestinationTable { get; set; }
        public string IdColumn { get; set; }
        public string[] Columns { get; set; }


    }
}
