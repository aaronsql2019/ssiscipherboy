using System;
using System.Collections.Generic;
using System.Text;


namespace SSISCipherUtil
{
    public static class SSISInterceptor
    {
        private static string GetRsaKeyContainerName(string nodeValue)
        {
            if (nodeValue.IndexOf("[RSA", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                int startPos = nodeValue.IndexOf('-') + 1;
                int endPos = nodeValue.IndexOf(']');
                int subStringLength = endPos - startPos;

                return nodeValue.Substring(startPos, subStringLength);
            }
            else
            {
                throw new InvalidOperationException("This method expects the EncryptionProvider to be RSA. Either the node value is corrupted or the ecnryption provider was something else.");
            }
        }

        private static EncryptionProvider GetEncryptionProvider(string nodeValue)
        {
            if (nodeValue.IndexOf("[DPAPI]", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                return EncryptionProvider.DPAPI;
            }
            else if (nodeValue.IndexOf("[RSA", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                return EncryptionProvider.RSA;
            }
            else
            {
                throw new InvalidEncryptionProviderException();
            }
        }

        public static string GetEncryptedText(string nodeValue)
        {
            string retVal = default(string);

            int beginTagStartPos = nodeValue.IndexOf('[');
            int beginTagEndPos = nodeValue.IndexOf(']', beginTagStartPos);

            int endTagStartPos = nodeValue.IndexOf('[', beginTagEndPos);
            int endTagEndPos = nodeValue.IndexOf(']', beginTagEndPos);

            int subStringLength = (endTagStartPos) - (beginTagEndPos + 1) ;
            retVal = nodeValue.Substring((beginTagEndPos + 1), subStringLength);

            return retVal;
        }

        public static string Encrypt(string input, EncryptionProvider provider, string keyContainerName)
        {
            string retVal = default(string);

            switch (provider)
            {
                case EncryptionProvider.DPAPI:
                    {
                        retVal = CipherEngine.Encrypt(input, provider, "");
                        retVal = string.Format("[DPAPI]{0}[DPAPI]", retVal);
                        break;
                    }
                case EncryptionProvider.RSA:
                    {
                        retVal = CipherEngine.Encrypt(input, provider, keyContainerName);
                        retVal = string.Format("[RSA-{0}]{1}[RSA-{0}]", keyContainerName, retVal);
                        break;
                    }
            }

            return retVal;
        }

        public static string Decrypt(string input)
        {
            string retVal = default(string);
            EncryptionProvider provider = GetEncryptionProvider(input);
            string cipherData = GetEncryptedText(input);

            switch (provider)
            {
                case EncryptionProvider.DPAPI:
                    {
                        retVal = CipherEngine.Decrypt(cipherData, provider, "");
                        break;
                    }
                case EncryptionProvider.RSA:
                    {
                        string keyContainerName = GetRsaKeyContainerName(input);
                        retVal = CipherEngine.Decrypt(cipherData, provider, keyContainerName);
                        break;
                    }
            }

            return retVal;
        }

        public static void ExportKeyAsXmlFile(string filePath, string containerName, bool includePrivateKeyInfo = true)
        {
            string xmlKey = RSACipher.ExportKeyAsXmlString(containerName, true);
            Utils.WriteStringToFile(xmlKey, filePath);
        }

        public static void ImportKeyFromXmlFile(string filePath, string containerName)
        {
            string xmlKey = Utils.ReadStringFromFile(filePath);
            RSACipher.ImportKeyFromXmlString(containerName, xmlKey);
        }
    }
}
