using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/servicehealth?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceHealth
    {
        public string Id { get; set; }
        public string Service { get; set; }
        public ServiceHealthServiceHealthStatus Status { get; set; }
    }
}
