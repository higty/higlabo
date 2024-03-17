using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Anthropic
{
    public class MessagesStreamResult
    {
        public MessagesObject? Message { get; set; }
        public List<MessageContentBlockDelta> DeltaList { get; init; } = new();
        public MessageDelta? MessageDelta { get; set; }

        public void Process(MessageContentBlockDelta delta)
        {
            this.DeltaList.Add(delta);
        }
        public string GetText()
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
