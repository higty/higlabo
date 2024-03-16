using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Anthropic
{
    public class MessagesStreamResult
    {
        public List<MessageContentBlockDelta> DeltaList { get; init; } = new();
        public string StopReason { get; set; } = "";
        public int OutputTokens { get; set; }

        public void Process(MessageContentBlockDelta delta)
        {
            this.DeltaList.Add(delta);
        }
        public string GetContent()
        {
            var sb = new StringBuilder(this.DeltaList.Sum(el => el.Delta.Text.Length) + 4);
            for (int i = 0; i < this.DeltaList.Count; i++)
            {
                sb.Append(this.DeltaList[i].Delta.Text);
            }
            return sb.ToString();
        }
    }
}
