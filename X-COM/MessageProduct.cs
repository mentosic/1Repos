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
    public partial class MessageProduct : Form
    {
        public static int id = 0;

        public MessageProduct(int idProduct)
        {
            InitializeComponent();
            id = idProduct;
            iniz();
        }

        // иницилизация формы //
        private void iniz()
        {
            panel1.Controls.Clear();

            int flag = 0;
            foreach (Product P in index.db.Products.Include(M => M.Messages))
            {
                if (P.id == id)
                {
                    label8.Text = $"Отзывы к {P.name} ";
                    int num = 0;
                    int score = 0;
                    foreach (Message M in P.Messages)
                        num++;

                    int i = 0;

                    Label[] infoMess = new Label[num];
                    Label[] nameMess = new Label[num];

                    // размеры //
                    int infoWidth = 500;
                    int infoHeight = 25;

                    int nameWidth = 735;
                    int nameHeight = 120;

                    // координаты на форме //
                    int infoX = 30;
                    int infoY = 20;

                    int nameX = 30;
                    int nameY = 50;
                    foreach (Message M in P.Messages)
                    {
                        flag = 1;
                        score += M.score;
                        if (num != 0)
                        {
                            infoMess[i] = new Label();
                            nameMess[i] = new Label();

                            nameMess[i] = new Label();
                            nameMess[i].ForeColor = Color.Black;
                            nameMess[i].BackColor = Color.White;
                            nameMess[i].Size = new Size(nameWidth, nameHeight);
                            nameMess[i].Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                            nameMess[i].TextAlign = ContentAlignment.TopLeft;
                            nameMess[i].Text = $"{M.text}";
                            // вывод объекта по следующим координатам //
                            nameMess[i].Location = new Point(nameX, nameY);
                            panel1.Controls.Add(nameMess[i]);
                            // переход к след координатам //
                            nameY += infoHeight + 160;

                            infoMess[i] = new Label();
                            infoMess[i].ForeColor = Color.Black;
                            infoMess[i].BackColor = Color.White;
                            infoMess[i].Size = new Size(infoWidth, infoHeight);
                            infoMess[i].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                            infoMess[i].TextAlign = ContentAlignment.TopLeft;
                            infoMess[i].Text = $"Имя: {M.name}    Дата: {M.date.ToShortDateString()}    Оценка: {M.score}/5";
                            // вывод объекта по следующим координатам //
                            infoMess[i].Location = new Point(infoX, infoY);
                            panel1.Controls.Add(infoMess[i]);
                            // переход к след координатам //
                            infoY += infoHeight + 160;

                            i++;
                        }
                    }
                    if (num != 0)
                        label8.Text += $"   Средняя оценка: {score / num}/5";
                    else
                        label8.Text += $"   Средняя оценка: не определена";
                    break;
                }
            }
            if (flag == 0)
            {
                Label error = new Label();
                error.ForeColor = Color.White;
                error.BackColor = this.BackColor;
                error.Size = new Size(600, 90);
                error.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Bold);
                error.TextAlign = ContentAlignment.TopCenter;
                error.Text = "Никто еще не оставил к данному товару:(";

                error.Location = new Point(100, 100);
                panel1.Controls.Add(error);
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

        // вернуться //
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        // оставить отзыв //
        private void button4_Click(object sender, EventArgs e)
        {
            if (index.user == 0)
            {
                UserInput _user = new UserInput();
                _user.ShowDialog();
                Close();
            }
            else
            {
                WriteMess writeMess = new WriteMess();
                writeMess.ShowDialog();
                iniz();
            }  
        }
    }
}
