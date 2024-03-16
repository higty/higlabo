using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace HigLabo.Core
{
    public class ServerSentEventResponse
    {
        internal Byte[] Buffer = new byte[1024];
        internal int BufferLength = 0;

        public IEnumerable<ServerSentEventLine> GetLines(List<ServerSentEventLine> previousDataList)
        {
            var startIndex = 0;
            var previousLength = previousDataList.Sum(el => el.Length);

            for (int i = 0; i < BufferLength; i++)
            {
                if (Buffer[i] == 13 || Buffer[i] == 10)
                {
                    var line = new ServerSentEventLine(i - startIndex + previousLength, true);
                    line.SetData(Buffer, previousDataList, startIndex, i);
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

            //Last line
            {
                var line = new ServerSentEventLine(BufferLength - startIndex, false);
                line.SetData(Buffer, Array.Empty<ServerSentEventLine>(), startIndex, BufferLength);
                yield return line;
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
