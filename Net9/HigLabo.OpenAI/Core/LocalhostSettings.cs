namespace HigLabo.OpenAI;

public class LocalhostSettings
{
    public string Url { get; set; } = "";

    public LocalhostSettings(string url)
    {
        this.Url = url;
    }
}
