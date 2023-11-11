using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class ChatMessage
    {
        public ChatMessageRole Role { get; set; }
        public string Content { get; set; } = "";

        public ChatMessage() { }
        public ChatMessage(ChatMessageRole role, string content)
        {
            this.Role = role;
            this.Content = content;
        }

        public override string ToString()
        {
            return $"{this.Role.ToStringFromEnum()} {this.Content}";
        }
    }
}
