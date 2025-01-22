using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-attributedefinition?view=graph-rest-1.0
/// </summary>
public partial class AttributeDefinition
{
    public enum AttributeDefinitionMutability
    {
        ReadWrite,
        ReadOnly,
        Immutable,
        WriteOnly,
    }
    public enum AttributeDefinitionAttributeType
    {
        String,
        Integer,
        Reference,
        Binary,
        Boolean,
        DateTime,
    }

    public bool? Anchor { get; set; }
    public bool? CaseExact { get; set; }
    public string? DefaultValue { get; set; }
    public bool? FlowNullValues { get; set; }
    public AttributeDefinitionMetadataEntry[]? Metadata { get; set; }
    public bool? Multivalued { get; set; }
    public AttributeDefinitionMutability Mutability { get; set; }
    public string? Name { get; set; }
    public bool? Required { get; set; }
    public ReferencedObject[]? ReferencedObjects { get; set; }
    public AttributeDefinitionAttributeType Type { get; set; }
}
