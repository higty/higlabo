using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyserviceprincipalConfirmcompromisedParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyServicePrincipals_ConfirmCompromised: return $"/identityProtection/riskyServicePrincipals/confirmCompromised";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityProtection_RiskyServicePrincipals_ConfirmCompromised,
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
    }
    public partial class RiskyserviceprincipalConfirmcompromisedResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyserviceprincipalConfirmcompromisedResponse> RiskyserviceprincipalConfirmcompromisedAsync()
        {
            var p = new RiskyserviceprincipalConfirmcompromisedParameter();
            return await this.SendAsync<RiskyserviceprincipalConfirmcompromisedParameter, RiskyserviceprincipalConfirmcompromisedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyserviceprincipalConfirmcompromisedResponse> RiskyserviceprincipalConfirmcompromisedAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyserviceprincipalConfirmcompromisedParameter();
            return await this.SendAsync<RiskyserviceprincipalConfirmcompromisedParameter, RiskyserviceprincipalConfirmcompromisedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyserviceprincipalConfirmcompromisedResponse> RiskyserviceprincipalConfirmcompromisedAsync(RiskyserviceprincipalConfirmcompromisedParameter parameter)
        {
            return await this.SendAsync<RiskyserviceprincipalConfirmcompromisedParameter, RiskyserviceprincipalConfirmcompromisedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyserviceprincipalConfirmcompromisedResponse> RiskyserviceprincipalConfirmcompromisedAsync(RiskyserviceprincipalConfirmcompromisedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyserviceprincipalConfirmcompromisedParameter, RiskyserviceprincipalConfirmcompromisedResponse>(parameter, cancellationToken);
        }
    }
}
