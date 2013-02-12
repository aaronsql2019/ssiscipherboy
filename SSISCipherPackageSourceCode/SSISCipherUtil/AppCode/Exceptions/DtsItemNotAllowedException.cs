using System;
using System.Collections.Generic;
using System.Text;

namespace SSISCipherUtil
{
    public class DtsItemNotAllowedException : Exception
    {
        public DtsItemNotAllowedException() : base("It seems that you are trying to encrypt/decrypt/generate code for something other than the Value Property of Package level user variable, or a ConnetionManager item. This utility is supports encryption of a Package level user variable and ConnectionManager entries. That is anything other than \\Package.Variables[User::variableName].Properties[Value] or \\Package.Connections[connectionName].Properties[PropertyName] are not supported. Also this library is built to support only String encryption/decryption.") { }
         public DtsItemNotAllowedException(string message) : base(message) { }
    }
}
