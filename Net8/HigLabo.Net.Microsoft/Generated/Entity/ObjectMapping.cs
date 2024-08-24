using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-objectmapping?view=graph-rest-1.0
    /// </summary>
    public partial class ObjectMapping
    {
        public AttributeMapping[]? AttributeMappings { get; set; }
        public bool? Enabled { get; set; }
        public ObjectFlowTypes? FlowTypes { get; set; }
        public ObjectMappingMetadataEntry[]? Metadata { get; set; }
        public string? Name { get; set; }
        public Filter? Scope { get; set; }
        public string? SourceObjectName { get; set; }
        public string? TargetObjectName { get; set; }
    }
}
