using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-auditing-auditactor?view=graph-rest-1.0
    /// </summary>
    public partial class AuditActor
    {
        public string Type { get; set; }
        public String[] UserPermissions { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationDisplayName { get; set; }
        public string UserPrincipalName { get; set; }
        public string ServicePrincipalName { get; set; }
        public string IpAddress { get; set; }
        public string UserId { get; set; }
    }
}
