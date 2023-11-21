using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-setuserpreferredpresence?view=graph-rest-1.0
    /// </summary>
    public partial class PresenceSetUserpreferredpresenceParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserId_Presence_SetUserPreferredPresence: return $"/users/{UserId}/presence/setUserPreferredPresence";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_UserId_Presence_SetUserPreferredPresence,
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
        public string? Activity { get; set; }
        public string? Availability { get; set; }
        public string? ExpirationDuration { get; set; }
    }
    public partial class PresenceSetUserpreferredpresenceResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-setuserpreferredpresence?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-setuserpreferredpresence?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PresenceSetUserpreferredpresenceResponse> PresenceSetUserpreferredpresenceAsync()
        {
            var p = new PresenceSetUserpreferredpresenceParameter();
            return await this.SendAsync<PresenceSetUserpreferredpresenceParameter, PresenceSetUserpreferredpresenceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-setuserpreferredpresence?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PresenceSetUserpreferredpresenceResponse> PresenceSetUserpreferredpresenceAsync(CancellationToken cancellationToken)
        {
            var p = new PresenceSetUserpreferredpresenceParameter();
            return await this.SendAsync<PresenceSetUserpreferredpresenceParameter, PresenceSetUserpreferredpresenceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-setuserpreferredpresence?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PresenceSetUserpreferredpresenceResponse> PresenceSetUserpreferredpresenceAsync(PresenceSetUserpreferredpresenceParameter parameter)
        {
            return await this.SendAsync<PresenceSetUserpreferredpresenceParameter, PresenceSetUserpreferredpresenceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-setuserpreferredpresence?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PresenceSetUserpreferredpresenceResponse> PresenceSetUserpreferredpresenceAsync(PresenceSetUserpreferredpresenceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PresenceSetUserpreferredpresenceParameter, PresenceSetUserpreferredpresenceResponse>(parameter, cancellationToken);
        }
    }
}
