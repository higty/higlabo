using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedappoperation?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedAppOperation
    {
        public string DisplayName { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string State { get; set; }
        public string Id { get; set; }
        public string Version { get; set; }
    }
}
