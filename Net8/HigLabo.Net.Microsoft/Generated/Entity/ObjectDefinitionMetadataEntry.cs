using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-objectdefinitionmetadataentry?view=graph-rest-1.0
    /// </summary>
    public partial class ObjectDefinitionMetadataEntry
    {
        public enum ObjectDefinitionMetadataEntryObjectDefinitionMetadata
        {
            PropertyNameAccountEnabled,
            PropertyNameSoftDeleted,
            IsSoftDeletionSupported,
            IsSynchronizeAllSupported,
            ConnectorDataStorageRequired,
            Extensions,
            LinkTypeName,
        }

        public ObjectDefinitionMetadataEntryObjectDefinitionMetadata Key { get; set; }
        public string? Value { get; set; }
    }
}
