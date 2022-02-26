using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Каталог : Form
    {
        public Каталог()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 Form4 = new Form4();
            Form4.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Hide();
            Для_детей Для_детей = new Для_детей();
            Для_детей.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 Form3 = new Form3();
            Form3.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 Form2 = new Form2();
            Form2.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Hide();
            Большие_размеры Большие_размеры = new Большие_размеры();
            Большие_размеры.Show();
        }
    }
}
