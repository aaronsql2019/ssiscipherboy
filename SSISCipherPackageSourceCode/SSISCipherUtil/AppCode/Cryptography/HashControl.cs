using System;
using System.Collections.Generic;
using System.Text;

using System.Security;
using System.Security.Cryptography;

namespace SSISCipherUtil
{
    internal static class HashControl
    {
        public static byte[] GetSHA512ManagedHash(string inputString, string salt)
        {
            HashAlgorithm sha512Managed = new SHA512Managed();

            byte[] saltedInput = Utils.ConcatStringsToBytes(inputString, salt);

            return sha512Managed.ComputeHash(saltedInput);
        }

        public static byte[] GetSHA512ManagedHash(byte[] inputBytes, byte[] saltBytes)
        {
            HashAlgorithm sha512Managed = new SHA512Managed();

            byte[] saltedInput = Utils.ConcatByteArrarys(inputBytes, saltBytes);

            return sha512Managed.ComputeHash(saltedInput);
        }

        public static string GetSHA512ManagedHashAsBase64(string inputString, string salt)
        {
            HashAlgorithm sha512Managed = new SHA512Managed();

            byte[] saltedInput = Utils.ConcatStringsToBytes(inputString, salt);

            byte[] hashOutput = sha512Managed.ComputeHash(saltedInput);

            return Utils.BytesToBase64String(hashOutput);
        }

        public static string GetSHA512ManagedHashAsBase64(byte[] inputBytes, byte[] saltBytes)
        {
            HashAlgorithm sha512Managed = new SHA512Managed();

            byte[] saltedInput = Utils.ConcatByteArrarys(inputBytes, saltBytes);

            byte[] hashOutput = sha512Managed.ComputeHash(saltedInput);

            return Utils.BytesToBase64String(hashOutput);
        }

        public static byte[] DerivePasswordBytes(string inputString, byte[] salt, int returnBytesToGenerate)
        {
            Rfc2898DeriveBytes passwordDerivedBytes = new Rfc2898DeriveBytes(inputString, salt);
            return passwordDerivedBytes.GetBytes(returnBytesToGenerate);
        }
    }
}
