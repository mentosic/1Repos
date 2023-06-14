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
    public partial class WriteMess : Form
    {
        public WriteMess()
        {
            InitializeComponent();
            iniz();
        }

        private void iniz()
        {
            foreach (User user in index.db.Users)
            {
                if (user.id == index.user)
                {
                    label8.Text = $"Имя: {user.name}";
                    label1.Text = $"Дата: {DateTime.Today.ToShortDateString()}";
                    break;
                }    
            }    
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackColor = Color.DarkBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Peru;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
            button2.BackColor = Color.DarkBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
            button2.BackColor = Color.Peru;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        // опубликовать //
        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim() != "")
            {
                string name = "";
                foreach (User user in index.db.Users)
                {
                    if (user.id == index.user)
                    {
                        name = user.name;
                        break;
                    }
                }
                Message message = new Message()
                {
                    name = name,
                    date = DateTime.Today,
                    text = richTextBox1.Text,
                    score = (int)numericUpDown1.Value,
                };
                index.db.Messages.Add(message);
                index.db.SaveChanges();

                foreach (Product P in index.db.Products)
                {
                    if (P.id == MessageProduct.id)
                    {
                        P.Messages.Add(message);
                        break;
                    }
                }
                index.db.SaveChanges();

                MessageBox.Show("Спасибо за оставленный отзыв!\nЖелаем приятного дня!", "Внимание!");
                Close();
            }
            else
                MessageBox.Show("Введите сообщение!", "Внимание!");
        }
    }
}
