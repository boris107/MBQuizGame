using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            // Генерация соли (16 байт = 128 бит)
            byte[] salt = new byte[16];
            
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Хеширование пароля с PBKDF2 (HMACSHA256)
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 25000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32 байта (256 бит)
                byte[] hashBytes = new byte[48];

                // Объединяем соль и хеш
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 32);

                // Возвращаем в виде base64
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
