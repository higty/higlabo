using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-oauthapplicationevidence?view=graph-rest-1.0
    /// </summary>
    public partial class OauthApplicationEvidence
    {
        public string? AppId { get; set; }
        public string? DisplayName { get; set; }
        public string? ObjectId { get; set; }
        public string? Publisher { get; set; }
    }
}
