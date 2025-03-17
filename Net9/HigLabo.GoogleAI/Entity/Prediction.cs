namespace HigLabo.GoogleAI;
public class Prediction
{
    public string MimeType { get; set; } = "";
    public string BytesBase64Encoded { get; set; } = "";

    public Byte[] GetBytes()
    {
        return Convert.FromBase64String(this.BytesBase64Encoded);
    }
    public Stream GetStream()
    {
        return new MemoryStream(Convert.FromBase64String(this.BytesBase64Encoded));
    }
}
