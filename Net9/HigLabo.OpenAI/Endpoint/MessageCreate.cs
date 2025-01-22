using HigLabo.OpenAI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public partial class MessageCreateParameter
{
    public void AddTextMessage(string text)
    {
        this.Content.Add(new MessageCreateContent(text));
    }
    public void AddImageFile(string fileId)
    {
        this.Content.Add(new MessageCreateContent(new MessageCreateContentImageFile(fileId)));
    }
    public void AddImageUrl(string url)
    {
        this.Content.Add(new MessageCreateContent(new MessageCreateContentImageUrl(url)));
    }
}
public enum MessageCreateContentType
{
    Text,
    Image_File,
    Image_Url,
}
public class MessageCreateContent
{
    public MessageCreateContentType Type { get; set; } = MessageCreateContentType.Text;
    public string? Text { get; set; }
    [JsonProperty("image_file")]
    public MessageCreateContentImageFile? Image_File { get; set; }
    [JsonProperty("image_url")]
    public MessageCreateContentImageUrl? Image_Url { get; set; }

    public MessageCreateContent()
    {
    }
    public MessageCreateContent(string text)
    {
        this.Type = MessageCreateContentType.Text;
        this.Text = text;
    }
    public MessageCreateContent(MessageCreateContentImageFile image)
    {
        this.Type = MessageCreateContentType.Image_File;
        this.Image_File = image;
    }
    public MessageCreateContent(MessageCreateContentImageUrl image)
    {
        this.Type = MessageCreateContentType.Image_Url;
        this.Image_Url = image;
    }

    public override string ToString()
    {
        switch (this.Type)
        {
            case MessageCreateContentType.Text: return this.Text ?? "";
            case MessageCreateContentType.Image_File: return this.Image_File?.ToString() ?? "";
            case MessageCreateContentType.Image_Url: return this.Image_Url?.ToString() ?? "";
            default: throw new InvalidOperationException();
        }
    }
}
public class MessageCreateContentImageFile
{
    public string File_Id { get; set; } = "";

    public MessageCreateContentImageFile(string fileId)
    {
        this.File_Id = fileId;
    }
    public override string ToString()
    {
        return this.File_Id; 
    }
}
public class MessageCreateContentImageUrl
{
    public string Url { get; set; } = "";

    public MessageCreateContentImageUrl(string url)
    {
        this.Url = url;
    }
    public override string ToString()
    {
        return this.Url;
    }
}

public partial class OpenAIClient
{
    public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, string text)
    {
        var p = new MessageCreateParameter();
        p.Thread_Id = thread_Id;
        p.Role = role;
        p.Content.Add(new MessageCreateContent(text));
        return await this.MessageCreateAsync(p, CancellationToken.None);
    }
    public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, string text, CancellationToken cancellationToken)
    {
        var p = new MessageCreateParameter();
        p.Thread_Id = thread_Id;
        p.Role = role;
        p.Content.Add(new MessageCreateContent(text));
        return await this.MessageCreateAsync(p, cancellationToken);
    }
    public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, MessageCreateContentImageFile image)
    {
        var p = new MessageCreateParameter();
        p.Thread_Id = thread_Id;
        p.Role = role;
        p.Content.Add(new MessageCreateContent(image));
        return await this.MessageCreateAsync(p, CancellationToken.None);
    }
    public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, MessageCreateContentImageFile image, CancellationToken cancellationToken)
    {
        var p = new MessageCreateParameter();
        p.Thread_Id = thread_Id;
        p.Role = role;
        p.Content.Add(new MessageCreateContent(image));
        return await this.MessageCreateAsync(p, cancellationToken);
    }
    public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, MessageCreateContentImageUrl image)
    {
        var p = new MessageCreateParameter();
        p.Thread_Id = thread_Id;
        p.Role = role;
        p.Content.Add(new MessageCreateContent(image));
        return await this.MessageCreateAsync(p, CancellationToken.None);
    }
    public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, MessageCreateContentImageUrl image, CancellationToken cancellationToken)
    {
        var p = new MessageCreateParameter();
        p.Thread_Id = thread_Id;
        p.Role = role;
        p.Content.Add(new MessageCreateContent(image));
        return await this.MessageCreateAsync(p, cancellationToken);
    }
}