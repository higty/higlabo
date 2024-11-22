namespace HigLabo.GoogleAI;

public class FunctionDeclaration
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public object? Parameters { get; set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Description}";
    }
}
