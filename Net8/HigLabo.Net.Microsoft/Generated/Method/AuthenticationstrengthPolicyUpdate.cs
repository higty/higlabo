using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-update?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationstrengthPolicyUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AuthenticationStrengthPolicyId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_AuthenticationStrengthPolicies_AuthenticationStrengthPolicyId: return $"/policies/authenticationStrengthPolicies/{AuthenticationStrengthPolicyId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Policies_AuthenticationStrengthPolicies_AuthenticationStrengthPolicyId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
}
public partial class AuthenticationstrengthPolicyUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyUpdateResponse> AuthenticationstrengthPolicyUpdateAsync()
    {
        var p = new AuthenticationstrengthPolicyUpdateParameter();
        return await this.SendAsync<AuthenticationstrengthPolicyUpdateParameter, AuthenticationstrengthPolicyUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyUpdateResponse> AuthenticationstrengthPolicyUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationstrengthPolicyUpdateParameter();
        return await this.SendAsync<AuthenticationstrengthPolicyUpdateParameter, AuthenticationstrengthPolicyUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyUpdateResponse> AuthenticationstrengthPolicyUpdateAsync(AuthenticationstrengthPolicyUpdateParameter parameter)
    {
        return await this.SendAsync<AuthenticationstrengthPolicyUpdateParameter, AuthenticationstrengthPolicyUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyUpdateResponse> AuthenticationstrengthPolicyUpdateAsync(AuthenticationstrengthPolicyUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationstrengthPolicyUpdateParameter, AuthenticationstrengthPolicyUpdateResponse>(parameter, cancellationToken);
    }
}
