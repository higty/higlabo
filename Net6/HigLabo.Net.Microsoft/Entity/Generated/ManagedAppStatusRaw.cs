using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedappstatusraw?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedAppStatusRaw
    {
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public string Version { get; set; }
        public Json? Content { get; set; }
    }
}
