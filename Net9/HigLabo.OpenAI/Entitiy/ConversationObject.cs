namespace HigLabo.OpenAI;
public class ConversationObject
{
    public string Id { get; set; } = "";
    public string Object { get; set; } = "";
    public Int64 Created { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
        }
    }
}
public class ConversationObjectResponse : RestApiResponse
{
    public string Id { get; set; } = "";
    public Int64 Created { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
        }
    }
}