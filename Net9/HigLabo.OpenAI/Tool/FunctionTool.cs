namespace HigLabo.OpenAI;
public  class FunctionTool : ToolObject
{
    public FunctionObject? Function { get; set; }

    public FunctionTool()
        : base("function")
    {
    }
}
