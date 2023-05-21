using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
    /// </summary>
    public partial class CallRedirectParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_Redirect: return $"/communications/calls/{Id}/redirect";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_Redirect,
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
        public InvitationParticipantInfo[]? Targets { get; set; }
        public Int32? Timeout { get; set; }
        public string? CallbackUri { get; set; }
    }
    public partial class CallRedirectResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRedirectResponse> CallRedirectAsync()
        {
            var p = new CallRedirectParameter();
            return await this.SendAsync<CallRedirectParameter, CallRedirectResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRedirectResponse> CallRedirectAsync(CancellationToken cancellationToken)
        {
            var p = new CallRedirectParameter();
            return await this.SendAsync<CallRedirectParameter, CallRedirectResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRedirectResponse> CallRedirectAsync(CallRedirectParameter parameter)
        {
            return await this.SendAsync<CallRedirectParameter, CallRedirectResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<CallRedirectResponse> CallRedirectAsync(CallRedirectParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallRedirectParameter, CallRedirectResponse>(parameter, cancellationToken);
        }
    }
}
