namespace HigLabo.GoogleAI;

public abstract class Tool
{
}
public class GoogleSearchRetrievalTool : Tool
{
    public object GoogleSearchRetrieval { get; set; } = new();
}
public class Function : Tool
{
    public List<FunctionDeclaration> FunctionDeclarations { get; init; } = new();
}
