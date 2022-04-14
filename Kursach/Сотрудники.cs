using MySql.Data.MySqlClient;
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
    public partial class Сотрудники : Form
    {
        public Сотрудники()
        {
            InitializeComponent();
        }
        public static string request = "SELECT id2 AS 'Код сотрудника', email2 AS 'Емайл сотрудника ', telephone AS 'Номер телефона', doljnost AS 'Должность', fio2 AS 'ФИО сотрудника' FROM sotrydniki";
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содержит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        public static string id_selected_rows = "0";


        private void Сотрудники_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Classes.DBConn.GetListUsers(request);
            //Видимость полей в гриде
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Visible = true;
            }
            //Ширина полей
            dataGridView1.Columns[0].FillWeight = 30;
            dataGridView1.Columns[1].FillWeight = 30;
            dataGridView1.Columns[2].FillWeight = 30;
            dataGridView1.Columns[3].FillWeight = 30;
            dataGridView1.Columns[4].FillWeight = 30;
            //Режим для полей "Только для чтения"


            //Растягивание полей грида
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            //Убираем заголовки строк
            dataGridView1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            dataGridView1.ColumnHeadersVisible = true;
        }
        public void Reload()
        {
            //Чистим виртуальную таблицу внутри класса
            Classes.DBConn.ReloadList();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            dataGridView1.DataSource = Classes.DBConn.GetListUsers(request);
        }
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string sql_update_current_stud = $"INSERT INTO sotrydniki (email2, telephone, doljnost, fio2) " +
                                           $"VALUES ('{naimenovanie.Text}', '{nomerTovara.Text}', '{price.Text}', '{kolichestvo.Text}')";
            Classes.DBConn.NewRecord(sql_update_current_stud);

            Reload();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Classes.DBConn.DeleteUser("DELETE FROM sotrydniki WHERE id2='", id_selected_rows);
            Reload();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Главное_меню Главное_меню = new Главное_меню();
            Главное_меню.Show();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                //dataGridView1.CurrentRow.Selected = true;
                dataGridView1.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && dataGridView1.CurrentCell != null)
            {
                //Магические строки
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // устанавливаем соединение с БД
            Classes.DBConn.conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE sotrydniki SET email2='{dataGridView1[1, dataGridView1.CurrentRow.Index].Value}', telephone='{dataGridView1[2, dataGridView1.CurrentRow.Index].Value}', doljnost='{dataGridView1[3, dataGridView1.CurrentRow.Index].Value}', fio2='{dataGridView1[4, dataGridView1.CurrentRow.Index].Value}' WHERE id2='{dataGridView1.Rows[Convert.ToInt32(dataGridView1.SelectedCells[0].RowIndex.ToString())].Cells[0].Value}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, Classes.DBConn.conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            Classes.DBConn.conn.Close();
            Reload();
        }
    }
}
