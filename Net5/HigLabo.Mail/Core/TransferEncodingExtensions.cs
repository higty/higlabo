using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Mime
{
    public static class TransferEncodingExtensions
    {
        public static HigLabo.Mime.TransferEncoding Cast(this System.Net.Mime.TransferEncoding encoding)
        {
            switch (encoding)
            {
                case System.Net.Mime.TransferEncoding.Base64: return HigLabo.Mime.TransferEncoding.Base64;
                case System.Net.Mime.TransferEncoding.QuotedPrintable: return HigLabo.Mime.TransferEncoding.QuotedPrintable;
                case System.Net.Mime.TransferEncoding.SevenBit: return HigLabo.Mime.TransferEncoding.SevenBit;
                case System.Net.Mime.TransferEncoding.Unknown: return HigLabo.Mime.TransferEncoding.None;
                default: throw new InvalidOperationException();
            }
        }
    }
}
