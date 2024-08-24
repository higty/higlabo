using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/socialidentitysource?view=graph-rest-1.0
    /// </summary>
    public partial class SocialIdentitySource
    {
        public enum SocialIdentitySourceSocialIdentitySourceType
        {
            Facebook,
            UnknownFutureValue,
        }

        public string? DisplayName { get; set; }
        public SocialIdentitySourceSocialIdentitySourceType SocialIdentitySourceType { get; set; }
    }
}
