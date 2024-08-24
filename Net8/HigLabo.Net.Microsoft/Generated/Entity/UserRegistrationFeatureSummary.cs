using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/userregistrationfeaturesummary?view=graph-rest-1.0
    /// </summary>
    public partial class UserRegistrationFeatureSummary
    {
        public enum UserRegistrationFeatureSummaryIncludedUserRoles
        {
            All,
            PrivilegedAdmin,
            Admin,
            User,
            UnknownFutureValue,
        }
        public enum UserRegistrationFeatureSummaryIncludedUserTypes
        {
            All,
            Member,
            Guest,
            UnknownFutureValue,
        }

        public Int64? TotalUserCount { get; set; }
        public UserRegistrationFeatureCount[]? UserRegistrationFeatureCounts { get; set; }
        public UserRegistrationFeatureSummaryIncludedUserRoles UserRoles { get; set; }
        public UserRegistrationFeatureSummaryIncludedUserTypes UserTypes { get; set; }
    }
}
