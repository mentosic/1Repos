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
    public partial class EditData : Form
    {
        string path = "";
        public EditData()
        {
            InitializeComponent();
            iniz();   
        }

        private void iniz()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Создать");
            foreach (Product P in index.db.Products)
            {
                if (P.copy == false)
                    comboBox1.Items.Add($"{P.name} id- {P.id}");
            }
            comboBox1.SelectedIndex = 0;
        }

        private void on()
        {
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            button5.Visible = true;
            button4.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
        }

        private void off()
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            pictureBox1.BackgroundImage = null;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
            button3.BackColor = Color.DarkBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
            button3.BackColor = Color.Peru;
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

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.ForeColor = Color.White;
            button6.BackColor = Color.DarkBlue;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.ForeColor = Color.White;
            button6.BackColor = Color.Peru;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = Color.White;
            button5.BackColor = Color.DarkBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.White;
            button5.BackColor = Color.Peru;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White;
            button4.BackColor = Color.DarkBlue;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White;
            button4.BackColor = Color.Peru;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.ForeColor = Color.White;
            button7.BackColor = Color.DarkBlue;

        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.ForeColor = Color.White;
            button7.BackColor = Color.Peru;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.ForeColor = Color.White;
            button8.BackColor = Color.DarkBlue;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.ForeColor = Color.White;
            button8.BackColor = Color.Peru;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.ForeColor = Color.White;
            button9.BackColor = Color.DarkBlue;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.ForeColor = Color.White;
            button9.BackColor = Color.Peru;
        }

        // вернуться в меню //
        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                off();
            }
            else
            {
                on();
                Product();
                skidka();
                Code();
            }
        }

        private void Code()
        {
            string[] str = comboBox1.Text.Split(' ');
            int flag = 0;
            foreach (Product P in index.db.Products)
            {
                if (P.id == Convert.ToInt32(str[str.Length - 1]))
                {
                    if (P.bonus != 0)
                    {
                        foreach (Bonus B in index.db.Bonus)
                        {
                            if (B.id == P.bonus)
                            {
                                flag = 1;
                                textBox4.Text = B.name;
                                numericUpDown3.Value = (decimal)B.discount;
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            if (flag == 0)
            {
                textBox4.Text = "";
                numericUpDown3.Value = 0;
            }
        }

        private void Product()
        {
            string[] str = comboBox1.Text.Split(' ');
            pictureBox1.BackgroundImage = null;
            foreach (Product P in index.db.Products)
            {
                if (P.id == Convert.ToInt32(str[str.Length-1]))
                {
                    try
                    {
                        textBox1.Text = P.name;
                        textBox2.Text = P.type;
                        textBox3.Text = P.brend;
                        numericUpDown1.Value = (decimal)P.price;
                        numericUpDown2.Value = (decimal)P.number;
                        pictureBox1.BackgroundImage = Image.FromFile(P.path);
                    }
                    catch { }
                    break;
                }
            }
        }

        // сбросить ваучер //
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox4.Text = "";
                numericUpDown3.Value = 0;
            }
            else
                Code();
        }

        // сбросить товар //
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                off();
            }
            else
            {
                Product();
                skidka();
                Code();
            }
        }

        // скидка //
        private void skidka()
        {
            string[] str = comboBox1.Text.Split(' ');
            int flag = 0;
            foreach (Product P in index.db.Products)
            {
                if (P.id == Convert.ToInt32(str[str.Length - 1]))
                {
                    if (P.stock != 0)
                    {
                        foreach (Stock S in index.db.Stocks)
                        {
                            if (S.id == P.stock)
                            {
                                textBox5.Text = S.name;
                                numericUpDown4.Value = (decimal)S.discount;
                                flag = 1;
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            if (flag == 0)
            {
                textBox5.Text = "";
                numericUpDown4.Value = 0;
            }
        }


        // удалить фото //
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
        }

        // добавление фото //
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog(); // создаем диалоговое окно
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; // формат загружаемых картинок

            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    path = open_dialog.FileName; // запоминаем путь к файлу
                    pictureBox1.BackgroundImage = Image.FromFile(path);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // сохранение/добавление товара //
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && numericUpDown1.Value != 0 && numericUpDown2.Value != 0 && pictureBox1.BackgroundImage != null)
            {
                if (comboBox1.SelectedIndex == 0) // добавить
                {
                    Product p = new Product()
                    {
                        name = textBox1.Text,
                        type = textBox2.Text,
                        brend = textBox3.Text,
                        price = (int)numericUpDown1.Value,
                        number = (int)numericUpDown2.Value,
                        bonus = 0,
                        stock = 0,
                        copy = false,
                        cod = false,
                        path = path,
                    };
                    index.db.Products.Add(p);
                    index.db.SaveChanges();
                    iniz();
                }
                else // изменить
                {
                    string[] str = comboBox1.Text.Split(' ');
                    foreach (Product P in index.db.Products)
                    {
                        if (P.id == Convert.ToInt32(str[str.Length - 1]))
                        {
                            P.name = textBox1.Text;
                            P.type = textBox2.Text;
                            P.brend = textBox3.Text;
                            P.price = (int)numericUpDown1.Value;
                            P.number = (int)numericUpDown2.Value;
                            P.path = path;
                            break;
                        }
                    }
                    index.db.SaveChanges();
                    iniz();
                }
            }
            else
                MessageBox.Show("Заполните все поля!", "Внимание!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox5.Text = "";
                numericUpDown4.Value = 0;
            }
            else
                skidka();
        }

        // сохранить скидку //
        private void button8_Click(object sender, EventArgs e)
        {
            string[] str = comboBox1.Text.Split(' ');
            Stock stock = new Stock();
            int flag = 0;
            foreach (Product P in index.db.Products)
            {
                if (P.id == Convert.ToInt32(str[str.Length - 1]))
                {
                    if (textBox5.Text != "" && numericUpDown4.Value != 0)
                    {
                        stock.name = textBox5.Text;
                        stock.discount = (int)numericUpDown4.Value;
                    }
                    else
                    {
                        MessageBox.Show("Скидка успешно удалена", "Внимание!");
                        P.stock = 0;
                        flag = 1;
                    }    
                    break;
                }
            }
            if (flag == 0)
            {
                index.db.Stocks.Add(stock);
                index.db.SaveChanges();
                foreach (Product P in index.db.Products)
                {
                    if (P.id == Convert.ToInt32(str[str.Length - 1]))
                    {
                        P.stock = stock.id;
                        break;
                    }
                }
                index.db.SaveChanges();
                MessageBox.Show("Скидка на товар создана", "Внимание!");
            }
        }

        // сохранить - добавить ваучер //
        private void button4_Click(object sender, EventArgs e)
        {
            string[] str = comboBox1.Text.Split(' ');
            Bonus bonus = new Bonus();
            int flag = 0;
            foreach (Product P in index.db.Products)
            {
                if (P.id == Convert.ToInt32(str[str.Length - 1]))
                {
                    if (textBox4.Text != "" && numericUpDown3.Value != 0)
                    {
                        bonus.name = textBox4.Text;
                        bonus.discount = (int)numericUpDown3.Value;
                    }
                    else
                    {
                        MessageBox.Show("Ваучер успешно удален", "Внимание!");
                        P.bonus = 0;
                        flag = 1;
                    }
                    break;
                }
            }
            if (flag == 0)
            {
                index.db.Bonus.Add(bonus);
                index.db.SaveChanges();
                foreach (Product P in index.db.Products)
                {
                    if (P.id == Convert.ToInt32(str[str.Length - 1]))
                    {
                        P.bonus = bonus.id;
                        break;
                    }
                }
                index.db.SaveChanges();
                MessageBox.Show("Ваучер успешно добавлен к товару", "Внимание!");
            }
        }
    }
}
