using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HigLabo.Mime.Internal
{
    internal unsafe class MimeStreamBuffer
    {
        private static readonly Byte[] _EmptyBytes = new Byte[0];

        private Boolean _IsLastOfLine = false;
        private Byte[] _LastLine = _EmptyBytes;
        private Byte* _Current = null;
        private Byte* _Start = null;
        private Byte* _End = null;

        public Boolean EndOfStream { get; private set; }
        
        public MimeStreamBuffer()
        {
        }
        public void Initialize(Byte* readBufferPtr, Int32 length, Boolean endOfStream)
        {
            _IsLastOfLine = false;
            _LastLine = _EmptyBytes;

            this._Start = null;
            this._Current = readBufferPtr;
            this._End = readBufferPtr + length * sizeof(Byte);
            this.EndOfStream = endOfStream;
        }
        public Byte[] ReadLine()
        {
            this._Start = this._Current;
            //Find LineFeed char
            while (*this._Current != 10) { this._Current++; }

            if (this._Start == this._Current)
            {
                this._Current++;
                return _EmptyBytes;
            }
             this._Current++;

            return MimeParser.CreateNewBytes(new IntPtr(this._Start), this._Current - this._Start);
        }
        public MimeHeaderBufferByteArray ReadHeader(MimeHeaderBufferByteArray header)
        {
            this._Start = this._Current;
            Byte* start = this._Start;
            Byte* lastOfLine = this._Current;

            if (this._Current == this._End) { return header; }
            if (*this._Current == 10)// \n
            {
                this._Current++;
                header.Add(MimeParser.CreateNewBytes(new IntPtr(start), this._Current - start), true);
                return header;
            }            
            //Find LineFeed char
            while (true)
            {
                // \n
                while (*this._Current != 10) { this._Current++; }

                if (this._Current == this._End)
                {
                    header.Add(MimeParser.CreateNewBytes(new IntPtr(start), this._End - start), false);
                    return header;
                }
                lastOfLine = this._Current - 2;

                this._Current++;
                //Empty line is start of body
                if (lastOfLine - this._Start < 1)
                {
                    header.Add(MimeParser.CreateNewBytes(new IntPtr(start), this._Current - start), true);
                    return header;
                }

                if (*this._Current != 9 && *this._Current != 32)// \t or white space
                {
                    header.Add(MimeParser.CreateNewBytes(new IntPtr(start), this._Current - start), true);
                    return header;
                }
            }
        }
        public Byte[] ReadBody(Byte[] boundary, out CheckBoundaryResult result, out Boolean isEndOfBody)
        {
            result = CheckBoundaryResult.None;
            isEndOfBody = false;

            if (this._Current == this._End)
            {
                isEndOfBody = true;
                return _EmptyBytes;
            }

            Int32 boundaryLength = -1;
            if (boundary != null)
            {
                boundaryLength = boundary.Length;
            }

            this._Start = this._Current;
            var line_Start = this._Current;

            UInt32 bbbbXor = 0;
            
            while (true)
            {
                UInt32* bbbb = (UInt32*)this._Current;
                do
                {
                    bbbbXor = *bbbb++ ^ 0x0A0A0A0A;
                } while (((bbbbXor - 0x01010101) & ~bbbbXor & 0x80808080) == 0);
                this._Current = (byte*)(bbbb - 1);
                // 10 is \n
                while (*this._Current != 10) { this._Current++; }

                if (*line_Start == 46)// .
                {
                    var lastOfLine = this._Current - 2;
                    if (line_Start == lastOfLine)
                    {
                        isEndOfBody = true;
                        //Remove last period from bodydata
                        return MimeParser.CreateNewBytes(new IntPtr(this._Start), lastOfLine - this._Start);
                    }
                }
                // Check this line is started by '-' (Boundary).
                //That avoid method call of CheckBoundary and improve performance.
                if (*line_Start == 45 && boundaryLength > -1)
                {
                    var lastOfLine = this._Current - 2;
                    var length = lastOfLine - line_Start + 1;
                    if (length == boundaryLength || length == boundaryLength + 2)
                    {
                        result = CheckBoundary(line_Start, lastOfLine + 1, boundary);
                        if (result != CheckBoundaryResult.None)
                        {
                            if (result == CheckBoundaryResult.Boundary)
                            {
                                //Back to start of line.To read boundary line on MimeParser.ReadMimeContent method.
                                this._Current = line_Start;
                            }
                            return MimeParser.CreateNewBytes(new IntPtr(this._Start), line_Start - this._Start);
                        }
                    }
                }
                if (this._Current == this._End)
                {
                    //Contains only 1 line and end of buffer
                    if (line_Start == this._Start)
                    {
                        this._Current = line_Start;
                        _IsLastOfLine = true;
                        _LastLine = MimeParser.CreateNewBytes(new IntPtr(this._Start), this._End - this._Start);
                        return _EmptyBytes;
                    }
                    return MimeParser.CreateNewBytes(new IntPtr(this._Start), this._Current - this._Start);
                }
                this._Current++;
                line_Start = this._Current;
            }
        }
        private CheckBoundaryResult CheckBoundary(Byte* start, Byte* end, Byte[] boundary)
        {
            Int32 boundaryLength = boundary.Length;
            var current = start;
            for (int i = 0; i < boundaryLength; i++)
            {
                if (*current != boundary[i]) { return CheckBoundaryResult.None; }
                current++;
            }
            if (current == end) { return CheckBoundaryResult.Boundary; }
            for (int i = 0; i < 2; i++)
            {
                if (*current != (Byte)'-') { return CheckBoundaryResult.None; }
                current++;
            }
            return CheckBoundaryResult.EndBoundary;
        }
        public Boolean IsEnd()
        {
            return this._Current >= this._End || _IsLastOfLine; 
        }
        public Byte[] GetLastLine()
        {
            return _LastLine;
        }
    }
}
