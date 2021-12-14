using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Net.Ftp
{
    public class FtpFileCommandResult : FtpCommandResult
    {
        //private static readonly Regex _pathRegex = new Regex(@".*\{(?<FileName>.+)\}.*");
        private static readonly Regex _pathRegex = new Regex(@"\{.+\}");
        public string NewFileName { get; protected set; }
        public FtpFileCommandResult(FtpCommandResult result)
        {
            this.StatusCode = result.StatusCode;
            this.Text = result.Text;

            var match = _pathRegex.Match(result.Text);
            if (!String.IsNullOrEmpty(match.Value))
            {
                this.NewFileName = match.Value + ".tmp";
            }
        }
    }
}
