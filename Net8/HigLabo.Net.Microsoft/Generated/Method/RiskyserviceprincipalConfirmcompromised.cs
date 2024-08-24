using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyServicePrincipalConfirmcompromisedParameter : IRestApiParameter
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
    public partial class RiskyServicePrincipalConfirmcompromisedResponse : RestApiResponse
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
        public async ValueTask<RiskyServicePrincipalConfirmcompromisedResponse> RiskyServicePrincipalConfirmcompromisedAsync()
        {
            var p = new RiskyServicePrincipalConfirmcompromisedParameter();
            return await this.SendAsync<RiskyServicePrincipalConfirmcompromisedParameter, RiskyServicePrincipalConfirmcompromisedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalConfirmcompromisedResponse> RiskyServicePrincipalConfirmcompromisedAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyServicePrincipalConfirmcompromisedParameter();
            return await this.SendAsync<RiskyServicePrincipalConfirmcompromisedParameter, RiskyServicePrincipalConfirmcompromisedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalConfirmcompromisedResponse> RiskyServicePrincipalConfirmcompromisedAsync(RiskyServicePrincipalConfirmcompromisedParameter parameter)
        {
            return await this.SendAsync<RiskyServicePrincipalConfirmcompromisedParameter, RiskyServicePrincipalConfirmcompromisedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalConfirmcompromisedResponse> RiskyServicePrincipalConfirmcompromisedAsync(RiskyServicePrincipalConfirmcompromisedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyServicePrincipalConfirmcompromisedParameter, RiskyServicePrincipalConfirmcompromisedResponse>(parameter, cancellationToken);
        }
    }
}
