using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class MessageObject
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public Int64 Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public string Thread_Id { get; set; } = "";
        public string Role { get; set; } = "";
        public MessageContentObject? Content { get; set; }
        public string Assistant_Id { get; set; } = "";
        public string? Run_Id { get; set; }
        public List<string>? File_Ids { get; set; }
        public string? MetaData { get; set; }

        public override string ToString()
        {
            return $"{this.Id} {this.Role} {this.Content?.Text}";
        }
    }
    public class MessageObjectResponse : RestApiResponse
    {
        public string Id { get; set; } = "";
        public Int64 Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public string Thread_Id { get; set; } = "";
        public string Role { get; set; } = "";
        public MessageContentObject? Content { get; set; }
        public string Assistant_Id { get; set; } = "";
        public string? Run_Id { get; set; }
        public List<string>? File_Ids { get; set; }
        public string? MetaData { get; set; }

        public override string ToString()
        {
            return $"{this.Id} {this.Role} {this.Content?.Text}";
        }
    }

    public enum MessageContentType
    {
        Image_File,
        Text,
    }
    public class MessageContentObject
    {
        public MessageContentType Type { get; set; } = MessageContentType.Text;
        public string Image_File { get; set; } = "";
        public MessageTextObject? Text { get; set; }
    }
    public class MessageImageObject
    {
        public string File_Id { get; set; } = "";
    }
    public class MessageTextObject
    {
        public string Value { get; set; } = "";
        public object? Annotations { get; set; }
    }
}
