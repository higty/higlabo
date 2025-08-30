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
    public void AddFile(string fileName, string contentType, Stream stream)
    {
        var input = new ResponseInputMessage();
        input.Role = "user";
        input.AddFile(fileName, contentType, stream);
        this.Add(input);
    }
    public void AddImage(string contentType, byte[] data)
    {
        var input = new ResponseInputMessage();
        input.Role = "user";
        input.AddImage(contentType, data);
        this.Add(input);
    }
    public void AddToolCallMessage(ResponseStreamOutputItem.OutputItem toolCall, string output)
    {
        {
            var input = new ResponseToolOutputMessage();
            input.Type = "function_call";
            input.Call_Id = toolCall.Call_Id;
            input.Name = toolCall.Name;
            input.Arguments = toolCall.Arguments;
            this.Add(input);
        }
        {
            var input = new ResponseToolOutputMessage();
            input.Type = "function_call_output";
            input.Call_Id = toolCall.Call_Id;
            input.Output = output;
            this.Add(input);
        }
    }
}
public class ResponseInputMessage 
{
    public List<ResponseInputContent> Content { get; internal set; } = new();
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

    public void AddPngImage(byte[] data)
    {
        this.AddImage("image/png", data);
    }
    public void AddJpegImage(byte[] data)
    {
        this.AddImage("image/jpeg", data);
    }
    public void AddImage(string contentType, byte[] data)
    {
        var content = new ResponseInputContent();
        content.Type = "input_image";
        content.FileName = null;
        content.Image_Url = data.CreateBase64FileString(contentType);
        this.Content.Add(content);
    }

    public void AddFile(string fileName, string contentType, Stream stream)
    {
        this.AddFile(fileName, contentType, stream.ToByteArray());
    }
    public void AddFile(string fileName, string contentType, byte[] data)
    {
        this.AddFile(fileName, data.CreateBase64FileString(contentType));
    }
    public void AddFile(string fileName, string base64EncodedData)
    {
        var content = new ResponseInputContent();
        content.Type = "input_file";
        content.FileName = fileName;
        content.File_Data = base64EncodedData;
        this.Content.Add(content);
    }
}
public class ResponseToolOutputMessage : ResponseInputMessage
{
    public new string? Role { get; private set; } 
    public new object? Content { get; private set; }
    public string? Call_Id { get; set; }
    public string? Name { get; set; }
    public string? Arguments { get; set; }
    public string? Output { get; set; }
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
