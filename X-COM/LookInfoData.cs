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
    public partial class LookInfoData : Form
    {
        public LookInfoData()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;
            client();
            mess();
            pur();
        }

        private void pur()
        {
            // чистим таблицу от предыдущего содержимого //
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();

            // выравниваем все ячейки в заголовке по центру //
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // добавляем столбцы //
            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();
            var column4 = new DataGridViewTextBoxColumn();

            // параметры столбцов //
            column1.HeaderText = "Id покупки";
            column1.Name = "Column1";
            column2.HeaderText = "Стоимость покупки";
            column2.Name = "Column2";
            column3.HeaderText = "Дата покупки";
            column3.Name = "Column3";
            column4.HeaderText = "Доставка";
            column4.Name = "Column4";


            // Добавляем созданные столбцы в таблицу //
            this.dataGridView3.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4 });

            // указываем ширину стобцов //
            dataGridView3.Columns[0].Width = 100;
            dataGridView3.Columns[1].Width = 170;
            dataGridView3.Columns[2].Width = 150;
            dataGridView3.Columns[3].Width = 150;

            // для того, чтобы был виден весь текст
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            int i = 0;
            foreach (Purchases P in index.db.Purchases)
            {
                dataGridView3.Rows.Add(); // добавляем новую строку

                // вставляем данные в ячейки строки //
                dataGridView3.Rows[i].Cells[0].Value = Convert.ToString(P.id);
                dataGridView3.Rows[i].Cells[1].Value = P.price.ToString();
                dataGridView3.Rows[i].Cells[2].Value = P.date.ToShortDateString();
                dataGridView3.Rows[i].Cells[3].Value = P.delivery.ToString();

                i++;
            }
        }

        private void mess()
        {
            // чистим таблицу от предыдущего содержимого //
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            // выравниваем все ячейки в заголовке по центру //
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // добавляем столбцы //
            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();
            var column4 = new DataGridViewTextBoxColumn();
            var column5 = new DataGridViewTextBoxColumn();
            var column6 = new DataGridViewTextBoxColumn();

            // параметры столбцов //
            column1.HeaderText = "Id отзыва";
            column1.Name = "Column1";
            column2.HeaderText = "Имя клиента";
            column2.Name = "Column2";
            column3.HeaderText = "Текст отзыва";
            column3.Name = "Column3";
            column4.HeaderText = "Дата отзыва";
            column4.Name = "Column4";
            column5.HeaderText = "Оценка";
            column5.Name = "Column5";
            column6.HeaderText = "id продукта";
            column6.Name = "Column6";


            // Добавляем созданные столбцы в таблицу //
            this.dataGridView2.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4, column5,
                column6 });

            // указываем ширину стобцов //
            dataGridView2.Columns[0].Width = 100;
            dataGridView2.Columns[1].Width = 170;
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Width = 170;

            // для того, чтобы был виден весь текст
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            int i = 0;
            foreach (Product P in index.db.Products.Include(M=>M.Messages))
            {
                foreach (Message M in P.Messages)
                {
                    dataGridView2.Rows.Add(); // добавляем новую строку

                    // вставляем данные в ячейки строки //
                    dataGridView2.Rows[i].Cells[0].Value = Convert.ToString(M.id);
                    dataGridView2.Rows[i].Cells[1].Value = M.name.ToString();
                    dataGridView2.Rows[i].Cells[2].Value = M.text;
                    dataGridView2.Rows[i].Cells[3].Value = M.date.ToShortDateString();
                    dataGridView2.Rows[i].Cells[4].Value = M.score.ToString();
                    dataGridView2.Rows[i].Cells[5].Value = P.id.ToString();

                    i++;
                }
            }
        }

        private void client()
        {
            // чистим таблицу от предыдущего содержимого //
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // выравниваем все ячейки в заголовке по центру //
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // добавляем столбцы //
            var column1 = new DataGridViewTextBoxColumn();
            var column2 = new DataGridViewTextBoxColumn();
            var column3 = new DataGridViewTextBoxColumn();
            var column4 = new DataGridViewTextBoxColumn();
            var column5 = new DataGridViewTextBoxColumn();
            var column6 = new DataGridViewTextBoxColumn();
            var column7 = new DataGridViewTextBoxColumn();

            // параметры столбцов //
            column1.HeaderText = "Id клиента";
            column1.Name = "Column1";
            column2.HeaderText = "Имя клиента";
            column2.Name = "Column2";
            column3.HeaderText = "Телефон";
            column3.Name = "Column3";
            column4.HeaderText = "Адрес для доставки";
            column4.Name = "Column4";
            column5.HeaderText = "Пароль от аккаунта";
            column5.Name = "Column5";
            column6.HeaderText = "Эл.почта";
            column6.Name = "Column6";
            column7.HeaderText = "Количество покупок";
            column7.Name = "Column7";

            // Добавляем созданные столбцы в таблицу //
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column1, column2, column3, column4, column5,
                column6, column7});

            // указываем ширину стобцов //
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 170;

            // для того, чтобы был виден весь текст
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            int i = 0;
            foreach (User U in index.db.Users.Include(P => P.Purchases))
            {
                dataGridView1.Rows.Add(); // добавляем новую строку

                // вставляем данные в ячейки строки //
                dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(U.id);
                dataGridView1.Rows[i].Cells[1].Value = U.name.ToString();
                dataGridView1.Rows[i].Cells[2].Value = U.phone;
                dataGridView1.Rows[i].Cells[3].Value = U.address.ToString();
                dataGridView1.Rows[i].Cells[4].Value = U.password.ToString();
                dataGridView1.Rows[i].Cells[5].Value = U.email.ToString();
                int num = 0;
                foreach (Purchases purchases in U.Purchases)
                    num++;
                dataGridView1.Rows[i].Cells[6].Value = num.ToString();
                i++;
            }  
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

        // выход //
        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
