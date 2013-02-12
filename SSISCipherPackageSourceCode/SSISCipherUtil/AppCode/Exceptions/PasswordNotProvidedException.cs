using System;
using System.Collections.Generic;
using System.Text;

namespace SSISCipherUtil
{
    public class PasswordNotProvidedException : Exception
    {
        public PasswordNotProvidedException() : base("Seems like the package is protected with Password. Cannot load or save the package untill the password is provided, or the provided password is incorrect.") { }
        public PasswordNotProvidedException(string message) : base(message) { }
    }
}
