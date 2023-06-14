using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace X_COM
{
    public partial class ProfileAndBuyer : Form
    {
        public static double price = 0;
        public static int numProd = 0;

        public ProfileAndBuyer()
        {
            InitializeComponent();
            iniz();
            money();
            groupBox1.Visible = false;
            groupBox3.Visible = false;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        // заполнение списка товаров корзины //
        private void money()
        {
            price = 0;
            checkedListBox1.Items.Clear();
            foreach (User U in index.db.Users)
            {
                if (U.id == index.user)
                {
                    foreach (Buyer B in index.db.Buyers.Include(P => P.Products))
                    {
                        if (B.id == U.buyerId)
                        {
                            foreach (Product P in B.Products)
                            {
                                double money = P.price;
                                if (P.stock != 0) // если есть акция
                                {
                                    foreach (Stock S1 in index.db.Stocks)
                                    {
                                        if (S1.id == P.stock)
                                        {
                                            money = money - (money * (S1.discount / 100));
                                            break;
                                        }
                                    }
                                }
                                if (P.cod == true) // если был введен промокод и этот промокод действует
                                {
                                    foreach (Bonus bonus in index.db.Bonus)
                                    {
                                        if (P.bonus == bonus.id)
                                        {
                                            money = money - (money * (bonus.discount / 100));
                                            break;
                                        }
                                    }
                                }
                                price += money;
                                checkedListBox1.Items.Add($"{P.name}   стоимость: {money} руб.");
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            label5.Text = $"Чек: {price} руб.";
        }

        private void iniz()
        {
            foreach (User U in index.db.Users)
            {
                if (U.id == index.user)
                {
                    maskedTextBox1.Text = U.phone;
                    textBox1.Text = U.name;
                    textBox2.Text = U.address;
                    textBox3.Text = U.password;
                    textBox4.Text = U.email;
                    break;
                }
            }
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

        // сбросить //
        private void button1_Click(object sender, EventArgs e)
        {
            iniz();
        }

        // сохранить //
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != ""
                && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" 
                && maskedTextBox1.MaskCompleted == true)
            {
                foreach (User U in index.db.Users)
                {
                    if (U.id == index.user)
                    {
                        U.name = textBox1.Text;
                        U.phone = maskedTextBox1.Text;
                        U.address = textBox2.Text;
                        U.password = textBox3.Text;
                        U.email = textBox4.Text;
                        break;
                    }
                }
                index.db.SaveChanges();
                MessageBox.Show("Персональные данные успешно изменены", "Внимание!");
                iniz();
            }
            else
                iniz();
        }

        // персональные данные //
        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            button6.Visible = false;
        }

        // корзина //
        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            button6.Visible = true;
        }

        // выход //
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        // выбрать все //
        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
            moneyBuy();
        }

        // подсчет стоимости //
        private void moneyBuy()
        {
            price = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string str = (string)checkedListBox1.Items[i];
                if (checkedListBox1.GetItemChecked(i))
                {
                    string[] words = str.Split(' ');
                    price += Convert.ToDouble(words[words.Length - 2]);
                }
            }
            if (checkBox2.Checked == true)
                price = price * 0.9;
            label5.Text = $"Чек: {price} руб.";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            moneyBuy();
        }
        
        // отказ от доставки //
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                price = price / 0.9;
                label5.Text = $"Чек: {price} руб.";
            }
            else
                moneyBuy();
        }

        // удалить выбранные //
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--)
            {
                string str = (string)checkedListBox1.Items[i];
                if (checkedListBox1.GetItemChecked(i))
                {
                    string[] words = str.Split(' ');
                    // удаляем из корзины в бд //
                    foreach (User U in index.db.Users)
                    {
                        if (U.id == index.user)
                        {
                            foreach (Buyer B in index.db.Buyers.Include(P => P.Products))
                            {
                                if (B.id == U.buyerId)
                                {
                                    foreach (Product P in B.Products)
                                    {
                                        double money = P.price;
                                        if (P.stock != 0)
                                        {
                                            foreach (Stock stock in index.db.Stocks)
                                            {
                                                if (stock.id == P.stock)
                                                {
                                                    money = money - (money * (stock.discount / 100));
                                                    break;
                                                }
                                            }
                                        }
                                        if (P.cod == true)
                                        {
                                            foreach (Bonus bonus in index.db.Bonus)
                                            {
                                                if (bonus.id == P.bonus)
                                                {
                                                    money = money - (money * (bonus.discount / 100));
                                                    break;
                                                }
                                            }
                                        }
                                        // нашли нужный из списка //
                                        string[] wor = P.name.Split(' ');
                                        if (words[0] == wor[0] && words[words.Length - 2] == money.ToString())
                                        {
                                            index.db.Products.Remove(P);
                                            price -= money;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    index.db.SaveChanges();
                    checkedListBox1.Items.RemoveAt(i);
                }
            }
            money();
            moneyBuy();
        }

        // оформить //
        private void button6_Click(object sender, EventArgs e)
        {
            int flag = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    flag = 1;
                    numProd++;
                }
            }
            if (flag == 1)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                button6.Visible = false;
                button8.Visible = false;
                button7.Visible = false;

                groupBox3.Visible = true;
                label6.Text = $"Сумма к оплате: {price} руб.";
            }
            else
                MessageBox.Show("Не выбран товар для покупки!", "Внимание!");

        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.ForeColor = Color.White;
            button10.BackColor = Color.DarkBlue;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.ForeColor = Color.White;
            button10.BackColor = Color.Peru;
        }

        private void maskedTextBox5_TextChanged(object sender, EventArgs e)
        {
            int flag = 0; // для определения, если ни одна из ниже карт, то убрать картинку
            // карта мир 2202 //
            if (maskedTextBox5.Text[0].ToString() == 2.ToString() && maskedTextBox5.Text[1].ToString() == 2.ToString()
                    && maskedTextBox5.Text[2].ToString() == 0.ToString() && maskedTextBox5.Text[3].ToString() == 2.ToString())
            {
                pictureBox1.BackgroundImage = Properties.Resources.mir1;
                flag = 1;
            }

            // карта виза 459 //
            if (maskedTextBox5.Text[0].ToString() == 4.ToString() && maskedTextBox5.Text[1].ToString() == 5.ToString()
                    && maskedTextBox5.Text[2].ToString() == 9.ToString())
            {
                pictureBox1.BackgroundImage = Properties.Resources.visa;
                flag = 1;
            }

            // карта мастеркард 54 //
            if (maskedTextBox5.Text[0].ToString() == 5.ToString() && maskedTextBox5.Text[1].ToString() == 4.ToString())
            {
                pictureBox1.BackgroundImage = Properties.Resources.mastercard;
                flag = 1;
            }

            // карта маестро 356 //
            if (maskedTextBox5.Text[0].ToString() == 3.ToString() && maskedTextBox5.Text[1].ToString() == 5.ToString()
                && maskedTextBox5.Text[2].ToString() == 6.ToString())
            {
                pictureBox1.BackgroundImage = Properties.Resources.maestro;
                flag = 1;
            }

            // ни одна из карт //
            if (flag == 0)
                pictureBox1.BackgroundImage = null;
        }

        // оплатить //
        private void button10_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.MaskCompleted == true && maskedTextBox3.MaskCompleted == true
                && maskedTextBox4.MaskCompleted == true && maskedTextBox5.MaskCompleted == true)
            {
                double finish = 0;
                DialogResult dialogResult = MessageBox.Show($"Желаете оплатить?\nСумма к оплате: {price} руб.", "Оплата", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    finish = price;
                    for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--)
                    {
                        string str = (string)checkedListBox1.Items[i];
                        if (checkedListBox1.GetItemChecked(i))
                        {
                            string[] words = str.Split(' ');
                            // удаляем из корзины в бд //
                            foreach (User U in index.db.Users)
                            {
                                if (U.id == index.user)
                                {
                                    foreach (Buyer B in index.db.Buyers.Include(P => P.Products))
                                    {
                                        if (B.id == U.buyerId)
                                        {
                                            foreach (Product P in B.Products)
                                            {
                                                double money = P.price;
                                                if (P.stock != 0)
                                                {
                                                    foreach (Stock stock in index.db.Stocks)
                                                    {
                                                        if (stock.id == P.stock)
                                                        {
                                                            money = money - (money * (stock.discount / 100));
                                                            break;
                                                        }
                                                    }
                                                }
                                                if (P.cod == true)
                                                {
                                                    foreach (Bonus bonus in index.db.Bonus)
                                                    {
                                                        if (bonus.id == P.bonus)
                                                        {
                                                            money = money - (money * (bonus.discount / 100));
                                                            break;
                                                        }
                                                    }
                                                }
                                                // нашли нужный из списка //
                                                string[] wor = P.name.Split(' ');
                                                if (words[0] == wor[0] && words[words.Length - 2] == money.ToString())
                                                {
                                                    //уменьшаем кол-во на складе продукт //
                                                    foreach (Product part in index.db.Products)
                                                    {
                                                        if (part.name == P.name && part.type == P.type && part.brend == P.brend)
                                                        {
                                                            part.number--;
                                                            break;
                                                        }
                                                    }
                                                    index.db.Products.Remove(P);
                                                    price -= money;
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            index.db.SaveChanges();
                            checkedListBox1.Items.RemoveAt(i);
                        }
                    }
                    money();
                    moneyBuy();
                }
                Purchases cheque = new Purchases()
                {
                    price = finish,
                    date = DateTime.Today,
                    delivery = checkBox2.Checked,
                };
                index.db.Purchases.Add(cheque);
                index.db.SaveChanges();
                foreach (User U in index.db.Users)
                {
                    if (U.id == index.user)
                    {
                        U.Purchases.Add(cheque);
                        break;
                    }
                }
                index.db.SaveChanges();
                string mess = $"Идентификатор чека: {cheque.id}\nДата покупки:{cheque.date.ToShortDateString()}";
                if (cheque.delivery == true)
                    mess += $"\nСумма к оплате: {finish} рублей\nне забудте предоставить чек при получении товара";
                else
                    mess += $"\nСумма к оплате: {finish} рублей\nЖелаем счастливого дня!";
                MessageBox.Show($"{mess}", "Внимание!");
            }
            else
                MessageBox.Show("Заполните все поля!", "Внимание!");
        }
    }
}