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

    public override string ToString()
    {
        return $"{this.MimeType} {this.Data}";
    }
}
