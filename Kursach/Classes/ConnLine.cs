namespace Kursach.Classes
{
    internal class ConnLine
    {
        #region строка подключения
        //Определяем параметры подключения
        private const string host = "chuc.caseum.ru";
        private const string port = "33333";
        private const string database = "is_1_19_st12_KURS";
        private const string username = "st_1_19_12";
        private const string password = "57856941";
        //Формируем строку подключения
        public static string connString = $"server={host};port={port};user={username};database={database};password={password};";
        #endregion
    }
}
