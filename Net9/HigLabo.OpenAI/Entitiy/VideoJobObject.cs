namespace HigLabo.OpenAI;
public class VideoJobError
{
    public string Code { get; set; } = "";
    public string Message { get; set; } = "";
}
public class VideoJobObject
{
    public string Id { get; set; } = "";
    public string Model { get; set; } = "";
    public string Object { get; set; } = "";
    public int Progress { get; set; }
    public string Remixed_From_Video_Id { get; set; } = "";
    public string Seconds { get; set; } = "";
    public string Size { get; set; } = "";
    public string Status { get; set; } = "";
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public Int64 Completed_At { get; set; }
    public DateTimeOffset CompleteTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Completed_At), TimeSpan.Zero);
        }
    }
    public Int64 Expired_At { get; set; }
    public DateTimeOffset ExpireTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expired_At), TimeSpan.Zero);
        }
    }
    public VideoJobError? Error { get; set; }
}
public class VideoJobObjectResponse : RestApiResponse
{
    public string Id { get; set; } = "";
    public string Model { get; set; } = "";
    public int Progress { get; set; }
    public string Remixed_From_Video_Id { get; set; } = "";
    public string Seconds { get; set; } = "";
    public string Size { get; set; } = "";
    public string Status { get; set; } = "";
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public Int64 Completed_At { get; set; }
    public DateTimeOffset CompleteTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Completed_At), TimeSpan.Zero);
        }
    }
    public Int64 Expired_At { get; set; }
    public DateTimeOffset ExpireTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expired_At), TimeSpan.Zero);
        }
    }
    public VideoJobError? Error { get; set; }
}