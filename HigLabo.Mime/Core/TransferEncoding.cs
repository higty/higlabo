using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    /// Specify transfer-encoding
    /// <summary>
    /// Specify transfer-encoding
    /// </summary>
    public enum TransferEncoding
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        /// <summary>
        /// 
        /// </summary>
        SevenBit,
        /// <summary>
        /// 
        /// </summary>
        EightBit,
        /// <summary>
        /// 
        /// </summary>
        Binary,
        /// <summary>
        /// 
        /// </summary>
        Base64,
        /// <summary>
        /// 
        /// </summary>
        QuotedPrintable
    }
    public static class TransferEncodingExtensions
    {
        public static String ToHeaderText(this TransferEncoding transferEncoding)
        {
            switch (transferEncoding)
            {
                case TransferEncoding.None: return "";
                case TransferEncoding.SevenBit: return "7bit";
                case TransferEncoding.EightBit: return "8bit";
                case TransferEncoding.Binary: return "Binary";
                case TransferEncoding.Base64: return "Base64";
                case TransferEncoding.QuotedPrintable: return "Quoted-Printable";
                default: throw new InvalidOperationException();
            }
        }
#if !NETFX_CORE
        public static TransferEncoding Cast(this System.Net.Mime.TransferEncoding encoding)
        {
            switch (encoding)
            {
                case System.Net.Mime.TransferEncoding.Base64: return TransferEncoding.Base64;
                case System.Net.Mime.TransferEncoding.QuotedPrintable: return TransferEncoding.QuotedPrintable;
                case System.Net.Mime.TransferEncoding.SevenBit: return TransferEncoding.SevenBit;
                case System.Net.Mime.TransferEncoding.Unknown: return TransferEncoding.None;
                default: throw new InvalidOperationException();
            }
        }
#endif
    }
}
