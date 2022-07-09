using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/appidentity?view=graph-rest-1.0
    /// </summary>
    public partial class AppIdentity
    {
        public string? AppId { get; set; }
        public string? DisplayName { get; set; }
        public string? ServicePrincipalId { get; set; }
        public string? ServicePrincipalName { get; set; }
    }
}
