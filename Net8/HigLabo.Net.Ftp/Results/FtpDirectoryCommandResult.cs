using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Net.Ftp
{
    public class FtpDirectoryCommandResult : FtpCommandResult
    {
        private static readonly Regex _pathRegex = new Regex(@".*""(?<Path>.+)"".*");
        public string DirectoryPath { get; protected set; }
        public FtpDirectoryCommandResult(FtpCommandResult result)
        {
            this.StatusCode = result.StatusCode;
            this.Text = result.Text;

            var match = _pathRegex.Match(result.Text);
            this.DirectoryPath = match.Groups["Path"].Value;
        }
    }
}
