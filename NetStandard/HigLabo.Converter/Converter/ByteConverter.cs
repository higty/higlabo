using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public abstract class ByteConverter
    {
        private Byte[] _Buffer = null;

        public Int32 BufferSize { get; set; }

        public abstract Byte[] Encode(Byte[] input);
        public abstract Byte[] Decode(Byte[] input);

        protected Byte[] GetBuffer()
        {
            if (_Buffer == null || _Buffer.Length != this.BufferSize)
            {
                _Buffer = new Byte[this.BufferSize];
            }
            return _Buffer;
        }

        public String Encode(String text, Encoding inputEncoding, Encoding outputEncoding)
        {
            var input = inputEncoding.GetBytes(text);
            var bb = this.Encode(input);
            return outputEncoding.GetString(bb);
        }
        public String EncodeToText(Byte[] input, Encoding encoding)
        {
            return encoding.GetString(Encode(input));
        }
        public Byte[] EncodeFromText(String input, Encoding encoding)
        {
            return Encode(encoding.GetBytes(input));
        }

        public String Decode(String text, Encoding inputEncoding, Encoding outputEncoding)
        {
            var input = inputEncoding.GetBytes(text);
            var bb = this.Decode(input);
            return outputEncoding.GetString(bb);
        }
        public String DecodeToText(Byte[] input, Encoding encoding)
        {
            return encoding.GetString(Decode(input));
        }
        public Byte[] DecodeFromText(String input, Encoding encoding)
        {
            return Decode(encoding.GetBytes(input));
        }
    }
}
