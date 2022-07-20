using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SQICS_Api.Helper.Password
{
    public static class PasswordManager
    {
        const int SALT_SIZE = 24;

        public static string GetHash(string password, string salt)
        {
            var hashedPassword = HashSha512(password, salt);

            return hashedPassword;
        }

        public static string GenerateSalt()
        {
            var buff = new byte[SALT_SIZE];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buff);
            }
            return Convert.ToBase64String(buff);
        }

        static string HashSha512(string rawData, string salt)
        {
            // Create a SHA256. SHA = Secure Hash Algorithm.
            using (var sha512Hash = SHA512.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData + salt));

                // Convert byte array to a string
                var builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString().ToUpper();
            }
        }
    }
}
