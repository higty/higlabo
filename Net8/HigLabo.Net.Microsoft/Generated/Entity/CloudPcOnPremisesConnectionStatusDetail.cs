using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudpconpremisesconnectionstatusdetail?view=graph-rest-1.0
    /// </summary>
    public partial class CloudPcOnPremisesConnectionStatusDetail
    {
        public DateTimeOffset? EndDateTime { get; set; }
        public CloudPcOnPremisesConnectionHealthCheck[]? HealthChecks { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
    }
}
