using HigLabo.Core;

namespace HigLabo.OpenAI;
public enum ResponseInputRole
{
    User,
    Assistant,
    System,
    Developer,
}
public class ResponseInput : List<ResponseInputMessage>
{
    public void AddUserMessage(string text)
    {
        this.AddMessage(ResponseInputRole.User, text);
    }
    public void AddMessage(ResponseInputRole role, string text)
    {
        var input = new ResponseInputMessage();
        input.Role = role.ToStringFromEnum().ToLower();
        var content = new ResponseInputContent();
        content.Type = "input_text";
        content.Text = text;
        input.Content.Add(content);
        this.Add(input);
    }
}
public class ResponseInputMessage
{
    public List<ResponseInputContent> Content { get; init; } = new();
    public string Role { get; set; } = "";
    public string? Type { get; set; }

    public void AddImage(string imageUrl)
    {
        var content = new ResponseInputContent();
        content.Type = "input_image";
        content.Image_Url = imageUrl;
        this.Content.Add(content);
    }
    public void AddFile(string fileId)
    {
        var content = new ResponseInputContent();
        content.Type = "input_file";
        content.File_Id = fileId;
        this.Content.Add(content);
    }
    public void AddFile(string fileName, string base64EncodedData)
    {
        var content = new ResponseInputContent();
        content.Type = "input_file";
        content.FileName = fileName;
        content.File_Data = base64EncodedData;
        this.Content.Add(content);
    }
    public void AddFile(string fileName, Stream stream)
    {
        this.AddFile(fileName, stream.ToByteArray());
    }
    public void AddFile(string fileName, byte[] data)
    {
        this.AddFile(fileName, $"data:text/plain;base64," + Convert.ToBase64String(data));
    }
}
public class ResponseInputContent
{
    public string Type { get; set; } = "";
    public string? Text { get; set; }
    public string? File_Id { get; set; }
    public string? FileName { get; set; }
    public string? File_Data { get; set; }
    public string? Image_Url { get; set; }
    public string? Detail { get; set; }
}
