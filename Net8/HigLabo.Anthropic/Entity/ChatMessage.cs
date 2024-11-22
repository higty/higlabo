using HigLabo.Core;

namespace HigLabo.Anthropic;

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
        public class ImageSource
        {
            public string Type { get; set; } = "base64";
            public string Media_Type { get; set; } = "";
            public string Data { get; set; } = "";
        }
        public string Type
        {
            get { return "image"; }
        }
        public ImageSource Source { get; set; } = new();

        public ImageContent() { }

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
            var extension = Path.GetExtension(filePath).Replace(".", "").ToLower();
            if (string.Equals(extension, "jpg", StringComparison.OrdinalIgnoreCase))
            {
                extension = "jpeg";
            }
            this.LoadImage($"image/{extension}", File.ReadAllBytes(filePath));
        }
        public void LoadImage(string mediaType, Stream stream)
        {
            this.LoadImage(mediaType, stream.ToByteArray());
        }
        public void LoadImage(string mediaType, byte[] data)
        {
            if (this.Source.Media_Type.IsNullOrEmpty())
            {
                this.Source.Media_Type = mediaType;
            }
            this.Source.Data = Convert.ToBase64String(data);
        }
    }
    public ChatMessageRole Role { get; set; }
    public List<IContent> Content { get; set; } = new();

    public ChatImageMessage(ChatMessageRole role)
    {
        this.Role = role;
    }
    public void AddTextContent(string text)
    {
        this.Content.Add(new TextContent(text));
    }
    public void AddImageFile(string filePath)
    {
        var content = new ImageContent();
        content.LoadImageFromFile(filePath);
        this.Content.Add(content);
    }
}
