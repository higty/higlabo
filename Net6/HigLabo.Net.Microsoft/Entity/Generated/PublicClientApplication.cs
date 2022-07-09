using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/publicclientapplication?view=graph-rest-1.0
    /// </summary>
    public partial class PublicClientApplication
    {
        public String[]? RedirectUris { get; set; }
    }
}
