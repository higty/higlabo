using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-get?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationcombinationConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Identity_ConditionalAccess_AuthenticationStrength_Policies_AuthenticationStrengthPolicyId_CombinationConfigurations_AuthenticationCombinationConfigurationId: return $"/identity/conditionalAccess/authenticationStrength/policies/{AuthenticationStrengthPolicyId}/combinationConfigurations/{AuthenticationCombinationConfigurationId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Identity_ConditionalAccess_AuthenticationStrength_Policies_AuthenticationStrengthPolicyId_CombinationConfigurations_AuthenticationCombinationConfigurationId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class AuthenticationcombinationConfigurationGetResponse : RestApiResponse
{
    public AuthenticationMethodModes[]? AppliesToCombinations { get; set; }
    public string? Id { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcombinationConfigurationGetResponse> AuthenticationcombinationConfigurationGetAsync()
    {
        var p = new AuthenticationcombinationConfigurationGetParameter();
        return await this.SendAsync<AuthenticationcombinationConfigurationGetParameter, AuthenticationcombinationConfigurationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcombinationConfigurationGetResponse> AuthenticationcombinationConfigurationGetAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationcombinationConfigurationGetParameter();
        return await this.SendAsync<AuthenticationcombinationConfigurationGetParameter, AuthenticationcombinationConfigurationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcombinationConfigurationGetResponse> AuthenticationcombinationConfigurationGetAsync(AuthenticationcombinationConfigurationGetParameter parameter)
    {
        return await this.SendAsync<AuthenticationcombinationConfigurationGetParameter, AuthenticationcombinationConfigurationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcombinationConfigurationGetResponse> AuthenticationcombinationConfigurationGetAsync(AuthenticationcombinationConfigurationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationcombinationConfigurationGetParameter, AuthenticationcombinationConfigurationGetResponse>(parameter, cancellationToken);
    }
}
