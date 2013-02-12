using System;
using System.Collections.Generic;
using System.Text;

using System.Security;
using System.Security.Cryptography;

namespace SSISCipherUtil
{
    internal static class DPAPI
    {
        /// <summary>
        /// Encrypts the string data using DPAPI and returns the base 64 string representation of cipher bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="entrophy"></param>
        /// <param name="dataProtectionScope"></param>
        /// <returns></returns>
        public static string Encrypt(string data, byte[] entropy, DataProtectionScope dataProtectionScope = DataProtectionScope.LocalMachine)
        {
            byte[] inputBytes = Utils.StringToUTF8Bytes(data);

            byte[] retVal = ProtectedData.Protect(inputBytes, entropy, dataProtectionScope);

            return Utils.BytesToBase64String(retVal);
        }


        /// <summary>
        /// Decrypts the base 64 string encrypted using DPAPI to original plain text
        /// </summary>
        /// <param name="base64String"></param>
        /// <param name="entrophy"></param>
        /// <param name="dataProtectionScope"></param>
        /// <returns></returns>
        public static string Decrypt(string base64String, byte[] entropy, DataProtectionScope dataProtectionScope = DataProtectionScope.LocalMachine)
        {
            byte[] inputBytes = Utils.Base64StringToBytes(base64String);

            byte[] retVal = ProtectedData.Unprotect(inputBytes, entropy, dataProtectionScope);

            return Utils.UTF8BytesToString(retVal);
        }
    }
}
