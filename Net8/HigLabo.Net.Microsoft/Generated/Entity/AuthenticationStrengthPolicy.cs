using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/authenticationstrengthpolicy?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationStrengthPolicy
{
    public enum AuthenticationStrengthPolicyAuthenticationStrengthPolicyType
    {
        BuiltIn,
        Custom,
        UnknownFutureValue,
        Eq,
        Ne,
        Not,
        In,
    }
    public enum AuthenticationStrengthPolicyAuthenticationStrengthRequirements
    {
        None,
        Mfa,
        UnknownFutureValue,
    }

    public AuthenticationMethodModes[]? AllowedCombinations { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
    public AuthenticationStrengthPolicyAuthenticationStrengthPolicyType PolicyType { get; set; }
    public AuthenticationStrengthPolicyAuthenticationStrengthRequirements RequirementsSatisfied { get; set; }
    public AuthenticationCombinationConfiguration[]? CombinationConfigurations { get; set; }
}
