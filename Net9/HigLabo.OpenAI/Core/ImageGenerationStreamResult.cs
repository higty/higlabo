using HigLabo.Core;

namespace HigLabo.OpenAI;
public class ImageGenerationStreamResult
{
    public List<ImageGenerationStreamEvent> EventList { get; init; } = new();
}
public class ImageGenerationStreamEventName
{
    public const string ImageGenerationPartialImage = "image_generation.partial_image";
    public const string ImageGenerationCompleted = "image_generation.completed";
    public const string ImageEditPartialImage = "image_edit.partial_image";
    public const string ImageEditCompleted = "image_edit.completed";
}
public class ImageGenerationStreamEvent
{
    public string EventName { get; set; } = "";
    public string Data { get; set; } = "";

    public ImageGenerationStreamEvent(string eventName, string data)
    {
        this.EventName = eventName;
        this.Data = data;
    }
    public IImageGenerationStreamEvent CreateTypedData()
    {
        switch (this.EventName)
        {
            case ImageGenerationStreamEventName.ImageGenerationPartialImage: return OpenAIClient.JsonConverter.DeserializeObject<ImageGenerationStreamPartialImage>(this.Data)!;
            case ImageGenerationStreamEventName.ImageGenerationCompleted: return OpenAIClient.JsonConverter.DeserializeObject<ImageGenerationStreamCompleted>(this.Data)!;
            case ImageGenerationStreamEventName.ImageEditPartialImage: return OpenAIClient.JsonConverter.DeserializeObject<ImageGenerationStreamPartialImage>(this.Data)!;
            case ImageGenerationStreamEventName.ImageEditCompleted: return OpenAIClient.JsonConverter.DeserializeObject<ImageGenerationStreamCompleted>(this.Data)!;
            default: throw SwitchStatementNotImplementException.Create(this.EventName);
        }
    }
}
public interface IImageGenerationStreamEvent
{
    string Type { get; }
}
public class ImageGenerationStreamPartialImage : IImageGenerationStreamEvent
{
    public string B64_Json { get; set; } = "";
    public string Background { get; set; } = "";
    public int Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public string Output_Format { get; set; } = "";
    public int Partial_Image_Index { get; set; }
    public string Quality { get; set; } = "";
    public string Size { get; set; } = "";
    public string Type { get; set; } = "";

    public Byte[] GetBytes()
    {
        return Convert.FromBase64String(this.B64_Json);
    }
}
public class ImageGenerationStreamCompleted : IImageGenerationStreamEvent
{
    public string B64_Json { get; set; } = "";
    public string Background { get; set; } = "";
    public int Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public string Output_Format { get; set; } = "";
    public string Quality { get; set; } = "";
    public string Size { get; set; } = "";
    public string Type { get; set; } = "";
    public ImageGenerationUsage Usage { get; set; } = new();

    public Byte[] GetBytes()
    {
        return Convert.FromBase64String(this.B64_Json);
    }
}
