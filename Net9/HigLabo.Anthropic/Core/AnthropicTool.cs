using HigLabo.Newtonsoft;
using Newtonsoft.Json;

namespace HigLabo.Anthropic;

public class AnthropicTools : List<AnthropicTool>
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
public class AnthropicTool
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    [JsonConverter(typeof(PreserveCaseJsonConverter))]
    public object? Input_Schema { get; set; }

    public AnthropicTool(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
