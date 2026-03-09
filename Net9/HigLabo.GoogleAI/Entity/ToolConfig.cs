namespace HigLabo.GoogleAI;

public class ToolConfig
{
    public FunctionCallingConfig? FunctionCallingConfig { get; set; }
}
public class FunctionCallingConfig
{
    public FunctionCallingMode? Mode { get; set; }
    public List<string>? AllowedFunctionNames { get; set; }
}
