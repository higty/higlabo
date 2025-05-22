namespace HigLabo.OpenAI;
public class Reasoning
{
    public string? Effort { get; set; }
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
            summary = this.Summary,
        };
    }
}
