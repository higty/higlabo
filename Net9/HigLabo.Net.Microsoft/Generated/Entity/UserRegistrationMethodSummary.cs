using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/userregistrationmethodsummary?view=graph-rest-1.0
/// </summary>
public partial class UserRegistrationMethodSummary
{
    public enum UserRegistrationMethodSummaryIncludedUserRoles
    {
        All,
        PrivilegedAdmin,
        Admin,
        User,
        UnknownFutureValue,
    }
    public enum UserRegistrationMethodSummaryIncludedUserTypes
    {
        All,
        Member,
        Guest,
        UnknownFutureValue,
    }

    public Int64? TotalUserCount { get; set; }
    public UserRegistrationMethodCount[]? UserRegistrationMethodCounts { get; set; }
    public UserRegistrationMethodSummaryIncludedUserRoles UserRoles { get; set; }
    public UserRegistrationMethodSummaryIncludedUserTypes UserTypes { get; set; }
}
