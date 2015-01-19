using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    public class ImapAuthenticateException : Exception
    {
        public ImapAuthenticateException()
        {

        }
        public ImapAuthenticateException(String message)
            : base(message)
        {

        }
    }
}
