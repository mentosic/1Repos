using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_COM
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string brend { get; set; }
        public double price { get; set; } // стоимость за 1 штуку
        public int number { get; set; } // количество на складе
        public int bonus { get; set; } // промокод. 0 - нет его
        public int stock { get; set; } // акция. 0 - нет
        // акция и промокод на товар может быть только по 1 //
        public bool copy { get; set; } // переменная копирования для корзины
        public bool cod { get; set; } // переменная заюзания промокода
        public string path { get; set; } // путь к фото
        public ICollection<Message> Messages { get; set; } // список отзывов
        public Product()
        {
            Messages = new List<Message>();
        }
    }
}
