using System.Security.Cryptography;
using System.Text;

namespace Kursach.Classes
{
    internal class Encryption
    {
        //Логин и пароль к данной форме Вы сможете посмотреть в БД
        //Вычисление хэша строки и возрат его из метода
        public static string Sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (var theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
