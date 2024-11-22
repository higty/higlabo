using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-post-policies?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationstrengthRootPostPoliciesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_AuthenticationStrengthPolicies: return $"/policies/authenticationStrengthPolicies";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

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
    public enum ApiPath
    {
        Policies_AuthenticationStrengthPolicies,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public AuthenticationMethodModes[]? AllowedCombinations { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
    public AuthenticationStrengthPolicyAuthenticationStrengthPolicyType PolicyType { get; set; }
    public AuthenticationStrengthPolicyAuthenticationStrengthRequirements RequirementsSatisfied { get; set; }
    public AuthenticationCombinationConfiguration[]? CombinationConfigurations { get; set; }
}
public partial class AuthenticationstrengthRootPostPoliciesResponse : RestApiResponse
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
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-post-policies?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-post-policies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthRootPostPoliciesResponse> AuthenticationstrengthRootPostPoliciesAsync()
    {
        var p = new AuthenticationstrengthRootPostPoliciesParameter();
        return await this.SendAsync<AuthenticationstrengthRootPostPoliciesParameter, AuthenticationstrengthRootPostPoliciesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-post-policies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthRootPostPoliciesResponse> AuthenticationstrengthRootPostPoliciesAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationstrengthRootPostPoliciesParameter();
        return await this.SendAsync<AuthenticationstrengthRootPostPoliciesParameter, AuthenticationstrengthRootPostPoliciesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-post-policies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthRootPostPoliciesResponse> AuthenticationstrengthRootPostPoliciesAsync(AuthenticationstrengthRootPostPoliciesParameter parameter)
    {
        return await this.SendAsync<AuthenticationstrengthRootPostPoliciesParameter, AuthenticationstrengthRootPostPoliciesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-post-policies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthRootPostPoliciesResponse> AuthenticationstrengthRootPostPoliciesAsync(AuthenticationstrengthRootPostPoliciesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationstrengthRootPostPoliciesParameter, AuthenticationstrengthRootPostPoliciesResponse>(parameter, cancellationToken);
    }
}
