using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Net.Ftp
{
    public class FtpIPCommandResult : FtpCommandResult
    {
        private static readonly Regex _pathRegex = new Regex(@".*\((?<Ip>.+)\).*");
        public string IPInfo { get; protected set; }
        public FtpIPCommandResult(FtpCommandResult result)
        {
            this.StatusCode = result.StatusCode;
            this.Text = result.Text;

            var match = _pathRegex.Match(result.Text);
            this.IPInfo = match.Groups["Ip"].Value;
        }
    }
}
