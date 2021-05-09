using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Command
    {
       public  int id_cmd { get; set;}
       public string date_cmd { get; set; }
       public int amount_cmd { get; set; }
        public string datedeliv_cmd { get; set; }
        public string location_cmd { get; set; }
        public string modedeliv_cmd { get; set; }
        public int price_cmd { get; set; }
        public string modepayment_cmd { get; set; }
    }
}
