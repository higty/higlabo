using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationmetadataentry?view=graph-rest-1.0
    /// </summary>
    public partial class SynchronizationMetadataEntry
    {
        public enum SynchronizationMetadataEntrySynchronizationMetadata
        {
            GalleryApplicationIdentifier,
            GalleryApplicationKey,
            IsOAuthEnabled,
            IsSynchronizationAgentAssignmentRequired,
            IsSynchronizationAgentRequired,
            IsSynchronizationInPreview,
            OAuthSettings,
            SynchronizationLearnMoreIbizaFwLink,
            ConfigurationFields,
        }

        public SynchronizationMetadataEntrySynchronizationMetadata Key { get; set; }
        public string? Value { get; set; }
    }
}
