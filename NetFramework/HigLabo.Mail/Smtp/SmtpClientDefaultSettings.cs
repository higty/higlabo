using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpClientDefaultSettings : SocketClientDefaultSettings
    {
        public Int32 SslPort { get; set; }
        public String HostName { get; set; }
        public SmtpAuthenticateMode AuthenticateMode { get; set; }
        public SmtpEncryptedCommunication EncryptedCommunication { get; set; }
        public SmtpClientDefaultSettings()
        {
            this.Port = 25;
            this.SslPort = 443;
            this.HostName = "localhost";
            this.AuthenticateMode = SmtpAuthenticateMode.Auto;
            this.EncryptedCommunication = SmtpEncryptedCommunication.None;
        }
    }
}
