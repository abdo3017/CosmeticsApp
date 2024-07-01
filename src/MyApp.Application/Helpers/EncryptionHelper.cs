using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Helpers
{
    public static class EncryptionHelper
    {
       public static string DecryptAES(string encreptedValue)
        {
            string keyString = "13313586896631234900207000800912"; //replace with your key
            string ivString = "6896631234900212"; //replace with your iv
            byte[] key = Encoding.ASCII.GetBytes(keyString);
            byte[] iv = Encoding.ASCII.GetBytes(ivString);

            using (var rijndaelManaged =
                    new RijndaelManaged { Key = key, IV = iv, Mode = CipherMode.CBC })
            {
                rijndaelManaged.BlockSize = 128;
                rijndaelManaged.KeySize = 256;
                Span<byte> buffer = new Span<byte>(new byte[encreptedValue.Length]);
                bool x = Convert.TryFromBase64String(encreptedValue, buffer, out int bytesParsed);
                if (x)
                {
                    using (var memoryStream =
                      new MemoryStream(Convert.FromBase64String(encreptedValue)))
                    using (var cryptoStream =
                           new CryptoStream(memoryStream,
                               rijndaelManaged.CreateDecryptor(key, iv),
                               CryptoStreamMode.Read))
                    {
                        return new StreamReader(cryptoStream).ReadToEnd();
                    }
                }
                return encreptedValue;
            }
        }

        public static Aes GenerateSymmetricKey()
        {
            Aes aes = Aes.Create();
            aes.KeySize = 256; // 256-bit key for AES
            string keyString = "13313586896631234900207000800912"; //replace with your key
            string ivString = "6896631234900212"; //replace with your iv
            byte[] key = Encoding.ASCII.GetBytes(keyString);
            byte[] iv = Encoding.ASCII.GetBytes(ivString);
            aes.Key = key;
            aes.IV = iv;
            return aes;
        }

        public static byte[] EncryptData(Aes aes, string data)
        {
            byte[] encrypted;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(data);
                    }
                    encrypted = ms.ToArray();
                }
            }
            return encrypted;
        }

        public static string DecryptData(Aes aes, byte[] encryptedData)
        {
            string decrypted;
            using (MemoryStream ms = new MemoryStream(encryptedData))
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        decrypted = sr.ReadToEnd();
                    }
                }
            }
            return decrypted;
        }

    }
}
