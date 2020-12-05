using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public class BufferByteArray
    {
        private Byte[] _Data = null;
        public Int32 Length { get; set; }

        public Byte[] Data
        {
            get { return _Data; }
        }
        public BufferByteArray(Int32 size)
        {
            _Data = new Byte[size];
        }
        public void Add(Byte data)
        {
            this.Add(new byte[] { data });
        }
        public void Add(Byte[] data)
        {
            if (this.Length + data.Length < _Data.Length)
            {
                Buffer.BlockCopy(data, 0, _Data, this.Length, data.Length);
            }
            else
            {
                var bb = _Data;
                _Data = new Byte[this.Length + data.Length];
                Buffer.BlockCopy(bb, 0, _Data, 0, bb.Length);
                Buffer.BlockCopy(data, 0, _Data, this.Length, data.Length);
            }
            this.Length += data.Length;
        }
        public void Add(Byte[] data, Int32 length)
        {
            if (this.Length + length <= _Data.Length)
            {
                Buffer.BlockCopy(data, 0, _Data, this.Length, length);
            }
            else
            {
                var bb = _Data;
                _Data = new Byte[this.Length + length];
                Buffer.BlockCopy(bb, 0, _Data, 0, bb.Length);
                Buffer.BlockCopy(data, 0, _Data, this.Length, length);
            }
            this.Length += length;
        }
        public void Clear()
        {
            this.Length = 0;
        }
        public Byte[] ToArray()
        {
            var bb = new Byte[this.Length];
            Buffer.BlockCopy(_Data, 0, bb, 0, this.Length);
            return bb;
        }
        public Byte[] ToArray(Int32 length)
        {
            return ToArray(0, length);
        }
        public Byte[] ToArray(Int32 startIndex, Int32 length)
        {
            var data = _Data;
            Byte[] bb = new Byte[length];
            System.Buffer.BlockCopy(data, startIndex, bb, 0, length);
            return bb;
        }
    }
}
