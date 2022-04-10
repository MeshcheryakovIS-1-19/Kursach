using System;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Профиль : Form
    {
        public Профиль()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void Профиль_Load(object sender, EventArgs e)
        {
            label4.Text = Classes.Auth.auth_fio;
            label6.Text = Classes.Auth.auth_doljnost;
            label8.Text = Classes.Auth.auth_email;
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Главное_меню Главное_меню = new Главное_меню();
            Главное_меню.Show();
        }
    }
}
