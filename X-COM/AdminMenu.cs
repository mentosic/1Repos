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
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
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

        // управление товаром //
        private void button6_Click(object sender, EventArgs e)
        {
            EditData editData = new EditData();
            editData.ShowDialog();
        }

        // просмотр данных //
        private void button1_Click(object sender, EventArgs e)
        {
            LookInfoData look = new LookInfoData();
            look.ShowDialog();
        }
    }
}
