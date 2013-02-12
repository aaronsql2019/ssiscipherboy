using System;
using System.Collections.Generic;
using System.Text;

namespace SSISCipherUtil
{
    public class DataTypeNotAllowedException : Exception
    {
        public DataTypeNotAllowedException() : base("It seems that you are trying to encrypt/decrypt/generate code for a data type that is not recommended for this operation. This library is built to support only String encryption/decryption. Expect other data type encryption in future versions. Anything other than String is not supported for encryption/decryption. Unsupported data types include Object, Boolean, DBNull, Char, Byte, SByte, Int32, Int64, UInt32, UInt64, Single, Double, DateTime.") { }
        public DataTypeNotAllowedException(string message) : base(message) { }
    }
}
