using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public struct ServerSentEventLine
    {
        private byte[] Data;
        private int IndexOfSpace = -1;

        public int Length
        {
            get { return this.Data.Length; }
        }
        public bool Complete { get; set; } 

        public ServerSentEventLine(int size, bool complete)
        {
            this.Data = new byte[size];
            this.Complete = complete;
        }
        internal void SetData(byte[] buffer, IEnumerable<ServerSentEventLine> previousDataList, int startIndex, int endIndex)
        {
            var pIndex = 0;
            foreach (var previousData in previousDataList)
            {
                for (int i = 0; i < previousData.Data.Length; i++)
                {
                    if (this.IndexOfSpace == -1 && previousData.Data[i] == 32)
                    {
                        this.IndexOfSpace = pIndex;
                    }
                    this.Data[pIndex++] = previousData.Data[i];
                }
            }
            for (int i = 0; i < endIndex - startIndex; i++)
            {
                if (this.IndexOfSpace == -1 && buffer[startIndex + i] == 32)
                {
                    this.IndexOfSpace = pIndex + i;
                }
                this.Data[pIndex + i] = buffer[startIndex + i];
            }
        }
   
        public bool IsEvent()
        {
            if (this.Data.Length < 6)
            {
                return false;
            }
            if (Data[0] == 101 &&
                Data[1] == 118 &&
                Data[2] == 101 &&
                Data[3] == 110 &&
                Data[4] == 116 &&
                Data[5] == 58)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsData()
        {
            if (this.Data.Length < 5)
            {
                return false;
            }
            if (Data[0] == 100 &&
                Data[1] == 97 &&
                Data[2] == 116 &&
                Data[3] == 97 &&
                Data[4] == 58)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsDone()
        {
            if (this.Data.Length < 12)
            {
                return false;
            }
            var index = 0;
            if (Data[index++] == 100 &&
                Data[index++] == 97 &&
                Data[index++] == 116 &&
                Data[index++] == 97 &&
                Data[index++] == 58 &&
                Data[index++] == 32 &&
                Data[index++] == 91 &&
                Data[index++] == 68 &&
                Data[index++] == 79 &&
                Data[index++] == 78 &&
                Data[index++] == 69 &&
                Data[index++] == 93)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsEmpty()
        {
            for (int i = 0; i < this.Data.Length; i++)
            {
                if (this.Data[i] != 13 && this.Data[i] != 10) { return false; }
            }
            return true;
        }
        public byte[] GetValue()
        {
            if (this.IndexOfSpace == -1) { return this.Data; }
            return this.Data.AsSpan().Slice(this.IndexOfSpace + 1).ToArray();
        }
        public string GetText()
        {
            if (this.IndexOfSpace == -1) { return Encoding.UTF8.GetString(this.Data); }
            return Encoding.UTF8.GetString(this.Data.AsSpan().Slice(this.IndexOfSpace + 1));
        }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(this.Data);
        }
    }
}
