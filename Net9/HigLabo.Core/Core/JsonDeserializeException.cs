namespace HigLabo.Core;

public class JsonDeserializeException : Exception
{
    public JsonDeserializeException(Exception exception, string json)
        : base($"{json}\n\n{exception.Message}", exception)
    {
    }
}
