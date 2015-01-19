using System;
using System.Collections.Generic;

namespace HigLabo.Net.Pop3
{
    public class Pop3AuthenticateException : Exception
    {
        public Pop3AuthenticateException()
        {

        }
        public Pop3AuthenticateException(String message)
            : base(message)
        {
        }
    }
}
