using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PresenceSetpresenceParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UserId_Presence_SetPresence,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UserId_Presence_SetPresence: return $"/users/{UserId}/presence/setPresence";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? SessionId { get; set; }
        public string? Availability { get; set; }
        public string? Activity { get; set; }
        public string? ExpirationDuration { get; set; }
        public string UserId { get; set; }
    }
    public partial class PresenceSetpresenceResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
        /// </summary>
        public async Task<PresenceSetpresenceResponse> PresenceSetpresenceAsync()
        {
            var p = new PresenceSetpresenceParameter();
            return await this.SendAsync<PresenceSetpresenceParameter, PresenceSetpresenceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
        /// </summary>
        public async Task<PresenceSetpresenceResponse> PresenceSetpresenceAsync(CancellationToken cancellationToken)
        {
            var p = new PresenceSetpresenceParameter();
            return await this.SendAsync<PresenceSetpresenceParameter, PresenceSetpresenceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
        /// </summary>
        public async Task<PresenceSetpresenceResponse> PresenceSetpresenceAsync(PresenceSetpresenceParameter parameter)
        {
            return await this.SendAsync<PresenceSetpresenceParameter, PresenceSetpresenceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/presence-setpresence?view=graph-rest-1.0
        /// </summary>
        public async Task<PresenceSetpresenceResponse> PresenceSetpresenceAsync(PresenceSetpresenceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PresenceSetpresenceParameter, PresenceSetpresenceResponse>(parameter, cancellationToken);
        }
    }
}
