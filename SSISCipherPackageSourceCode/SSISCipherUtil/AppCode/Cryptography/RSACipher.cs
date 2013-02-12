using System;
using System.Collections.Generic;
using System.Text;

using System.Security;
using System.Security.Cryptography;

namespace SSISCipherUtil
{
    internal static class RSACipher
    {
        public static void DeleteKeyFromRsaContainer(string containerName)
        {
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = containerName;
            cspParameters.Flags |= CspProviderFlags.UseMachineKeyStore;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters);

            rsa.PersistKeyInCsp = false;
            rsa.Clear();            
        }

        public static string ExportKeyAsXmlString(string containerName, bool includePrivateKeyInfo = true)
        {
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = containerName;
            cspParameters.Flags |= CspProviderFlags.UseMachineKeyStore;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters);
            return rsa.ToXmlString(includePrivateKeyInfo);
        }

        public static RSACryptoServiceProvider ImportKeyFromXmlString(string containerName, string xmlKeyString)
        {
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = containerName;
            cspParameters.Flags |= CspProviderFlags.UseMachineKeyStore;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters);
            rsa.FromXmlString(xmlKeyString);
            //rsa.PersistKeyInCsp = true;
            return rsa;
        }

        public static void QueryRsaKeyParameters(RSACryptoServiceProvider rsa, out byte[] modulus, out byte[] exponent)
        {
            RSAParameters rsaParameters = rsa.ExportParameters(true);
            modulus = rsaParameters.Modulus;
            exponent = rsaParameters.Exponent;
        }

        public static void QueryRsaKeyParameters(RSACryptoServiceProvider rsa, out byte[] d, out byte[] p, out byte[] q)
        {
            RSAParameters rsaParameters = rsa.ExportParameters(true);
            d = rsaParameters.D;
            p = rsaParameters.P;
            q = rsaParameters.Q;
        }

        public static void QueryRsaKeyParameters(RSACryptoServiceProvider rsa, out byte[] modulus, out byte[] exponent, out byte[] d, out byte[] p, out byte[] q)
        {
            RSAParameters rsaParameters = rsa.ExportParameters(true);
            modulus = rsaParameters.Modulus;
            exponent = rsaParameters.Exponent;
            d = rsaParameters.D;
            p = rsaParameters.P;
            q = rsaParameters.Q;
        }
    }
}
