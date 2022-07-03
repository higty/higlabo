using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/socialidentityprovider?view=graph-rest-1.0
    /// </summary>
    public partial class SocialIdentityProvider
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string IdentityProviderType { get; set; }
    }
}
