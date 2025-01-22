using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-directorydefinition?view=graph-rest-1.0
/// </summary>
public partial class DirectoryDefinition
{
    public enum DirectoryDefinitionDirectoryDefinitionDiscoverabilities
    {
        None,
        AttributeNames,
        AttributeDataTypes,
        AttributeReadOnly,
        ReferenceAttributes,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public string? Name { get; set; }
    public ObjectDefinition[]? Objects { get; set; }
    public bool? ReadOnly { get; set; }
    public string? Version { get; set; }
    public DateTimeOffset? DiscoveryDateTime { get; set; }
    public DirectoryDefinitionDirectoryDefinitionDiscoverabilities Discoverabilities { get; set; }
}
