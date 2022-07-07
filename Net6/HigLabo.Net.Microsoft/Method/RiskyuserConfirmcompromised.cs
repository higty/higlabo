using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RiskyuserConfirmcompromisedParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityProtection_RiskyUsers_ConfirmCompromised,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_ConfirmCompromised: return $"/identityProtection/riskyUsers/confirmCompromised";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? UserIds { get; set; }
    }
    public partial class RiskyuserConfirmcompromisedResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserConfirmcompromisedResponse> RiskyuserConfirmcompromisedAsync()
        {
            var p = new RiskyuserConfirmcompromisedParameter();
            return await this.SendAsync<RiskyuserConfirmcompromisedParameter, RiskyuserConfirmcompromisedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserConfirmcompromisedResponse> RiskyuserConfirmcompromisedAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyuserConfirmcompromisedParameter();
            return await this.SendAsync<RiskyuserConfirmcompromisedParameter, RiskyuserConfirmcompromisedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserConfirmcompromisedResponse> RiskyuserConfirmcompromisedAsync(RiskyuserConfirmcompromisedParameter parameter)
        {
            return await this.SendAsync<RiskyuserConfirmcompromisedParameter, RiskyuserConfirmcompromisedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async Task<RiskyuserConfirmcompromisedResponse> RiskyuserConfirmcompromisedAsync(RiskyuserConfirmcompromisedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyuserConfirmcompromisedParameter, RiskyuserConfirmcompromisedResponse>(parameter, cancellationToken);
        }
    }
}
