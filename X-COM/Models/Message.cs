using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_COM
{
    public class Message
    {
        public int id { get; set; }
        public string name { get; set; } // имя того, кто оставил коммент
        public string text { get; set; } // текст отзыва
        public DateTime date { get; set; } // дата отзыва
        public int score { get; set; } // оценка (от 0 до 5)
    }
}
