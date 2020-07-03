using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpAuthenticateException : Exception
    {
        public SmtpAuthenticateException()
        {

        }
        public SmtpAuthenticateException(String message)
            : base(message)
        {

        }
    }
}
