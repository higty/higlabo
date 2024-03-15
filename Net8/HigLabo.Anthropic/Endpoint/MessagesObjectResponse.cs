using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic
{
    public class MessagesObjectResponse
    {
        public string Id { get; set; } = "";
        public string Type { get; set; } = "";
        public string Role { get; set; } = "";
        public List<MessageText> Content { get; set; } = new();
        public string Model { get; set; } = "";
        public string Stop_Reason { get; set; } = "";
        public string? Stop_Sequence { get; set; } 
        public MessageUsage Usage { get; set; } = new();
    }
    public class MessagesObjectResponseResponse: RestApiResponse
    {
        public string Id { get; set; } = "";
        public string Type { get; set; } = "";
        public string Role { get; set; } = "";
        public List<MessageText> Content { get; set; } = new();
        public string Model { get; set; } = "";
        public string Stop_Reason { get; set; } = "";
        public string? Stop_Sequence { get; set; }
        public MessageUsage Usage { get; set; } = new();
    }
    public class MessageText
    {
        public string Type { get; set; } = "";
        public string Text { get; set; } = "";
    }
    public class MessageUsage
    {
        public int Input_Tokens { get; set; }
        public int Output_Tokens { get; set; }
    }
}
