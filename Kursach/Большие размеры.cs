﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Большие_размеры : Form
    {
        public Большие_размеры()
        {
            InitializeComponent();
        }
        public static string request = "SELECT id2 AS 'Код товара', name2 AS 'Наименование товара', number_tovar2 AS 'Номер товара', price2 AS 'Цена товара', kolichestvo2 AS 'Количество тоавара' FROM big_size ";
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содержит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        public static string id_selected_rows = "0"; 







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
       


        private void Большие_размеры_Load(object sender, EventArgs e)
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
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;
            }
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
            string sql_update_current_stud = $"INSERT INTO big_size (name2, number_tovar2, price2, kolichestvo2) " +
                                           $"VALUES ('{naimenovanie.Text}', '{nomerTovara.Text}', '{price.Text}', '{kolichestvo.Text}')";
            Classes.DBConn.NewRecord(sql_update_current_stud);

            Reload();

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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Classes.DBConn.DeleteUser("DELETE FROM bid_size WHERE id2='", id_selected_rows);
            Reload();
        }
    }

}
