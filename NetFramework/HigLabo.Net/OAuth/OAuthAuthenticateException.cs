using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    public class OAuthAuthenticateException : Exception
    {
        public String BodyText { get; set; }

        public OAuthAuthenticateException(String bodyText, String message)
            : base(message)
        {
            this.BodyText = bodyText;
        }
    }
}
