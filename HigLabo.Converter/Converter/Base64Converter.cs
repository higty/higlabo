using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public class Base64Converter : ByteConverter
    {
        public Base64CharTable Base64CharTable { get; set; }
        public Boolean InsertNewline { get; set; }
        public Boolean Padding { get; set; }
        public Int32 CharCountPerLine { get; set; }
        public Boolean DecodeDataIsNormalized { get; set; }

        public Base64Converter(Int32 bufferSize)
            : this(bufferSize, '/')
        {
        }
        public Base64Converter(Int32 bufferSize, Char char63)
        {
            this.BufferSize = bufferSize;
            this.Base64CharTable = new Base64CharTable('+', char63);
            this.InsertNewline = true;
            this.Padding = true;
            this.CharCountPerLine = 72;
            this.DecodeDataIsNormalized = false;
        }

        public String Encode(String text, Encoding encoding)
        {
            var bb = encoding.GetBytes(text);
            return this.EncodeToText(bb, Encoding.UTF8);
        }
        public override Byte[] Encode(Byte[] input)
        {
            if (this.InsertNewline == true)
            {
                return EncodeWithInsertingNewline(input);
            }
            return EncodeWithoutInsertingNewline(input);
        }
        private Byte[] EncodeWithInsertingNewline(Byte[] input)
        {
            BufferByteArray encoded = new BufferByteArray((input.Length / 3) * 4);
            var buffer = this.GetBuffer();
            var bufferIndex = 0;
            Int32 loopCount = input.Length / 3;
            Byte c0, c1, c2;
            Int32 startIndex = 0;
            Int32 charCountPerLine = 0;
            Int32 paddingCount = 0;
            var encodeTable = this.Base64CharTable.EncodeTable;

            for (int i = 0; i < loopCount; i++)
            {
                startIndex = i * 3;
                c0 = input[startIndex];
                c1 = input[startIndex + 1];
                c2 = input[startIndex + 2];

                if (bufferIndex + 6 >= buffer.Length)
                {
                    encoded.Add(buffer, bufferIndex);
                    bufferIndex = 0;
                }
                buffer[bufferIndex++] = encodeTable[c0 >> 2];
                buffer[bufferIndex++] = encodeTable[(c1 >> 4) | ((c0 & 0x3) << 4)];
                buffer[bufferIndex++] = encodeTable[((c1 & 0x0f) << 2) | (c2 >> 6)];
                buffer[bufferIndex++] = encodeTable[c2 & 63];
                
                charCountPerLine += 4;

                if (charCountPerLine >= this.CharCountPerLine)
                {
                    buffer[bufferIndex++] = 13;// \r
                    buffer[bufferIndex++] = 10;// \n
                    charCountPerLine = 0;
                }
            }
            if (loopCount > 0)
            {
                startIndex += 3;
            }

            if (bufferIndex + 4 > buffer.Length)
            {
                encoded.Add(buffer, bufferIndex);
            }
            if (input.Length - startIndex == 2)
            {
                c0 = input[startIndex];
                c1 = input[startIndex + 1];
                c2 = 0;
                buffer[bufferIndex++] = encodeTable[c0 >> 2];
                buffer[bufferIndex++] = encodeTable[(c1 >> 4) | ((c0 & 0x3) << 4)];
                buffer[bufferIndex++] = encodeTable[((c1 & 0x0f) << 2) | (c2 >> 6)];
                buffer[bufferIndex++] = 61;
                paddingCount = 1;
            }
            else if (input.Length - startIndex == 1)
            {
                c0 = input[startIndex];
                c1 = 0;
                c2 = 0;
                buffer[bufferIndex++] = encodeTable[c0 >> 2];
                buffer[bufferIndex++] = encodeTable[(c1 >> 4) | ((c0 & 0x3) << 4)];
                buffer[bufferIndex++] = 61;
                buffer[bufferIndex++] = 61;
                paddingCount = 2;
            }
            if (bufferIndex > 0)
            {
                if (this.Padding == true)
                {
                    encoded.Add(buffer, bufferIndex);
                }
                else
                {
                    encoded.Add(buffer, bufferIndex - paddingCount);
                }
            }
            return encoded.ToArray();
        }
        private Byte[] EncodeWithoutInsertingNewline(Byte[] input)
        {
            Byte[] encoded = null;
            if (input.Length % 3 == 0)
            {
                encoded = new Byte[(input.Length / 3) * 4];
            }
            else
            {
                encoded = new Byte[(input.Length / 3) * 4 + 4];
            }
            Int32 encodedIndex = 0;
            Int32 loopCount = input.Length / 3;
            Byte c0, c1, c2;
            Int32 startIndex = 0;
            Int32 paddingCount = 0;
            var encodeTable = this.Base64CharTable.EncodeTable;

            for (int i = 0; i < loopCount; i++)
            {
                startIndex = i * 3;
                c0 = input[startIndex];
                c1 = input[startIndex + 1];
                c2 = input[startIndex + 2];

                startIndex += 3;
                encoded[encodedIndex++] = encodeTable[c0 >> 2];
                encoded[encodedIndex++] = encodeTable[(c1 >> 4) | ((c0 & 0x3) << 4)];
                encoded[encodedIndex++] = encodeTable[((c1 & 0x0f) << 2) | (c2 >> 6)];
                encoded[encodedIndex++] = encodeTable[c2 & 63];
            }
            
            if (input.Length - startIndex == 2)
            {
                c0 = input[startIndex];
                c1 = input[startIndex + 1];
                c2 = 0;
                encoded[encodedIndex++] = encodeTable[c0 >> 2];
                encoded[encodedIndex++] = encodeTable[(c1 >> 4) | ((c0 & 0x3) << 4)];
                encoded[encodedIndex++] = encodeTable[((c1 & 0x0f) << 2) | (c2 >> 6)];
                encoded[encodedIndex++] = 61;
                paddingCount = 1;
            }
            else if (input.Length - startIndex == 1)
            {
                c0 = input[startIndex];
                c1 = 0;
                c2 = 0;
                encoded[encodedIndex++] = encodeTable[c0 >> 2];
                encoded[encodedIndex++] = encodeTable[(c1 >> 4) | ((c0 & 0x3) << 4)];
                encoded[encodedIndex++] = 61;
                encoded[encodedIndex++] = 61;
                paddingCount = 2;
            }
            if (this.Padding == true)
            {
                return encoded;
            }
            else
            {
                Byte[] bb = new Byte[encodedIndex - paddingCount];
                Buffer.BlockCopy(encoded, 0, bb, 0, encodedIndex- paddingCount);
                return bb;
            }
        }

        public String Decode(String text, Encoding encoding)
        {
            var bb = Encoding.UTF8.GetBytes(text);
            return this.DecodeToText(bb, encoding);
        }
        public override Byte[] Decode(Byte[] input)
        {
            if (this.DecodeDataIsNormalized == true)
            {
                return DecodeFromNormalizedInput(input);
            }
            return DecodeFromUnNormalizedInput(input);
        }
        private Byte[] DecodeFromUnNormalizedInput(Byte[] input)
        {
            BufferByteArray decoded = new BufferByteArray((input.Length / 4 * 3));
            var buffer = this.GetBuffer();
            Int32 bufferIndex = 0;
            UInt32 bbbb = 0;
            Int32 bIndex = 0;
            Byte c = 0;
            Int32 paddingCount = 0;
            var decodeTable = this.Base64CharTable.DecodeTable;//For performance improvement
            Int32 length = input.Length;//For performance improvement
            for (int i = 0; i < length; i++)
            {
                c = decodeTable[input[i]];
                if (c == 255) { continue; }

                if (bufferIndex + 3 >= buffer.Length)
                {
                    decoded.Add(buffer, bufferIndex);
                    bufferIndex = 0;
                }

                bbbb = bbbb << 6 | c;
                bIndex += 1;
                if (input[i] == 61)// = 
                {
                    paddingCount++;
                }
                if (bIndex == 4)
                {
                    buffer[bufferIndex++] = (byte)((bbbb >> 16) & 0xFF);
                    buffer[bufferIndex++] = (byte)((bbbb >> 8) & 0xFF);
                    buffer[bufferIndex++] = (byte)(bbbb & 0xFF);
                    bbbb = 0;
                    bIndex = 0;
                }
            }
            if (bufferIndex > 0)
            {
                decoded.Add(buffer, bufferIndex - paddingCount);
            }
            return decoded.ToArray();
        }
        private Byte[] DecodeFromNormalizedInput(Byte[] input)
        {
            Int32 paddingCount = 0;
            var decodeTable = this.Base64CharTable.DecodeTable;

            if (input[input.Length - 1] == 61)// =
            {
                paddingCount = 1;
                if (input[input.Length - 2] == 61)// =
                {
                    paddingCount = 2;
                }
            }
            Byte[] decoded = new Byte[(input.Length / 4 * 3) + paddingCount];
            Int32 decodedIndex = 0;
            Int32 loopCount = input.Length / 4;
            Int32 startIndex = 0;
            UInt32 buffer = 0;

            for (int i = 0; i < loopCount; i++)
            {
                startIndex = i * 4;
                buffer = 0;
                for (int bIndex = 0; bIndex < 4; bIndex++)
                {
                    buffer = buffer << 6 | decodeTable[input[startIndex + bIndex]];
                }
                decoded[decodedIndex++] = (byte)((buffer >> 16) & 0xFF);
                decoded[decodedIndex++] = (byte)((buffer >> 8) & 0xFF);
                decoded[decodedIndex++] = (byte)(buffer & 0xFF);
            }

            buffer = 0;
            for (int bIndex = 0; bIndex < 4 - paddingCount; bIndex++)
            {
                buffer += buffer << 6 | decodeTable[input[startIndex + bIndex]];
            }
            if (paddingCount > 0)
            {
                var count = 3 - paddingCount;
                for (int i = 0; i < paddingCount; i++)
                {
                    decoded[decodedIndex++] = (byte)(buffer >> (16 - (i * 8)) & 0xFF);
                }
            }
            return decoded;
        }
    }
}
