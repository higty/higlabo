namespace HigLabo.OpenAI;
public class McpCallTool : Tool
{
    public string? Server_Label { get; set; }
    public string? Server_Url { get; set; }
    public string? Require_Approval { get; set; }
    public McpCallTool()
        : base("mcp")
    {
    }
}
