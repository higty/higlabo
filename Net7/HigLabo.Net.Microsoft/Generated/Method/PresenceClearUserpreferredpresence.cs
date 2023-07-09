using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-clearuserpreferredpresence?view=graph-rest-1.0
    /// </summary>
    public partial class PresenceClearUserpreferredpresenceParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserId_Presence_ClearUserPreferredPresence: return $"/users/{UserId}/presence/clearUserPreferredPresence";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_UserId_Presence_ClearUserPreferredPresence,
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
    public partial class PresenceClearUserpreferredpresenceResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-clearuserpreferredpresence?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-clearuserpreferredpresence?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PresenceClearUserpreferredpresenceResponse> PresenceClearUserpreferredpresenceAsync()
        {
            var p = new PresenceClearUserpreferredpresenceParameter();
            return await this.SendAsync<PresenceClearUserpreferredpresenceParameter, PresenceClearUserpreferredpresenceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-clearuserpreferredpresence?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PresenceClearUserpreferredpresenceResponse> PresenceClearUserpreferredpresenceAsync(CancellationToken cancellationToken)
        {
            var p = new PresenceClearUserpreferredpresenceParameter();
            return await this.SendAsync<PresenceClearUserpreferredpresenceParameter, PresenceClearUserpreferredpresenceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-clearuserpreferredpresence?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PresenceClearUserpreferredpresenceResponse> PresenceClearUserpreferredpresenceAsync(PresenceClearUserpreferredpresenceParameter parameter)
        {
            return await this.SendAsync<PresenceClearUserpreferredpresenceParameter, PresenceClearUserpreferredpresenceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-clearuserpreferredpresence?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PresenceClearUserpreferredpresenceResponse> PresenceClearUserpreferredpresenceAsync(PresenceClearUserpreferredpresenceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PresenceClearUserpreferredpresenceParameter, PresenceClearUserpreferredpresenceResponse>(parameter, cancellationToken);
        }
    }
}
