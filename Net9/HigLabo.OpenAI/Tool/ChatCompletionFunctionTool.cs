namespace HigLabo.OpenAI;
public  class ChatCompletionFunctionTool 
{
    public class FunctionObject
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public object? Parameters { get; set; }
    }

    public string Type { get; set; } = "function";
    public FunctionObject Function { get; set; } = new FunctionObject();

    public ChatCompletionFunctionTool()
    {
    }
    public ChatCompletionFunctionTool(string type)
    {
        Type = type;
    }
}
