namespace HigLabo.OpenAI;
public class EvalRunObject
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
    public object? Data_Source { get; set; }
    public object? Error { get; set; }
    public string Eval_Id { get; set; } = "";
    public object? Metadata { get; set; }
    public string Model { get; set; } = "";
    public List<object>? Per_Model_Usage { get; set; }
    public List<object>? Per_Testing_Criteria_Results { get; set; }
    public string Report_Url { get; set; } = "";
    public List<object>? Result_Counts { get; set; }
    public string Status { get; set; } = "";
}
public class EvalRunObjectResponse : RestApiResponse
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
    public object? Data_Source { get; set; }
    public object? Error { get; set; }
    public string Eval_Id { get; set; } = "";
    public object? Metadata { get; set; }
    public string Model { get; set; } = "";
    public List<object>? Per_Model_Usage { get; set; }
    public List<object>? Per_Testing_Criteria_Results { get; set; }
    public string Report_Url { get; set; } = "";
    public List<object>? Result_Counts { get; set; }
    public string Status { get; set; } = "";
}
