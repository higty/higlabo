using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyUserDismissParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_Dismiss: return $"/identityProtection/riskyUsers/dismiss";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityProtection_RiskyUsers_Dismiss,
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
        public String[]? UserIds { get; set; }
    }
    public partial class RiskyUserDismissResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserDismissResponse> RiskyUserDismissAsync()
        {
            var p = new RiskyUserDismissParameter();
            return await this.SendAsync<RiskyUserDismissParameter, RiskyUserDismissResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserDismissResponse> RiskyUserDismissAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyUserDismissParameter();
            return await this.SendAsync<RiskyUserDismissParameter, RiskyUserDismissResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserDismissResponse> RiskyUserDismissAsync(RiskyUserDismissParameter parameter)
        {
            return await this.SendAsync<RiskyUserDismissParameter, RiskyUserDismissResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyUserDismissResponse> RiskyUserDismissAsync(RiskyUserDismissParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyUserDismissParameter, RiskyUserDismissResponse>(parameter, cancellationToken);
        }
    }
}
