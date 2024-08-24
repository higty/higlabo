using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcauditresource?view=graph-rest-1.0
    /// </summary>
    public partial class CloudPcAuditResource
    {
        public string? DisplayName { get; set; }
        public CloudPcAuditProperty[]? ModifiedProperties { get; set; }
        public string? ResourceId { get; set; }
    }
}
