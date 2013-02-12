using System;
using System.Collections.Generic;
using System.Text;

namespace SSISCipherUtil
{
    public class InvalidEncryptionProviderException : Exception
    {
        public InvalidEncryptionProviderException() : base("SSISCipherUtil supports DPAPI and RSA EncryptionProviders, the string passed in for decryption either uses some other unsupported EncryptionProvider, or it is not encrypted at all, or it does not have the encryption providers of the format [DPAPI] or [RSA]. Sample encrypted string for DPAPI is [DPAPI]AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA+aRsDCIBtk+yGF6dHRRJBwQAAAACAAAAAAADZgAAqAAAABAAAABhQStbO/0piM8KC6UaUE9+AAAAAASAAACgAAAAEAAAALShNm/qnZeHhzJvaw7KzFcQAAAAcpuMiLBQ3zgPopoIfM6FwxQAAAAOrk8IhkubNtvjhitAdm1rLfbNMQ==[DPAPI] and for RSA with key container named myrsakey1 is [RSA-myrsakey1]F7VW9qEJnmtYcj4GuhnsRPeEAv4yO/Ymt9RQQXtJxq0=[RSA-myrsakey1]") { }
        public InvalidEncryptionProviderException(string message) : base (message) { }
    }
}
