using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-post-combinationconfigurations?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationstrengthPolicyPostCombinationConfigurationsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AuthenticationStrengthPolicyId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_ConditionalAccess_AuthenticationStrength_Policies_AuthenticationStrengthPolicyId_CombinationConfigurations: return $"/identity/conditionalAccess/authenticationStrength/policies/{AuthenticationStrengthPolicyId}/combinationConfigurations";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Identity_ConditionalAccess_AuthenticationStrength_Policies_AuthenticationStrengthPolicyId_CombinationConfigurations,
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
    public AuthenticationMethodModes[]? AppliesToCombinations { get; set; }
    public String[]? AllowedAAGUIDs { get; set; }
    public string? Id { get; set; }
}
public partial class AuthenticationstrengthPolicyPostCombinationConfigurationsResponse : RestApiResponse
{
    public String[]? AllowedAAGUIDs { get; set; }
    public AuthenticationMethodModes[]? AppliesToCombinations { get; set; }
    public string? Id { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-post-combinationconfigurations?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-post-combinationconfigurations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyPostCombinationConfigurationsResponse> AuthenticationstrengthPolicyPostCombinationConfigurationsAsync()
    {
        var p = new AuthenticationstrengthPolicyPostCombinationConfigurationsParameter();
        return await this.SendAsync<AuthenticationstrengthPolicyPostCombinationConfigurationsParameter, AuthenticationstrengthPolicyPostCombinationConfigurationsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-post-combinationconfigurations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyPostCombinationConfigurationsResponse> AuthenticationstrengthPolicyPostCombinationConfigurationsAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationstrengthPolicyPostCombinationConfigurationsParameter();
        return await this.SendAsync<AuthenticationstrengthPolicyPostCombinationConfigurationsParameter, AuthenticationstrengthPolicyPostCombinationConfigurationsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-post-combinationconfigurations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyPostCombinationConfigurationsResponse> AuthenticationstrengthPolicyPostCombinationConfigurationsAsync(AuthenticationstrengthPolicyPostCombinationConfigurationsParameter parameter)
    {
        return await this.SendAsync<AuthenticationstrengthPolicyPostCombinationConfigurationsParameter, AuthenticationstrengthPolicyPostCombinationConfigurationsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-post-combinationconfigurations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyPostCombinationConfigurationsResponse> AuthenticationstrengthPolicyPostCombinationConfigurationsAsync(AuthenticationstrengthPolicyPostCombinationConfigurationsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationstrengthPolicyPostCombinationConfigurationsParameter, AuthenticationstrengthPolicyPostCombinationConfigurationsResponse>(parameter, cancellationToken);
    }
}
