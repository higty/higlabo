namespace HigLabo.OpenAI;
public class CodeInterpreterTool : ToolObject
{
    public object? Container { get; set; }

    public CodeInterpreterTool()
        : base("code_interpreter")
    {
    }
}
