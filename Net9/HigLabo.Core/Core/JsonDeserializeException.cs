namespace HigLabo.Core;

public class JsonDeserializeException : Exception
{
    public string Json { get; set; }

    public JsonDeserializeException(Exception exception, string json)
        : base($"{json}\n\n{exception.Message}", exception)
    {
        this.Json = json;
    }

    public JsonDeserializeException(string json, Exception exception)
        : base(json + Environment.NewLine + Environment.NewLine + exception.Message, exception)
    {
        this.Json = json;
    }
}
