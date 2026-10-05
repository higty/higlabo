namespace HigLabo.OpenAI;
public class Reasoning
{
    public string? Effort { get; set; }
    public string? Mode { get; set; }
    public string? Context { get; set; }
    public string? Summary { get; set; } 

    public override string ToString()
    {
        return $"{this.Effort} {this.Summary}";
    }
    public object GetRequestBody()
    {
        return new
        {
            effort = this.Effort,
            mode = this.Mode,
            context = this.Context,
            summary = this.Summary,
        };
    }
}
