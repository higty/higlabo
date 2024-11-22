using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-attributemapping?view=graph-rest-1.0
/// </summary>
public partial class AttributeMapping
{
    public enum AttributeMappingAttributeFlowBehavior
    {
        FlowWhenChanged,
        FlowAlways,
    }
    public enum AttributeMappingAttributeFlowType
    {
        Always,
        ObjectAddOnly,
        MultiValueAddOnly,
        ValueAddOnly,
        AttributeAddOnly,
    }

    public string? DefaultValue { get; set; }
    public bool? ExportMissingReferences { get; set; }
    public AttributeMappingAttributeFlowBehavior FlowBehavior { get; set; }
    public AttributeMappingAttributeFlowType FlowType { get; set; }
    public Int32? MatchingPriority { get; set; }
    public AttributeMappingSource? Source { get; set; }
    public string? TargetAttributeName { get; set; }
}
