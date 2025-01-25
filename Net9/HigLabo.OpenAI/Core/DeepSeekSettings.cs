namespace HigLabo.OpenAI;
public class DeepSeekSettings
{
    public string ApiKey { get; set; } = "";

    public DeepSeekSettings() { }
    public DeepSeekSettings(string apiKey)
    {
        this.ApiKey = apiKey;
    }
}
