using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class MimeParserDefaultSettings
    {
        public Int32 BufferSize { get; set; }
        public Int32 QuotedPrintableConverterBufferSize { get; set; }
        public Int32 Base64ConverterBufferSize { get; set; }
        public MimeParserFilter Filter { get; set; }
        public Encoding Encoding { get; set; }

        public MimeParserDefaultSettings()
        {
            this.BufferSize = 12000;
            this.QuotedPrintableConverterBufferSize = 2000;
            this.Base64ConverterBufferSize = 20000;
            this.Filter = new MimeParserFilter();
            this.Encoding = Encoding.UTF8;
        }
    }
}
