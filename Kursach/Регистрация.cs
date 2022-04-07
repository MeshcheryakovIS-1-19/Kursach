using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kursach
{
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Classes.DBConn.NewRecord($"INSERT INTO Staff (Login, Password) " +
                                             $"VALUES ('{guna2TextBox1.Text}','{Classes.Encryption.Sha256(guna2TextBox2.Text)}')");
            Hide();
            Form4 Form4 = new Form4();
            Form4.ShowDialog();
        }
    }
}
