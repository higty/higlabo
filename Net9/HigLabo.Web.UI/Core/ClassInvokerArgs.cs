namespace HigLabo.Web;

public class ClassInvokerArgs
{
    public string ClassName { get; } = "";
    public string Selector { get; } = "";
    public string FunctionName { get; } = "";
    public object? Args { get; } = null;

    public ClassInvokerArgs() { }
    public ClassInvokerArgs(string className, string selector, string functionName, object args)
    {
        ClassName = className;
        Selector = selector;
        FunctionName = functionName;
        Args = args;
    }
}
