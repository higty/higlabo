using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/useridentity?view=graph-rest-1.0
    /// </summary>
    public partial class UserIdentity
    {
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public string IpAddress { get; set; }
        public string UserPrincipalName { get; set; }
    }
}
