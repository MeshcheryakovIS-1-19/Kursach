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

        // строка подключения к БД
        string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
        //Переменная соединения
        MySqlConnection conn;
        //Логин и пароль к данной форме Вы сможете посмотреть в БД db_test таблице t_user

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Регистрация_Load(object sender, EventArgs e)
        {


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            м
        }
    }
}
