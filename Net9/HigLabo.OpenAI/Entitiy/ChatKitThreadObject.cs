using static HigLabo.OpenAI.ChatKitThreadObject;

namespace HigLabo.OpenAI;
public class ChatKitThreadObject
{
    public class ChatKitThreadStatus
    {
        public string Type { get; set; } = "";
        public string Reason { get; set; } = "";
    }
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public string Id { get; set; } = "";
    public string Object { get; set; } = "";
    public ChatKitThreadStatus Status { get; set; } = new ();
    public string Title { get; set; } = "";
    public string User { get; set; } = "";
}
public class ChatKitThreadObjectResponse : RestApiResponse
{
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public string Id { get; set; } = "";
    public ChatKitThreadStatus Status { get; set; } = new();
    public string Title { get; set; } = "";
    public string User { get; set; } = "";
}