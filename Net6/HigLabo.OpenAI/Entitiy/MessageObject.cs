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
        public List<MessageContentObject> Content { get; set; } = new();
        public string Assistant_Id { get; set; } = "";
        public string? Run_Id { get; set; }
        public List<string>? File_Ids { get; set; }
        public object? MetaData { get; set; }

        public override string ToString()
        {
            return $"{this.Id} {this.Role} {this.Content?.ToString()}";
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
        public List<MessageContentObject> Content { get; set; } = new();
        public string Assistant_Id { get; set; } = "";
        public string? Run_Id { get; set; }
        public List<string>? File_Ids { get; set; }
        public object? MetaData { get; set; }

        public override string ToString()
        {
            return $"{this.Id} {this.Role} {this.Content?.ToString()}";
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
        public MessageImageObject? Image_File { get; set; }
        public MessageTextObject? Text { get; set; }

        public override string ToString()
        {
            switch (this.Type)
            {
                case MessageContentType.Image_File: return this.Image_File?.File_Id ?? "";
                case MessageContentType.Text: return this.Text?.Value ?? "";
                default: return "";
            };
        }
    }
    public class MessageImageObject
    {
        public string File_Id { get; set; } = "";

        public override string ToString()
        {
            return this.File_Id;
        }
    }
    public class MessageTextObject
    {
        public string Value { get; set; } = "";
        public List<MessageAnnotation> Annotations { get; set; } = new();

        public override string ToString()
        {
            return this.Value;
        }
    }
    public class MessageAnnotation
    {
        public string Type { get; set; } = "";
        public string Text { get; set; } = "";
        public int Start_Index { get; set; }
        public int End_Index { get; set; }
        public MessageFileCitation? File_Citation { get; set; }
    }

    public class MessageFileCitation
    {
        public string File_Id { get; set; } = "";
        public string Quote { get; set; } = "";
    }
}
