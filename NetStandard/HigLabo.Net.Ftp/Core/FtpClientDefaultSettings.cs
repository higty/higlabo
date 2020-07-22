using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Ftp
{
    public class FtpClientDefaultSettings : SocketClientDefaultSettings
    {
        public FtpConnectionMode ConnectionMode { get; set; }
        public FtpDataType DataType { get; set; }
        public Boolean Resume { get; set; }
        public Func<String, FtpDirectory> CreateFtpDirectory { get; set; }
        public FtpClientDefaultSettings()
        {
            this.Port = 21;
            this.ConnectionMode = FtpConnectionMode.Passive;
            this.DataType = FtpDataType.Ascii;
            this.Resume = true;
            this.CreateFtpDirectory = DefaultCreateFtpDirectory;
        }
        private static FtpDirectory DefaultCreateFtpDirectory(String text)
        {
            return new FtpDirectory(text);
        }
    }
}
