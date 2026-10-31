using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    public static class CryptographyHelper
    {

        private static readonly byte[] Key =
          Convert.FromBase64String("Q1k4fQqkzM1B5r3pTq8x1v4Y1+8ZzGd8vQyC0WzJ1n4=");

        private static readonly byte[] IV =
            Convert.FromBase64String("Y7YV4nM9Vg6d3FqP8y1k2A==");

        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] buffer = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
