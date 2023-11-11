using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public struct ServerSentEventLine
    {
        internal byte[] Data;
        public bool Complete { get; set; } 

        public ServerSentEventLine(int size, bool complete)
        {
            this.Data = new byte[size];
            this.Complete = complete;
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
            if (this.IsData())
            {
                return this.Data.AsSpan().Slice(5).ToArray();
            }
            return this.Data;
        }
    }
}
