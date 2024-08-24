using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-objectmappingmetadataentry?view=graph-rest-1.0
    /// </summary>
    public partial class ObjectMappingMetadataEntry
    {
        public enum ObjectMappingMetadataEntryObjectMappingMetadata
        {
            EscrowBehavior,
            DisableMonitoringForChanges,
            OriginalJoiningProperty,
            Disposition,
            IsCustomerDefined,
            ExcludeFromReporting,
            Unsynchronized,
        }

        public ObjectMappingMetadataEntryObjectMappingMetadata Key { get; set; }
        public string? Value { get; set; }
    }
}
