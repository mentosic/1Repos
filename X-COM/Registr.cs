using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_COM
{
    public partial class Registr : Form
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = Color.White;
            button5.BackColor = Color.DarkBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.Black;
            button5.BackColor = Color.Moccasin;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackColor = Color.DarkBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
            button1.BackColor = Color.Moccasin;
        }

        // вернуться //
        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        // создать //
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != ""
                && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != ""
                && maskedTextBox1.MaskCompleted == true)
            {
                int flag = 0;
                foreach (User U in index.db.Users)
                {
                    if (textBox4.Text.Trim() == U.email)
                    {
                        MessageBox.Show("На данную почту уже зарегистрирован аккаунт", "Внимание!");
                        break;
                    }
                }
                if (flag == 0)
                {
                    User user = new User()
                    {
                        name = textBox1.Text,
                        email = textBox4.Text,
                        phone = maskedTextBox1.Text,
                        address = textBox2.Text,
                        password = textBox3.Text,
                        buyerId = 0
                    };
                    // создаем корзину покупателя //
                    Buyer buyer = new Buyer()
                    {
                        price = 0
                    };
                    index.db.Buyers.Add(buyer);
                    index.db.SaveChanges();
                    user.buyerId = buyer.id;
                    index.db.Users.Add(user);
                    index.db.SaveChanges();
                    MessageBox.Show("Профиль успешно создан!", "Внимание!");
                    Close();
                }
            }
            else
                MessageBox.Show("Некорректно введены данные:(", "Внимание!");
        }
    }
}
