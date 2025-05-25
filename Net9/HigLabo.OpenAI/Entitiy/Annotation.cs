namespace HigLabo.OpenAI.Entitiy;
public class Annotation : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string File_Id { get; set; } = "";
    public int? Index { get; set; }
    public int? Start_Index { get; set; }
    public int? End_Index { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
}
