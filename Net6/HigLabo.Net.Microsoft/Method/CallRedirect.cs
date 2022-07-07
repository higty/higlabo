using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallRedirectParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_Redirect,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_Redirect: return $"/communications/calls/{Id}/redirect";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public InvitationParticipantInfo[]? Targets { get; set; }
        public Int32? Timeout { get; set; }
        public string? CallbackUri { get; set; }
        public string Id { get; set; }
    }
    public partial class CallRedirectResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRedirectResponse> CallRedirectAsync()
        {
            var p = new CallRedirectParameter();
            return await this.SendAsync<CallRedirectParameter, CallRedirectResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRedirectResponse> CallRedirectAsync(CancellationToken cancellationToken)
        {
            var p = new CallRedirectParameter();
            return await this.SendAsync<CallRedirectParameter, CallRedirectResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRedirectResponse> CallRedirectAsync(CallRedirectParameter parameter)
        {
            return await this.SendAsync<CallRedirectParameter, CallRedirectResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRedirectResponse> CallRedirectAsync(CallRedirectParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallRedirectParameter, CallRedirectResponse>(parameter, cancellationToken);
        }
    }
}
