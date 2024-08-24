using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/appconsentapprovalroute?view=graph-rest-1.0
    /// </summary>
    public partial class AppConsentApprovalRoute
    {
        public AppConsentRequest[]? AppConsentRequests { get; set; }
    }
}
