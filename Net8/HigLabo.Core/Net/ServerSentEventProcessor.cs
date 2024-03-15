using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class ServerSentEventProcessor
    {
        public Stream Stream { get; set; }

        public ServerSentEventProcessor(Stream stream)
        {
            this.Stream = stream;
        }

        public async IAsyncEnumerable<string> Process([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var sseResponse = new ServerSentEventResponse();
            var previousLineList = new List<ServerSentEventLine>();

            var loopIndex = 0;
            while (true)
            {
                sseResponse.Clear();
                var readCount = await this.Stream.ReadAsync(sseResponse.Buffer, cancellationToken);
                sseResponse.BufferLength = readCount;

                Debug.WriteLine($"■Read={readCount} {Encoding.UTF8.GetString(sseResponse.Buffer)}");
                if (readCount == 0) { break; }

                foreach (var line in sseResponse.GetLines(previousLineList))
                {
                    if (cancellationToken.IsCancellationRequested) { break; }

                    if (line.IsEmpty()) { continue; }
                    if (line.IsDone()) { yield break; }
                    if (line.Complete == false)
                    {
                        previousLineList.Add(line);
                        continue;
                    }
                    if (line.IsEvent())
                    {
                        var text = Encoding.UTF8.GetString(line.GetValue());
                        yield return text;
                    }
                    if (line.IsData())
                    {
                        var text = Encoding.UTF8.GetString(line.GetValue());
                        yield return text;
                    }
                }
                loopIndex++;
            }

        }
    }
}
