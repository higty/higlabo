using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyserviceprincipalDismissParameter : IRestApiParameter
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
    public partial class RiskyserviceprincipalDismissResponse : RestApiResponse
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
        public async Task<RiskyserviceprincipalDismissResponse> RiskyserviceprincipalDismissAsync()
        {
            var p = new RiskyserviceprincipalDismissParameter();
            return await this.SendAsync<RiskyserviceprincipalDismissParameter, RiskyserviceprincipalDismissResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyserviceprincipalDismissResponse> RiskyserviceprincipalDismissAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyserviceprincipalDismissParameter();
            return await this.SendAsync<RiskyserviceprincipalDismissParameter, RiskyserviceprincipalDismissResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyserviceprincipalDismissResponse> RiskyserviceprincipalDismissAsync(RiskyserviceprincipalDismissParameter parameter)
        {
            return await this.SendAsync<RiskyserviceprincipalDismissParameter, RiskyserviceprincipalDismissResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyserviceprincipal-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyserviceprincipalDismissResponse> RiskyserviceprincipalDismissAsync(RiskyserviceprincipalDismissParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyserviceprincipalDismissParameter, RiskyserviceprincipalDismissResponse>(parameter, cancellationToken);
        }
    }
}
