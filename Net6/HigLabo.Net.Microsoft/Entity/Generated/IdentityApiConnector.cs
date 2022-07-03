using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/identityapiconnector?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityApiConnector
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string TargetUrl { get; set; }
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
    }
}
