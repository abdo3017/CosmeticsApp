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
       public static string DecryptAES(string AuthorizationCode)
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
                Span<byte> buffer = new Span<byte>(new byte[AuthorizationCode.Length]);
                bool x = Convert.TryFromBase64String(AuthorizationCode, buffer, out int bytesParsed);
                if (x)
                {
                    using (var memoryStream =
                      new MemoryStream(Convert.FromBase64String(AuthorizationCode)))
                    using (var cryptoStream =
                           new CryptoStream(memoryStream,
                               rijndaelManaged.CreateDecryptor(key, iv),
                               CryptoStreamMode.Read))
                    {
                        return new StreamReader(cryptoStream).ReadToEnd();
                    }
                }
                return AuthorizationCode;
            }
        }
    }
}
