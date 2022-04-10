using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Kursach.Classes
{
    internal class DBConn
    {
        //Объявляем и инициализируем соединение
        public static readonly MySqlConnection conn = new MySqlConnection(ConnLine.connString);
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private static readonly MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private static BindingSource bSource;
        //Представляет одну таблицу данных в памяти.
        private static DataTable table;

        //Метод заполнения грида
        public static BindingSource GetListUsers(string commandStr)
        {
            table = new DataTable();
            bSource = new BindingSource();
            // устанавливаем соединение с БД
            conn.Open();
            //Объявляем команду, которая выполнит запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Закрываем соединение
            conn.Close();
            //Возвращаем bindingSource
            return bSource;
        }

        public static void ReloadList()
        {
            //Чистим виртуальную таблицу
            table.Clear();
        }

        //Метод удаления строк
        public static void DeleteUser(string request, string id)
        {
            //Формируем строку запроса на удаление строк
            string sql_delete = request + id + "'";
            //Посылаем запрос на обновление данных
            MySqlCommand delete = new MySqlCommand(sql_delete, conn);
            conn.Open();
            delete.ExecuteNonQuery();
            conn.Close();
        }

        //Метод добавления строк
        public static void NewRecord(string request)
        {
            //Формируем строку запроса на удаление строк
            string sql_new = request;
            //Посылаем запрос на обновление данных
            MySqlCommand newrec = new MySqlCommand(sql_new, conn);
            conn.Open();
            newrec.ExecuteNonQuery();
            conn.Close();
        }

        public static void Search(string request, string textBox)
        {
            bSource.Filter = request + textBox + "%'";
        }

        // Поиск по ID
        public static void Search(string textBox)
        {
            if (textBox != "")
            {
                bSource.Filter = "id =" + textBox;
            }
            else
            {
                bSource.Filter = "";
            }
        }
    }
}
