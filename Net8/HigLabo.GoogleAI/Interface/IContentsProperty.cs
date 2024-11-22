using HigLabo.Core;

namespace HigLabo.GoogleAI;

public interface IContentsProperty
{
    List<Content> Contents { get; }
}
public static class IContentsPropertyExtensions
{
    public static void AddMessage(this IContentsProperty obj, ChatMessageRole role, string text)
    {
        obj.Contents.Add(new Content(role, text));
    }
    public static void AddUserMessage(this IContentsProperty obj, string text)
    {
        obj.Contents.Add(new Content(ChatMessageRole.User, text));
    }
    public static void AddModelMessage(this IContentsProperty obj, string text)
    {
        obj.Contents.Add(new Content(ChatMessageRole.Model, text));
    }

    public static void AddMessage(this IContentsProperty obj, string text, string mimeType, Stream stream)
    {
        obj.AddMessage(text, mimeType, stream.ToByteArray());
    }
    public static void AddMessage(this IContentsProperty obj, string text, string mimeType, byte[] data)
    {
        var content = new Content();
        content.Parts.Add(new ContentPart(text));

        var part = new ContentPart();
        part.InlineData = new InlineData(mimeType, Convert.ToBase64String(data));
        content.Parts.Add(part);
        obj.Contents.Add(content);
    }
}
