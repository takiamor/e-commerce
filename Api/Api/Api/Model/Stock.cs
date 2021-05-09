using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Stock
    {
        public int id_s { get; set; }
        public string product { get; set; }
        public int stockin { get; set; }
        public int stockout { get; set; }
        public int allstock { get; set; }
    }
}
