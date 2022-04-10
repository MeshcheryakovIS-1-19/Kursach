using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }
        bool IsValid(string line, string request)
        {
            return new Regex(@request).IsMatch(line);
        }
        //Формируем строку запроса на удаление строк

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IsValid(email.Text, @"^[\w\.\-]+@[\w\-]+\.[a-z]+$"))
            {
                string sql_new = ($"INSERT INTO Staff (fio, doljnost, email, login, password) " +
                                                 $"VALUES ('{fio.Text}','{doljnost.Text}','{email.Text}',@un,@up)");
                //Посылаем запрос на обновление данных
                MySqlCommand newrec = new MySqlCommand(sql_new, Classes.DBConn.conn);
                Classes.DBConn.conn.Open();
                newrec.Parameters.Add("@un", MySqlDbType.VarChar, 25);
                newrec.Parameters.Add("@up", MySqlDbType.VarChar, 25);
                //Присваиваем параметрам значение
                newrec.Parameters["@un"].Value = login.Text;
                newrec.Parameters["@up"].Value = Classes.Encryption.Sha256(password.Text);
                newrec.ExecuteNonQuery();
                Classes.DBConn.conn.Close();

                Hide();
                Авторизация Авторизация = new Авторизация();
                Авторизация.ShowDialog();
            }
            else
            {
                MessageBox.Show("Введите корректные данные почты, либо не верный повторный пароль");
            }
        }


        private void Регистрация_Load(object sender, EventArgs e)
        {

        }
    }
}
