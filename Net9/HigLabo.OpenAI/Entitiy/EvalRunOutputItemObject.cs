namespace HigLabo.OpenAI;
public class EvalRunOutputItemObject
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
    public object? DataSource_Item { get; set; }
    public int DataSource_Item_Id{ get; set; }
    public string Eval_Id { get; set; } = "";
    public object? Metadata { get; set; }
    public List<object>? Results { get; set; }
    public string Run_Id { get; set; } = "";
    public object? Sample { get; set; }
    public string Status { get; set; } = "";
}
public class EvalRunOutputItemObjectResponse : RestApiResponse
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
    public object? DataSource_Item { get; set; }
    public int DataSource_Item_Id { get; set; }
    public string Eval_Id { get; set; } = "";
    public object? Metadata { get; set; }
    public List<object>? Results { get; set; }
    public string Run_Id { get; set; } = "";
    public object? Sample { get; set; }
    public string Status { get; set; } = "";
}
