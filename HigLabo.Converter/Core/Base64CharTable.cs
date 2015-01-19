using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public class Base64CharTable
    {
        private static readonly Char[] _Char61 = new Char[]
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9'
        };
        private Char[] _Chars = null;
        private Byte[] _EncodeTable = null;
        private Byte[] _DecodeTable = null;

        public Byte[] EncodeTable
        {
            get { return _EncodeTable; }
        }
        public Byte[] DecodeTable
        {
            get { return _DecodeTable; }
        }

        public Base64CharTable(Char char62, Char char63)
        {
            Char[] cc = new Char[64];
            for (int i = 0; i < _Char61.Length; i++)
            {
                cc[i] = _Char61[i];
            }
            cc[62] = char62;
            cc[63] = char63;
            _Chars = cc;

            this.SetEncodeTable();
            this.SetDecodeTable();
        }
        private void SetEncodeTable()
        {
            _EncodeTable = new Byte[_Chars.Length];
            for (int i = 0; i < _Chars.Length; i++)
            {
                _EncodeTable[i] = (Byte)_Chars[i];
            }
        }
        private void SetDecodeTable()
        {
            _DecodeTable = new Byte[256];

            for (int i = 0; i < 256; i++)
            {
                int mappingIndex = -1;
                if (i == 61) // = 
                {
                    mappingIndex = 0;
                }
                else
                {
                    for (int bc = 0; bc < _EncodeTable.Length; bc++)
                    {
                        if (i == _EncodeTable[bc])
                        {
                            mappingIndex = bc;
                            break;
                        }
                    }
                }

                if (mappingIndex > -1)
                {
                    _DecodeTable[i] = (byte)mappingIndex;
                }
                else
                {
                    _DecodeTable[i] = 0xFF;
                }
            }
        }
    }
}
