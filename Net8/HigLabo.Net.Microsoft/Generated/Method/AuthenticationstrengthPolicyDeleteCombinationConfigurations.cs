using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-delete-combinationconfigurations?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationstrengthPolicyDeleteCombinationConfigurationsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AuthenticationStrengthPolicyId { get; set; }
        public string? AuthenticationCombinationConfigurationId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_ConditionalAccess_AuthenticationStrength_Policies_AuthenticationStrengthPolicyId_CombinationConfigurations_AuthenticationCombinationConfigurationId_ref: return $"/identity/conditionalAccess/authenticationStrength/policies/{AuthenticationStrengthPolicyId}/combinationConfigurations/{AuthenticationCombinationConfigurationId}/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Identity_ConditionalAccess_AuthenticationStrength_Policies_AuthenticationStrengthPolicyId_CombinationConfigurations_AuthenticationCombinationConfigurationId_ref,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class AuthenticationstrengthPolicyDeleteCombinationConfigurationsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-delete-combinationconfigurations?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-delete-combinationconfigurations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyDeleteCombinationConfigurationsResponse> AuthenticationstrengthPolicyDeleteCombinationConfigurationsAsync()
    {
        var p = new AuthenticationstrengthPolicyDeleteCombinationConfigurationsParameter();
        return await this.SendAsync<AuthenticationstrengthPolicyDeleteCombinationConfigurationsParameter, AuthenticationstrengthPolicyDeleteCombinationConfigurationsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-delete-combinationconfigurations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyDeleteCombinationConfigurationsResponse> AuthenticationstrengthPolicyDeleteCombinationConfigurationsAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationstrengthPolicyDeleteCombinationConfigurationsParameter();
        return await this.SendAsync<AuthenticationstrengthPolicyDeleteCombinationConfigurationsParameter, AuthenticationstrengthPolicyDeleteCombinationConfigurationsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-delete-combinationconfigurations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyDeleteCombinationConfigurationsResponse> AuthenticationstrengthPolicyDeleteCombinationConfigurationsAsync(AuthenticationstrengthPolicyDeleteCombinationConfigurationsParameter parameter)
    {
        return await this.SendAsync<AuthenticationstrengthPolicyDeleteCombinationConfigurationsParameter, AuthenticationstrengthPolicyDeleteCombinationConfigurationsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-delete-combinationconfigurations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationstrengthPolicyDeleteCombinationConfigurationsResponse> AuthenticationstrengthPolicyDeleteCombinationConfigurationsAsync(AuthenticationstrengthPolicyDeleteCombinationConfigurationsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationstrengthPolicyDeleteCombinationConfigurationsParameter, AuthenticationstrengthPolicyDeleteCombinationConfigurationsResponse>(parameter, cancellationToken);
    }
}
