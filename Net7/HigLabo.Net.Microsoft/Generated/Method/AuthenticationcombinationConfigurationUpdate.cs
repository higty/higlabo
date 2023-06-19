using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationcombinationConfigurationUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public AuthenticationMethodModes[]? AppliesToCombinations { get; set; }
    }
    public partial class AuthenticationcombinationConfigurationUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcombinationConfigurationUpdateResponse> AuthenticationcombinationConfigurationUpdateAsync()
        {
            var p = new AuthenticationcombinationConfigurationUpdateParameter();
            return await this.SendAsync<AuthenticationcombinationConfigurationUpdateParameter, AuthenticationcombinationConfigurationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcombinationConfigurationUpdateResponse> AuthenticationcombinationConfigurationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationcombinationConfigurationUpdateParameter();
            return await this.SendAsync<AuthenticationcombinationConfigurationUpdateParameter, AuthenticationcombinationConfigurationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcombinationConfigurationUpdateResponse> AuthenticationcombinationConfigurationUpdateAsync(AuthenticationcombinationConfigurationUpdateParameter parameter)
        {
            return await this.SendAsync<AuthenticationcombinationConfigurationUpdateParameter, AuthenticationcombinationConfigurationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationcombinationconfiguration-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationcombinationConfigurationUpdateResponse> AuthenticationcombinationConfigurationUpdateAsync(AuthenticationcombinationConfigurationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationcombinationConfigurationUpdateParameter, AuthenticationcombinationConfigurationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
