using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Converter;

namespace HigLabo.Mime.Internal
{
    internal class MimeContentByteArray
    {
        private Byte[] _BoundaryLine = null;
        private List<Byte[]> _HeaderData = new List<Byte[]>();
        private List<Byte[]> _BodyData = new List<Byte[]>();
        public Int32 HeaderLength { get; set; }
        public Int32 Length { get; set; }

        public void AddBoundaryLine(Byte[] data)
        {
            var dataLength = data.Length;
            if (data.Length > 1 && data[data.Length - 1] == 10)
            {
                dataLength -= 1;
            }
            if (data.Length > 2 && data[data.Length - 2] == 13)
            {
                dataLength -= 1;
            }
            this.Length += dataLength;
            if (_BoundaryLine == null)
            {
                _BoundaryLine = new Byte[dataLength];
                Buffer.BlockCopy(data, 0, _BoundaryLine, 0, dataLength);
            }
            else
            {
                var bb = _BoundaryLine;
                _BoundaryLine = new Byte[_BoundaryLine.Length + dataLength];
                Buffer.BlockCopy(bb, 0, _BoundaryLine, 0, bb.Length);
                Buffer.BlockCopy(data, 0, _BoundaryLine, bb.Length, dataLength);
            }
        }
        public void AddHeaderLine(Byte[] data)
        {
            this.Length += data.Length;
            _HeaderData.Add(data);
        }
        public void AddBodyLine(Byte[] data)
        {
            this.Length += data.Length;
            _BodyData.Add(data);
        }
        public CheckBoundaryResult CheckBoundary(Byte[] boundary)
        {
            if (boundary == null) { return CheckBoundaryResult.None; }

            var boundaryLength = boundary.Length;
            if (_BoundaryLine.Length == boundaryLength)
            {
                for (int i = 0; i < boundaryLength; i++)
                {
                    if (_BoundaryLine[i] != boundary[i]) { return CheckBoundaryResult.None; }
                }
                return CheckBoundaryResult.Boundary;
            }
            if (_BoundaryLine.Length == boundaryLength + 2)
            {
                for (int i = 0; i < boundaryLength; i++)
                {
                    if (_BoundaryLine[i] != boundary[i]) { return CheckBoundaryResult.None; }
                }
                for (int i = 0; i < 2; i++)
                {
                    if (_BoundaryLine[boundaryLength] != (Byte)'-') { return CheckBoundaryResult.None; }
                }
                return CheckBoundaryResult.EndBoundary;
            }
            return CheckBoundaryResult.None;
        }
        public byte[] GetBodyArray()
        {
            Byte[] data = null;
            Int32 lastIndex = _BodyData.Count - 1;
            var lastBytes = _BodyData[lastIndex];
            Boolean endWithNewline = lastBytes.Length > 1 && lastBytes[lastBytes.Length - 2] == 13 && lastBytes[lastBytes.Length - 1] == 10;

            if (endWithNewline == true)
            {
                data = new Byte[this.Length - this.HeaderLength - 2];
            }
            else
            {
                data = new Byte[this.Length - this.HeaderLength];
            }
            Int32 startIndex = 0;
            Int32 length = 0;
            for (int i = 0; i < lastIndex; i++)
            {
                length = _BodyData[i].Length;
                Buffer.BlockCopy(_BodyData[i], 0, data, startIndex, length);
                startIndex += length;
            }
            //Remove last new line char
            if (endWithNewline == true)
            {
                length = lastBytes.Length - 2;
            }
            else
            {
                length = lastBytes.Length;
            }
            Buffer.BlockCopy(lastBytes, 0, data, startIndex, length);
            startIndex += length;

            return data;
        }
        public byte[] GetEntireArray()
        {
            var data = new byte[this.Length];
            int startIndex = 0;
            Int32 count = 0;
            Int32 length = 0;

            //Boundary
            Buffer.BlockCopy(_BoundaryLine, 0, data, startIndex, _BoundaryLine.Length);
            startIndex += _BoundaryLine.Length;

            //Header
            count = _HeaderData.Count;
            for (int i = 0; i < count; i++)
            {
                length = _HeaderData[i].Length;
                Buffer.BlockCopy(_HeaderData[i], 0, data, startIndex, length);
                startIndex += length;
            }
            //Body
            count = _BodyData.Count;
            for (int i = 0; i < count; i++)
            {
                length = _BodyData[i].Length;
                Buffer.BlockCopy(_BodyData[i], 0, data, startIndex, length);
                startIndex += length;
            }
            return data;
        }
        public void Clear()
        {
            _BoundaryLine = null;
            _HeaderData.Clear();
            _BodyData.Clear();
            this.HeaderLength = 0;
            this.Length = 0;
        }
    }
}
