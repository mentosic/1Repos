using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_COM
{
    public class Buyer
    {
        public int id { get; set; }
        public double price { get; set; }
        public ICollection<Product> Products { get; set; } // список товаров
        public Buyer()
        {
            Products = new List<Product>();
        }
    }
}
