using HigLabo.Newtonsoft;
using Newtonsoft.Json;

namespace HigLabo.OpenAI;

public class NamespaceTool : Tool
{
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public List<Tool> Tools { get; set; } = new();
    public NamespaceTool() : base("namespace") { }
}

public class ToolSearchTool : Tool
{
    public string? Execution { get; set; }
    public string? Description { get; set; }
    [JsonConverter(typeof(PreserveCaseJsonConverter))]
    public object? Parameters { get; set; }
    public ToolSearchTool() : base("tool_search") { }
}

public class CustomTool : Tool
{
    public bool? Async { get; set; }
    public bool? Defer_Loading { get; set; }
    public List<string>? Allowed_Callers { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public object? Format { get; set; }
    public CustomTool() : base("custom") { }
}

public class ComputerTool : Tool
{
    public ComputerTool() : base("computer") { }
}

public class ShellTool : Tool
{
    public List<string>? Allowed_Callers { get; set; }
    public object? Environment { get; set; }
    public ShellTool() : base("shell") { }
}

public class ApplyPatchTool : Tool
{
    public List<string>? Allowed_Callers { get; set; }
    public ApplyPatchTool() : base("apply_patch") { }
}

public class ImageGenerationTool : Tool
{
    public string? Model { get; set; }
    public string? Action { get; set; }
    public string? Background { get; set; }
    public string? Complexity { get; set; }
    public int? Frame_Count { get; set; }
    public int? Frame_Duration_Ms { get; set; }
    public ImageSvgOptions? Svg { get; set; }
    public string? Input_Fidelity { get; set; }
    public object? Input_Image_Mask { get; set; }
    public string? Moderation { get; set; }
    public int? Output_Compression { get; set; }
    public string? Output_Format { get; set; }
    public int? Partial_Images { get; set; }
    public string? Quality { get; set; }
    public string? Size { get; set; }
    public ImageGenerationTool() : base("image_generation") { }
}
