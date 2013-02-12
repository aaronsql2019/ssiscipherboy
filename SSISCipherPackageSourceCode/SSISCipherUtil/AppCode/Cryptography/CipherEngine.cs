using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace SSISCipherUtil
{
    internal static class CipherEngine
    {
        public static string Encrypt(string data, EncryptionProvider encryptionProvider, string containerName)
        {
            string retVal = default(string);
            switch (encryptionProvider)
            {
                case EncryptionProvider.DPAPI:
                    {
                        byte[] entropy = GetEntropy();
                        retVal = DPAPI.Encrypt(data, entropy);
                        break;
                    }
                case EncryptionProvider.RSA:
                    {
                        if (string.IsNullOrEmpty(containerName))
                        {
                            throw new ArgumentException("containerName is mandatory when using RSA EncryptionProvider");
                        }

                        byte[] key = GetKey(containerName);
                        byte[] iv = GetIV(containerName);

                        Console.WriteLine(Utils.BytesToBase64String(key));
                        Console.WriteLine(Utils.BytesToBase64String(iv));

                        retVal = RijndaelCipher.Encrypt(data, key, iv);
                        break;
                    }
            }
            return retVal;
        }

        public static string Decrypt(string cipherData, EncryptionProvider encryptionProvider, string containerName)
        {
            string retVal = default(string);
            switch (encryptionProvider)
            {
                case EncryptionProvider.DPAPI:
                    {
                        byte[] entropy = GetEntropy();
                        retVal = DPAPI.Decrypt(cipherData, entropy);
                        break;
                    }
                case EncryptionProvider.RSA:
                    {
                        if (string.IsNullOrEmpty(containerName))
                        {
                            throw new ArgumentException("containerName is mandatory when using RSA EncryptionProvider");
                        }

                        byte[] key = GetKey(containerName);
                        byte[] iv = GetIV(containerName);

                        Console.WriteLine(Utils.BytesToBase64String(key));
                        Console.WriteLine(Utils.BytesToBase64String(iv));

                        retVal = RijndaelCipher.Decrypt(cipherData, key, iv);
                        break;
                    }
            }
            return retVal;
        }

        private static byte[] GetEntropy()
        {
            byte[] h1 = HashControl.GetSHA512ManagedHash(Constants.CONST1, Constants.CONST6);
            byte[] h2 = HashControl.GetSHA512ManagedHash(Constants.CONST2, Constants.CONST5);
            byte[] h3 = HashControl.GetSHA512ManagedHash(Constants.CONST3, Constants.CONST4);

            byte[] retVal;

            byte[] salt = Utils.ConcatByteArrarys(h1, h2);
            string base64edSalt = Utils.BytesToBase64String(salt);

            retVal = HashControl.DerivePasswordBytes(base64edSalt, h3, 1024);

            return retVal;            
        }
         
        private static byte[] GetKey(string containerName)
        {
            byte[] d, p, q = null;
            byte[] s = Utils.StringToUTF8Bytes(Constants.CONST1);

            string xmlKey = RSACipher.ExportKeyAsXmlString(containerName);
            RSACryptoServiceProvider rsa = RSACipher.ImportKeyFromXmlString(containerName, xmlKey);
            RSACipher.QueryRsaKeyParameters(rsa, out d, out p, out q);

            byte[] h1 = HashControl.GetSHA512ManagedHash(d, p);
            byte[] h2 = HashControl.GetSHA512ManagedHash(q, s);

            string h1Base64 = Utils.BytesToBase64String(h1);

            return HashControl.DerivePasswordBytes(h1Base64, h2, 32);
        }

        private static byte[] GetIV(string containerName)
        {
            byte[] e, m = null;
            byte[] s = Utils.StringToUTF8Bytes(Constants.CONST2);

            string xmlKey = RSACipher.ExportKeyAsXmlString(containerName);
            RSACryptoServiceProvider rsa = RSACipher.ImportKeyFromXmlString(containerName, xmlKey);
            RSACipher.QueryRsaKeyParameters(rsa, out m, out e);

            byte[] h3 = HashControl.GetSHA512ManagedHash(m, e);
            string h3Base64 = Utils.BytesToBase64String(h3);

            return HashControl.DerivePasswordBytes(h3Base64, h3, 32);            
        }

        public static string ExportKeyAsXmlString(string containerName, bool includePrivateKeyInfo = true)
        {
            return RSACipher.ExportKeyAsXmlString(containerName, includePrivateKeyInfo);
        }

        public static RSACryptoServiceProvider ImportKeyFromXmlString(string containerName, string xmlKeyString)
        {
            return RSACipher.ImportKeyFromXmlString(containerName, xmlKeyString);
        }
    }
}
