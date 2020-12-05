using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Converter
{
    public class EncodingNotFoundException : Exception
    {
        public String Encoding { get; set; }

        public EncodingNotFoundException(String encoding)
        {
            this.Encoding = encoding;
        }
    }
}
