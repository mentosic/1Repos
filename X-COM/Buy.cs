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
    public partial class Buy : Form
    {
        public static int idProduct = 0;
        public static double money = 0;
        double promoCode = 0;

        public Buy(int id)
        {
            InitializeComponent();
            idProduct = id;
            iniz();
            button4.Enabled = false;
        }

        private void iniz()
        {
            money = 0;
            foreach (Product P in index.db.Products)
            {
                if (P.id == idProduct)
                {
                    if (P.stock != 0)
                    {
                        foreach (Stock S in index.db.Stocks)
                        {
                            if (S.id == P.stock)
                            {
                                money = P.price - (P.price * (S.discount/100));
                                break;
                            }
                        }
                    }
                    else
                        money = P.price;

                    if (promoCode != 0)
                        money -= money * promoCode;

                    label1.Text = $"Цена: {money* (int)numericUpDown1.Value} руб.";
                    numericUpDown1.Maximum = P.number;
                    break;
                }
            }
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

        // вернуться //
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        // промокод //
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                foreach (Product P in index.db.Products)
                {
                    if (P.id == idProduct)
                    {
                        if (P.bonus != 0)
                        {
                            foreach (Bonus B in index.db.Bonus)
                            {
                                if (B.id == P.bonus)
                                {
                                    promoCode = B.discount / 100;
                                    button4.Enabled = true;
                                    button1.Enabled = false;
                                    break;
                                }    
                            }
                        }    
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Введите промокод", "Внимание!");

            iniz();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            button4.Enabled = false;
            button1.Enabled = true;
            promoCode = 0;
            iniz();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            iniz();
        }

        // продолжить //
        private void button3_Click(object sender, EventArgs e)
        {
            createBuy();
            DialogResult dialogResult = MessageBox.Show("Желаете перейти в профиль для последующей покупки?", 
                "Подтверждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ProfileAndBuyer profileAndBuyer = new ProfileAndBuyer();
                profileAndBuyer.ShowDialog();
                Close();
            }
            else
                Close();
        }

        // закидываем товар в корзину //
        private void createBuy()
        {
            for (int i = 0; i < (int)numericUpDown1.Value; i++)
            {
                foreach (User U in index.db.Users)
                {
                    if (U.id == index.user)
                    {
                        foreach (Buyer B in index.db.Buyers)
                        {
                            if (B.id == U.buyerId)
                            {
                                foreach (Product P in index.db.Products)
                                {
                                    if (P.id == idProduct)
                                    {
                                        Product product = new Product()
                                        {
                                            name = P.name,
                                            type = P.type,
                                            brend = P.brend,
                                            price = P.price,
                                            number = P.number,
                                            bonus = P.bonus,
                                            stock = P.stock,
                                            copy = true,
                                            cod = false,
                                            path = "",

                                        };
                                        if (promoCode != 0)
                                            product.cod = true;
                                        else
                                            product.cod = false;
                                        index.db.Products.Add(product);
                                        B.Products.Add(product);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            index.db.SaveChanges();
            MessageBox.Show("Товар успешно добавлен в Вашу корзину", "Внимание!");
        }
    }
}