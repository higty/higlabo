using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class InvalidMimeFormatException : Exception
    {
        public String RawText { get; private set; }
        public String ParseText { get; private set; }
        public InvalidMimeFormatException(String rawText, String parseText)
            : base()
        {
            this.RawText = rawText;
            this.ParseText = parseText;
        }
    }
}
