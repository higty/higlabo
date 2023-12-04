using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class ServerSentEventResponse
    {
        internal Byte[] Buffer = new byte[1024];
        internal int BufferLength = 0;

        public IEnumerable<ServerSentEventLine> GetLines(List<ServerSentEventLine> previousDataList)
        {
            var startIndex = 0;
            var previousLength = previousDataList.Sum(el => el.Data.Length);

            for (int i = 0; i < BufferLength; i++)
            {
                if (Buffer[i] == 13 || Buffer[i] == 10)
                {
                    var line = new ServerSentEventLine(i - startIndex + previousLength, true);
                    this.SetPreviousData(line, previousDataList, startIndex, i);
                    previousDataList.Clear();
                    previousLength = 0;

                    if (i < BufferLength - 1 && Buffer[i + 1] == 10)
                    {
                        i = i + 2;
                    }
                    else
                    {
                        i = i + 1;
                    }
                    startIndex = i;
                    yield return line;
                }
            }

            {
                var line = new ServerSentEventLine(BufferLength - startIndex, false);
                for (int i = 0; i < line.Data.Length; i++)
                {
                    line.Data[i] = Buffer[startIndex + i];
                }
                yield return line;
            }
        }
        private void SetPreviousData(ServerSentEventLine line, List<ServerSentEventLine> previousDataList, int startIndex, int endIndex)
        {
            var pIndex = 0;
            foreach (var previousData in previousDataList)
            {
                for (int i = 0; i < previousData.Data.Length; i++)
                {
                    line.Data[pIndex++] = previousData.Data[i];
                }
            }
            for (int i = 0; i < endIndex - startIndex; i++)
            {
                line.Data[pIndex + i] = Buffer[startIndex + i];
            }
        }
        public void Clear()
        {
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i] = 0;
            }
        }
    }
}
