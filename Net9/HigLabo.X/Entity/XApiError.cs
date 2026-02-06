namespace HigLabo.X;

public class XApiError
{
    public string Message { get; set; } = "";
    public string Resource_Type { get; set; } = "";
    public string Field { get; set; } = "";
    public string Value { get; set; } = "";
    public string Type { get; set; } = "";
    public string Detail { get; set; } = "";
    public string Title { get; set; } = "";
    public List<string> Parameters { get; set; } = new();
}
