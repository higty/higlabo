using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace HigLabo.OpenAI
{
    public interface IChatMessage
    {

    }
    public class ChatMessage : IChatMessage
    {
        public ChatMessageRole Role { get; set; }
        public string Content { get; set; } = "";

        public ChatMessage() { }
        public ChatMessage(ChatMessageRole role, string content)
        {
            this.Role = role;
            this.Content = content;
        }
    }
    public class ChatImageMessage : IChatMessage
    {
        public interface IContent
        {

        }
        public class TextContent : IContent
        {
            public string Type
            {
                get { return "text"; }
            }
            public string Text { get; set; } = "";
            public TextContent() { }
            public TextContent(string text)
            {
                Text = text;
            }
        }
        public class ImageContent : IContent
        {
            public enum DetailType
            {
                Low,
                High,
                Auto,
            }
            public class ImageUrl
            {
                public string Url { get; set; } = "";
                public DetailType? Detail { get; set; }
            }
            public string Type
            {
                get { return "image_url"; }
            }
            public ImageUrl Image_Url { get; set; } = new ImageUrl();

            public ImageContent() { }
            public ImageContent(string imageUrl)
            {
                this.Image_Url.Url = imageUrl;
            }
            public void LoadJpgImage(Stream stream)
            {
                this.LoadImage("image/jpg", stream);
            }
            public void LoadPngImage(Stream stream)
            {
                this.LoadImage("image/png", stream);
            }
            public void LoadGifImage(Stream stream)
            {
                this.LoadImage("image/git", stream);
            }
            public void LoadImageFromFile(string filePath)
            {
                var extension = Path.GetExtension(filePath);
                this.LoadImage($"image/{extension.Replace(".", "").ToLower()}", File.ReadAllBytes(filePath));
            }
            public void LoadImage(string dataType, Stream stream)
            {
                this.LoadImage(dataType, stream.ToByteArray());
            }
            public void LoadImage(string dataType, byte[] data)
            {
                this.Image_Url.Url = $"data:{dataType};base64," + Convert.ToBase64String(data);
            }
        }
        public ChatMessageRole Role { get; set; }
        public List<IContent> Content { get; set; } = new List<IContent>();
    
        public ChatImageMessage(ChatMessageRole role)
        {
            this.Role = role;
        }
        public void AddTextContent(string text)
        {
            this.Content.Add(new TextContent(text));
        }
        public void AddImageContent(string imageUrl)
        {
            this.Content.Add(new ImageContent(imageUrl));
        }
        public void AddImageFile(string filePath)
        {
            var content = new ImageContent(filePath);
            content.LoadImageFromFile(filePath);
            this.Content.Add(content);
        }
    }


}
