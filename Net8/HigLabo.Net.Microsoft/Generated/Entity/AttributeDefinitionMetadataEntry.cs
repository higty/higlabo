using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-attributedefinitionmetadataentry?view=graph-rest-1.0
/// </summary>
public partial class AttributeDefinitionMetadataEntry
{
    public enum AttributeDefinitionMetadataEntryAttributeDefinitionMetadata
    {
        BaseAttributeName,
        ComplexObjectDefinition,
        IsContainer,
        IsCustomerDefined,
        IsDomainQualified,
        LinkPropertyNames,
        LinkTypeName,
        MaximumLength,
        ReferencedProperty,
    }

    public AttributeDefinitionMetadataEntryAttributeDefinitionMetadata Key { get; set; }
    public string? Value { get; set; }
}
