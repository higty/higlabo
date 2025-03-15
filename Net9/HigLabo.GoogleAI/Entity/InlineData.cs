namespace HigLabo.GoogleAI;

public class InlineData
{
    public string MimeType { get; set; } = "";
    public string Data { get; set; } = "";
    public InlineData() { }
    public InlineData(string mimeType, string Data)
    {
        this.MimeType = mimeType;
        this.Data = Data;
    }
    public Byte[] GetBytes()
    {
        return Convert.FromBase64String(this.Data);
    }
    public Stream GetStream()
    {
        return new MemoryStream(Convert.FromBase64String(this.Data));
    }

    public override string ToString()
    {
        return $"{this.MimeType} {this.Data}";
    }
}
