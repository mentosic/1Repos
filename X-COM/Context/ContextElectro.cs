using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace X_COM
{
    public class ContextElectro : DbContext
    {
        public ContextElectro() : base("StoreElectroV6")
        { }

        // заносим в БД наши модели (таблицы)
        public DbSet<Buyer> Buyers { get; set; } // корзины
        public DbSet<Purchases> Purchases { get; set; } // чеки
        public DbSet<User> Users { get; set; } // клиенты
        public DbSet<Bonus> Bonus { get; set; } // промокоды
        public DbSet<Product> Products { get; set; } // запчасти
        public DbSet<Stock> Stocks { get; set; } // акции
        public DbSet<Message> Messages { get; set; } // отзывы
    }
}
