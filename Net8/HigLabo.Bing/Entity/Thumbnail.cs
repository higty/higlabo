namespace HigLabo.Bing;

public class Thumbnail
{
    public string Url { get; set; } = "";
    public override string ToString()
    {
        return this.Url;
    }
}
