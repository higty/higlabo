namespace HigLabo.OpenAI;
public class ImagesGenerationObject
{
    public string Background { get; set; } = "";
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public List<ImageObject> Data { get; set; } = new();
    public string Output_Format { get; set; } = "";
    public string Quality { get; set; } = "";
    public string Size { get; set; } = "";
    public ImageGenerationUsage Usage { get; set; } = new();
}
public class ImagesGenerationObjectRespons: RestApiResponse
{
    public string Background { get; set; } = "";
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public List<ImageObject> Data { get; set; } = new();
    public string Output_Format { get; set; } = "";
    public string Quality { get; set; } = "";
    public string Size { get; set; } = "";
    public ImageGenerationUsage Usage { get; set; } = new();
}
