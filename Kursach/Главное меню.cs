using System;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Главное_меню : Form
    {
        public Главное_меню()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hide();
            Профиль Профиль = new Профиль();
            Профиль.ShowDialog();
        }

        public static Главное_меню главное_Меню = new Главное_меню();

        private void Form4_Load(object sender, EventArgs e)
        {
            // Если авторизации была успешна и в поле класса хранится истина, то делаем движуху:
            if (Classes.Auth.auth)
            {
                // Отображаем рабочую форму
                Show();
            }
            // иначе
            else
            {
                // Закрываем форму
                Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Большие_размеры Большие_размеры = new Большие_размеры();
            Большие_размеры.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Hide();
            Для_детей Для_детей = new Для_детей();
            Для_детей.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 Form2 = new Form2();
            Form2.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 Form3 = new Form3();
            Form3.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Hide();
            Сотрудники Сотрудники = new Сотрудники();
            Сотрудники.Show();
        }
    }
}
