using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskyuserDismissParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityProtection_RiskyUsers_Dismiss,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_Dismiss: return $"/identityProtection/riskyUsers/dismiss";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? UserIds { get; set; }
    }
    public partial class RiskyuserDismissResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserDismissResponse> RiskyuserDismissAsync()
        {
            var p = new RiskyuserDismissParameter();
            return await this.SendAsync<RiskyuserDismissParameter, RiskyuserDismissResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserDismissResponse> RiskyuserDismissAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyuserDismissParameter();
            return await this.SendAsync<RiskyuserDismissParameter, RiskyuserDismissResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserDismissResponse> RiskyuserDismissAsync(RiskyuserDismissParameter parameter)
        {
            return await this.SendAsync<RiskyuserDismissParameter, RiskyuserDismissResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-dismiss?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserDismissResponse> RiskyuserDismissAsync(RiskyuserDismissParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyuserDismissParameter, RiskyuserDismissResponse>(parameter, cancellationToken);
        }
    }
}
