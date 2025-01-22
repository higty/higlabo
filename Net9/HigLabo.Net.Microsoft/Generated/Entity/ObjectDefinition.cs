using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-objectdefinition?view=graph-rest-1.0
/// </summary>
public partial class ObjectDefinition
{
    public AttributeDefinition[]? Attributes { get; set; }
    public ObjectDefinitionMetadataEntry[]? Metadata { get; set; }
    public string? Name { get; set; }
    public String[]? SupportedApis { get; set; }
}
