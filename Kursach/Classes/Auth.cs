namespace Kursach.Classes

{
    //Класс необходимый для хранения состояния авторизации во время работы программы
    internal static class Auth
    {
        //Статичное поле, которое хранит значение статуса авторизации
        public static bool auth = false;
        //Статичное поле, которое хранит значения ID пользователя
        public static string auth_id = null;
        //Статичное поле, которое хранит значения ФИО пользователя
        public static string auth_fio = null;
        public static string auth_email = null;
        //Статичное поле, которое хранит количество привелегий пользователя
        public static string auth_doljnost = null;
        public static bool status = false;
    }
}
