using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace Kursach
{
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        //Метод запроса данных пользователя по логину для запоминания их в полях класса
        public void GetUserInfo(string login)
        {
            // устанавливаем соединение с БД
            Classes.DBConn.conn.Open();
            // запрос
            var sql = $"SELECT * FROM Staff WHERE login='{login}'";
            // объект для выполнения SQL-запроса
            var command = new MySqlCommand(sql, Classes.DBConn.conn);
            // объект для чтения ответа сервера
            var reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Classes.Auth.auth_id = reader[2].ToString();
                Classes.Auth.auth_fio = reader[3].ToString();
                Classes.Auth.auth_doljnost = reader[4].ToString();
                Classes.Auth.auth_email = reader[5].ToString();
                
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            Classes.DBConn.conn.Close();
            Classes.Auth.auth = true;
        }


        private void Авторизация_Load(object sender, EventArgs e)
        {
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Регистрация Регистрация = new Регистрация();
            Регистрация.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Запрос в БД на предмет того, если ли строка с подходящим логином и паролем
            var sql = "SELECT * FROM Staff WHERE login = @un and  password= @up";
            //Открытие соединения
            Classes.DBConn.conn.Open();
            //Объявляем таблицу
            var table = new DataTable();
            //Объявляем адаптер
            var adapter = new MySqlDataAdapter();
            //Объявляем команду
            var command = new MySqlCommand(sql, Classes.DBConn.conn);
            //Определяем параметры
            command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
            //Присваиваем параметрам значение
            command.Parameters["@un"].Value = login.Text;
            command.Parameters["@up"].Value = Classes.Encryption.Sha256(password.Text);
            //Заносим команду в адаптер
            adapter.SelectCommand = command;
            //Заполняем таблицу
            adapter.Fill(table);
            //Закрываем соединение
            Classes.DBConn.conn.Close();
            //Если вернулась больше 0 строк, значит такой пользователь существует
            if (table.Rows.Count > 0)
            {
                //Присваеваем глобальный признак авторизации
                Classes.Auth.auth = true;
                //Достаем данные пользователя в случае успеха
                GetUserInfo(login.Text);
                Hide();
                Главное_меню ме = new Главное_меню();
                ме.ShowDialog();
            }
            else
            {
                //Отобразить сообщение о том, что авторизаия неуспешна
                MessageBox.Show("Неверные данные авторизации");
            }
            

        }

        private void Авторизация_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Classes.Auth.auth)
            {
                Environment.Exit(0);
            }
        }

    }
}
