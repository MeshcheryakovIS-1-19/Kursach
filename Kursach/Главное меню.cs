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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Профиль Профиль = new Профиль();
            Профиль.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Каталог Каталог = new Каталог();
            Каталог.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Hide();
            Корзина Корзина = new Корзина();
            Корзина.ShowDialog();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Hide();
            Заказ Заказ = new Заказ();
            Заказ.ShowDialog();
        }
    }
}
