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
    public partial class UserInput : Form
    {
        public UserInput()
        {
            InitializeComponent();
            textBox1.UseSystemPasswordChar = true;
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

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.GreenYellow;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }

        // вернуться //
        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox1.UseSystemPasswordChar = false;
            else
                textBox1.UseSystemPasswordChar = true;
        }

        // зарегистрируйся //
        private void label4_Click(object sender, EventArgs e)
        {
            Registr registration = new Registr();
            registration.ShowDialog();
        }

        // вход //
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "" && textBox1.Text.Trim() != "")
            {
                int flag = 0;
                foreach (User user in index.db.Users)
                {
                    if (user.email == textBox2.Text && user.password == textBox1.Text)
                    {
                        index.user = user.id;
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    ProfileAndBuyer profileAndBuyer = new ProfileAndBuyer();
                    profileAndBuyer.ShowDialog();
                    Close();
                }
                else
                    MessageBox.Show("Неправильный логин или пароль!\nПроверьте правильность заполнения данных", "Внимание!");
            }
            else
                MessageBox.Show("Неправильный логин или пароль!\nПроверьте правильность заполнения данных", "Внимание!");
        }
    }
}
