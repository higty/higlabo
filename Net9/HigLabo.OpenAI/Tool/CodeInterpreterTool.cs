namespace HigLabo.OpenAI;
public class CodeInterpreterTool : Tool
{
    public object? Container { get; set; }

    public CodeInterpreterTool()
        : base("code_interpreter")
    {
    }
}
