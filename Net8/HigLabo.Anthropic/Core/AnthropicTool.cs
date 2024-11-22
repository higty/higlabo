using System.Security;
using System.Text;

namespace HigLabo.Anthropic;

public class AnthropicTools : List<AnthropicTool>
{
    public override string ToString()
    {
        var sb = new StringBuilder(512);
        sb.AppendLine("<tools>");
        foreach (var tool in this)
        {
            sb.AppendLine(tool.ToString());
            sb.AppendLine();
        }
        sb.AppendLine("</tools>");

        return sb.ToString();
    }
}
public class AnthropicTool
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public List<AnthropicToolParameter> Parameters { get; init; } = new();

    public AnthropicTool(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }

    public override string ToString()
    {
        var sb = new StringBuilder(512);
        sb.AppendLine("<tool_description>");
        {
            sb.AppendLine($"<tool_name>{SecurityElement.Escape(this.Name)}</tool_name>");
            sb.AppendLine($"<description>{SecurityElement.Escape(this.Description)}</description>");

            sb.AppendLine("<parameters>");
            foreach (var p in this.Parameters)
            {
                var reader = new StringReader(p.ToString());
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine()!;
                    sb.AppendLine($"\t{line}");
                }
            }
            sb.AppendLine("</parameters>");
        }

        sb.AppendLine("</tool_description>");

        return sb.ToString();
    }
}
public class AnthropicToolParameter
{
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public string Description { get; set; } = "";

    public AnthropicToolParameter(string name, string type, string description)
    {
        Name = name;
        Type = type;
        Description = description;
    }

    public override string ToString()
    {
        var sb = new StringBuilder(256);
        sb.AppendLine("<parameter>");
        {
            sb.AppendLine($"\t<name>{SecurityElement.Escape(this.Name)}</name>");
            sb.AppendLine($"\t<type>{SecurityElement.Escape(this.Type)}</type>");
            sb.AppendLine($"\t<description>{SecurityElement.Escape(this.Description)}</description>");
        }
        sb.AppendLine("</parameter>");
        return sb.ToString();
    }
}
