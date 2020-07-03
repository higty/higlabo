using HigLabo.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class MimeWriterDefaultSettings
    {
        public Rfc2047Encoding HeaderRfc2047Encoding { get; set; }
        public Encoding HeaderEncoding { get; set; }
        public FileNameEncoding FileNameEncoding { get; set; }
        public MimeHeaderParameterEncoding MimeHeaderParameterEncoding { get; set; }

        public MimeWriterDefaultSettings()
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ja")
            {
                this.HeaderEncoding = Encoding.GetEncoding("iso-2022-jp");
                this.HeaderRfc2047Encoding = Rfc2047Encoding.Base64;
            }
            else
            {
                this.HeaderEncoding = Encoding.UTF8;
                this.HeaderRfc2047Encoding = Rfc2047Encoding.QuotedPrintable;
            }
            this.FileNameEncoding = FileNameEncoding.BestEffort;
            this.MimeHeaderParameterEncoding = MimeHeaderParameterEncoding.Rfc2231;
        }
    }
}
