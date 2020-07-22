using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class InvalidMimeFormatException : Exception
    {
        public String ParseText { get; private set; }

        public InvalidMimeFormatException(String parseText)
            : base(parseText)
        {
            this.ParseText = parseText;
        }
    }
}
