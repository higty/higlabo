using HigLabo.Newtonsoft;
using Newtonsoft.Json;

namespace HigLabo.GoogleAI;

public class FunctionDeclaration
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    [JsonConverter(typeof(PreserveCaseJsonConverter))]
    public object? Parameters { get; set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Description}";
    }
}
