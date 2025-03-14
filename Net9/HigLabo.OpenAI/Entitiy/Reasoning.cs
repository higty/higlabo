namespace HigLabo.OpenAI;
public class Reasoning
{
    public string? Effort { get; set; }
    public string? Generate_Summary { get; set; } 

    public override string ToString()
    {
        return $"{this.Effort} {this.Generate_Summary}";
    }
}
