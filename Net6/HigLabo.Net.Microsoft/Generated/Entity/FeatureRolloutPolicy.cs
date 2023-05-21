using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/featurerolloutpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class FeatureRolloutPolicy
    {
        public enum FeatureRolloutPolicystring
        {
            PassthroughAuthentication,
            SeamlessSso,
            PasswordHashSync,
            EmailAsAlternateId,
            UnknownFutureValue,
        }

        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public FeatureRolloutPolicystring Feature { get; set; }
        public string? Id { get; set; }
        public bool? IsAppliedToOrganization { get; set; }
        public bool? IsEnabled { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
}
