using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationschema?view=graph-rest-1.0
    /// </summary>
    public partial class SynchronizationSchema
    {
        public string? Id { get; set; }
        public SynchronizationRule[]? SynchronizationRules { get; set; }
        public string? Version { get; set; }
        public DirectoryDefinition[]? Directories { get; set; }
    }
}
