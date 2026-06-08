namespace HigLabo.GoogleAI;

public abstract class Tool
{
}
public class GoogleSearchTool : Tool
{
    public object GoogleSearch { get; set; } = new();
}
public class GoogleSearchRetrievalTool : Tool
{
    public object GoogleSearchRetrieval { get; set; } = new();
}
public class Function : Tool
{
    public List<FunctionDeclaration> FunctionDeclarations { get; init; } = new();
}

public abstract class InteractionTool(string type)
{
    public string Type { get; init; } = type;
}
public class InteractionGoogleSearchTool : InteractionTool
{
    public InteractionGoogleSearchTool()
        : base("google_search")
    {
    }
}
public class InteractionCodeExecutionTool : InteractionTool
{
    public InteractionCodeExecutionTool()
        : base("code_execution")
    {
    }
}
public class InteractionUrlContextTool : InteractionTool
{
    public InteractionUrlContextTool()
        : base("url_context")
    {
    }
}
public class InteractionFunctionTool : InteractionTool
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public object? Parameters { get; set; }

    public InteractionFunctionTool()
        : base("function")
    {
    }
}
