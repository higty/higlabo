using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/appconsentrequest?view=graph-rest-1.0
    /// </summary>
    public partial class AppConsentRequest
    {
        public string? AppDisplayName { get; set; }
        public string? AppId { get; set; }
        public string? Id { get; set; }
        public AppConsentRequestScope[]? PendingScopes { get; set; }
    }
}
