using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public class QuotedPrintableConverter : ByteConverter
    {
        static readonly byte[] HexAlphabet = new byte[16] {
			0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37,0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, // 0-9A-F
		};

        public QuotedPrintableConvertMode Mode { get; set; }
        public Boolean InsertNewline { get; set; }
        public Int32 CharCountPerLine { get; set; }

        public QuotedPrintableConverter(Int32 bufferSize, QuotedPrintableConvertMode mode)
        {
            this.BufferSize = bufferSize;
            this.CharCountPerLine = 76;
            this.InsertNewline = true;
            this.Mode = mode;
        }
        public override Byte[] Encode(Byte[] input)
        {
            BufferByteArray decoded = new BufferByteArray(input.Length * 3);
            var buffer = this.GetBuffer();
            Int32 bufferIndex = 0;
            Byte c = 0;
            Int32 charCount = 0;

            Int32 length = input.Length;
            for (int i = 0; i < length; i++)
            {
                c = input[i];
                if (bufferIndex + 6 > buffer.Length)
                {
                    decoded.Add(buffer, bufferIndex);
                    bufferIndex = 0;
                }
                if (InsertNewline == true && this.CharCountPerLine - 3 < charCount)//Insert new line
                {
                    var escaped = false;

                    if (c == 0x09 || c == 0x20)
                    {
                        // \t or white space
                        buffer[bufferIndex++] = 61; // '='
                        buffer[bufferIndex++] = HexAlphabet[(c & 0xf0) >> 4];
                        buffer[bufferIndex++] = HexAlphabet[c & 0x0f];

                        escaped = true;
                    }

                    buffer[bufferIndex++] = 61; // '='
                    buffer[bufferIndex++] = 13; // \r
                    buffer[bufferIndex++] = 10; // \n

                    charCount = 0;

                    if (escaped) { continue; }
                }

                var quote = false;

                switch (c)
                {
                    case 9: // \t
                    case 32: // ' ' WhiteSpace
                    case 63: // ?
                    case 95: // _
                        quote = this.InsertNewline == false;
                        break;
                    case 0x3d: // '='
                        quote = true;
                        break;

                    default:
                        // NonPrintableChar
                        quote = (c < 33 || 127 < c);
                        break;
                }

                if (quote == true)
                {
                    // = or NonPrintableChar
                    buffer[bufferIndex++] = 61; // '='
                    buffer[bufferIndex++] = HexAlphabet[(c & 0xf0) >> 4];
                    buffer[bufferIndex++] = HexAlphabet[c & 0x0f];

                    charCount += 3;
                }
                else
                {
                    // = or PrintableChar
                    buffer[bufferIndex++] = c;

                    charCount++;
                }
            }
            if (bufferIndex > 0)
            {
                decoded.Add(buffer, bufferIndex);
            }
            return decoded.ToArray();
        }
        public override Byte[] Decode(Byte[] input)
        {
            BufferByteArray decoded = new BufferByteArray(input.Length);
            var buffer = this.GetBuffer();
            Int32 bufferIndex = 0;
            var bbb = new byte[3];
            var bbbIndex = 0;
            Byte b = 0;
            Byte c = 0;

            var length = input.Length;
            for (int i = 0; i < length; i++)
            {
                c = input[i];
                if (bufferIndex + 3 > buffer.Length)
                {
                    decoded.Add(buffer, bufferIndex);
                    bufferIndex = 0;
                }

                if (bbbIndex == 0)
                {
                    if (c == 61) // =
                    {
                        bbb[bbbIndex++] = c;
                    }
                    else if (this.Mode == QuotedPrintableConvertMode.Header && c == 0x5f) // _
                    {
                        buffer[bufferIndex++] = 32; // white space
                    }
                    else
                    {
                        // NonQuotedChar
                        buffer[bufferIndex++] = c;
                    }
                }
                else
                {
                    // QuotedChar
                    bbb[bbbIndex++] = c;
                }

                if (bbbIndex == 3)
                {
                    if (bbb[1] == 13 && bbb[2] == 10)
                    {
                        // New line
                        bbbIndex = 0;
                    }
                    else if (bbb[1] == 13 || bbb[1] == 10)
                    {
                        if (bbb[2] == 61)
                        {
                            bbbIndex = 1;
                        }
                        else
                        {
                            buffer[bufferIndex++] = bbb[2];
                            bbbIndex = 0;
                        }
                    }
                    else
                    {
                        byte d = 0;

                        for (var bIndex = 1; bIndex < 3; bIndex++)
                        {
                            d <<= 4;
                            b = bbb[bIndex];

                            if (0x30 <= b && b <= 0x39)
                            {
                                d |= (byte)(b - 0x30);// 0-9
                            }
                            else if (0x41 <= b && b <= 0x46)
                            {
                                d |= (byte)(b - 0x37);// A-F
                            }
                            else if (0x61 <= b && b <= 0x66)
                            {
                                d |= (byte)(b - 0x57);// a-f
                            }
                            else
                            {
                                throw new FormatException();
                            }
                        }
                        buffer[bufferIndex++] = d;
                        bbbIndex = 0;
                    }
                }
            }
            if (bufferIndex > 0)
            {
                decoded.Add(buffer, bufferIndex);
            }
            return decoded.ToArray();
        }
    }
}
