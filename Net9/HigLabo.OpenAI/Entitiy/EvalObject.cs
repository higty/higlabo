namespace HigLabo.OpenAI;
public class EvalObject
{
    public string Id { get; set; } = "";
    public string Object { get; set; } = "";
    public string Name { get; set; } = "";
    public Int64 Created { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
        }
    }
    public object? Metadata { get; set; }
    public List<object>? Testing_Criteria { get; set; } 
}
public class EvalObjectResponse : RestApiResponse
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public Int64 Created { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
        }
    }
    public object? Metadata { get; set; }
    public List<object>? Testing_Criteria { get; set; }
}
