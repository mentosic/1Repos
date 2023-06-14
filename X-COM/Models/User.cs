using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_COM
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; } // почта для отзывов и она же логин для входа
        public string phone { get; set; } // телефон для связи
        public string address { get; set; } // адрес доставки, доставка скаладывается от суммы (стоимость товара * 0.05)
        public string password { get; set; } // пароль для входа в личный кабинет
        public int buyerId { get; set; } // корзина покупателя
        public ICollection<Purchases> Purchases { get; set; } // список чеков клиента
        public User()
        {
            Purchases = new List<Purchases>();
        }
    }
}
