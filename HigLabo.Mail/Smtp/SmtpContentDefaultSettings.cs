using HigLabo.Converter;
using HigLabo.Mime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpContentDefaultSettings
    {
        public Encoding ContentTypeCharsetEncoding { get; set; }
        public TransferEncoding ContentTransferEncoding { get; set; }

        public SmtpContentDefaultSettings()
        {
            this.SetProperty();
        }
        private void SetProperty()
        {

            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ja")
            {
                this.ContentTypeCharsetEncoding = Encoding.GetEncoding("iso-2022-jp");
                this.ContentTransferEncoding = TransferEncoding.Base64;
            }
            else
            {
                this.ContentTypeCharsetEncoding = Encoding.UTF8;
                this.ContentTransferEncoding = TransferEncoding.QuotedPrintable;
            }
        }
    }
}
