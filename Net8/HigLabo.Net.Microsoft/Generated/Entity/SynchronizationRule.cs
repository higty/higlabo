using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationrule?view=graph-rest-1.0
    /// </summary>
    public partial class SynchronizationRule
    {
        public bool? Editable { get; set; }
        public string? Id { get; set; }
        public StringKeyStringValuePair[]? Metadata { get; set; }
        public string? Name { get; set; }
        public ObjectMapping[]? ObjectMappings { get; set; }
        public int? Priority { get; set; }
        public string? SourceDirectoryName { get; set; }
        public string? TargetDirectoryName { get; set; }
    }
}
