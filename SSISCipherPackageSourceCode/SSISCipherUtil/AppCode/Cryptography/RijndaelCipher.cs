using System;
using System.Collections.Generic;
using System.Text;

using System.Security;
using System.Security.Cryptography;
using System.IO;

namespace SSISCipherUtil
{
    internal static class RijndaelCipher
    {
        /// <summary>
        /// Encrypts the input data and returns a base64 string representing the cipher bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string Encrypt(string data, byte[] key, byte[] iv)
        {
            string retVal = default(string);

            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.KeySize = 256;
                rijndaelManaged.BlockSize = 256;

                using (ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(key, iv))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(data);
                            }
                        }

                        retVal = Utils.BytesToBase64String(ms.ToArray());
                    }
                }
            }

            return retVal;
        }


        /// <summary>
        /// Decrypts the base 64 input string to the original plain text
        /// </summary>
        /// <param name="base64Cipher"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string Decrypt(string base64Cipher, byte[] key, byte[] iv)
        {
            string retVal = default(string);
            byte[] cipherBytes = Utils.Base64StringToBytes(base64Cipher);

            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.KeySize = 256;
                rijndaelManaged.BlockSize = 256;

                using (ICryptoTransform encryptor = rijndaelManaged.CreateDecryptor(key, iv))
                {
                    using (MemoryStream ms = new MemoryStream(cipherBytes))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                retVal = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }

            return retVal;
        }

    }
}
