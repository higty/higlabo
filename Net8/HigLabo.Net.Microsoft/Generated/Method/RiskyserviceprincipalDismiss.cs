using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyServicePrincipalDismissParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyServicePrincipals_Dismiss: return $"/identityProtection/riskyServicePrincipals/dismiss";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityProtection_RiskyServicePrincipals_Dismiss,
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
    public partial class RiskyServicePrincipalDismissResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalDismissResponse> RiskyServicePrincipalDismissAsync()
        {
            var p = new RiskyServicePrincipalDismissParameter();
            return await this.SendAsync<RiskyServicePrincipalDismissParameter, RiskyServicePrincipalDismissResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalDismissResponse> RiskyServicePrincipalDismissAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyServicePrincipalDismissParameter();
            return await this.SendAsync<RiskyServicePrincipalDismissParameter, RiskyServicePrincipalDismissResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalDismissResponse> RiskyServicePrincipalDismissAsync(RiskyServicePrincipalDismissParameter parameter)
        {
            return await this.SendAsync<RiskyServicePrincipalDismissParameter, RiskyServicePrincipalDismissResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyServicePrincipalDismissResponse> RiskyServicePrincipalDismissAsync(RiskyServicePrincipalDismissParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyServicePrincipalDismissParameter, RiskyServicePrincipalDismissResponse>(parameter, cancellationToken);
        }
    }
}
