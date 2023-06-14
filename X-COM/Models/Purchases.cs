using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_COM
{
    public class Purchases
    {
        public int id { get; set; }
        public double price { get; set; } // стоимость покупки
        public DateTime date { get; set; } // дата покупки
        public bool delivery { get; set; } // с доставкой или без
    }
}
