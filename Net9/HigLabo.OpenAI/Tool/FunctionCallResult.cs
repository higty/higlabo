namespace HigLabo.OpenAI;

public class FunctionCallResult
{
    public string Name { get; set; } = "";
    public string Arguments { get; set; } = "";

    public override string ToString()
    {
        if (string.IsNullOrEmpty(this.Arguments))
        {
            return this.Name;
        }
        return $"{this.Name} {this.Arguments}";
    }
}
