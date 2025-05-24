namespace HigLabo.OpenAI;
public class ResponseInputItem
{
    public string Id { get; set; } = "";
    public string Type { get; set; } = "";
    public string Role { get; set; } = "";

    public List<ResponseInputItemContentObject> Content { get; set; } = new();

}
public class ResponseInputItemContentObject
{
    public string Type { get; set; } = "";
    public string Text { get; set; } = "";
    public string Refusal { get; set; } = "";
    public List<ResponseInputItemAnnotation>? Annotations { get; set; } = new();
}
public class ResponseInputItemAnnotation : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string File_Id { get; set; } = "";
    public int? Index { get; set; }
    public int? Start_Index { get; set; }
    public int? End_Index { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
}


