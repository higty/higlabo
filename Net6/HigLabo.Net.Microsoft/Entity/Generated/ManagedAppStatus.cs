using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedappstatus?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedAppStatus
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
    }
}
