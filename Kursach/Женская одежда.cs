using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        



        private void Form3_Load(object sender, EventArgs e)
        {
         
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Каталог Каталог = new Каталог();
            Каталог.Show();
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
        public void GetSelectedIDString()
        {
            

        }
        //Метод обновления DataGreed
        public void re
        load_list()
        {

            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            dataGridView1.DataSource = Classes.DBConn.GetListUsers("SELECT id AS 'Код', fio AS 'ФИО', age AS 'Возраст', " +
                "theme_kurs AS 'Тема курсовой', id_state AS 'Статус' FROM t_stud");

        }
    }
}
