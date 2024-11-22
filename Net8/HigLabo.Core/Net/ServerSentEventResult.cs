using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core;

public class ServerSentEventResult
{
    public List<ServerSentEventLine> LineList { get; init; } = new();

    public void AddLine(ServerSentEventLine line)
    {
        this.LineList.Add(line);
    }
    public override string ToString()
    {
        var sb = new StringBuilder(this.LineList.Sum(el => el.Length) + 4);
        for (int i = 0; i < this.LineList.Count; i++)
        {
            sb.AppendLine(this.LineList[i].ToString());
        }
        return sb.ToString();
    }
}
