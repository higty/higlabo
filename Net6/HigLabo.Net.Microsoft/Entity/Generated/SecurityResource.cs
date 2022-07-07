using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/securityresource?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityResource
    {
        public enum SecurityResourceSecurityResourceType
        {
            Attacked,
            Related,
        }

        public string? Resource { get; set; }
        public SecurityResourceSecurityResourceType ResourceType { get; set; }
    }
}
