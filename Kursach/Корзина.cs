using System;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Корзина : Form
    {
        public Корзина()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Корзина_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Главное_меню Form4 = new Главное_меню();
            Form4.Show();
        }
    }
}
