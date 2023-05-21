using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-clearpresence?view=graph-rest-1.0
    /// </summary>
    public partial class PresenceClearpresenceParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserId_Presence_ClearPresence: return $"/users/{UserId}/presence/clearPresence";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_UserId_Presence_ClearPresence,
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
        public string? SessionId { get; set; }
    }
    public partial class PresenceClearpresenceResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/presence-clearpresence?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-clearpresence?view=graph-rest-1.0
        /// </summary>
        public async Task<PresenceClearpresenceResponse> PresenceClearpresenceAsync()
        {
            var p = new PresenceClearpresenceParameter();
            return await this.SendAsync<PresenceClearpresenceParameter, PresenceClearpresenceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-clearpresence?view=graph-rest-1.0
        /// </summary>
        public async Task<PresenceClearpresenceResponse> PresenceClearpresenceAsync(CancellationToken cancellationToken)
        {
            var p = new PresenceClearpresenceParameter();
            return await this.SendAsync<PresenceClearpresenceParameter, PresenceClearpresenceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-clearpresence?view=graph-rest-1.0
        /// </summary>
        public async Task<PresenceClearpresenceResponse> PresenceClearpresenceAsync(PresenceClearpresenceParameter parameter)
        {
            return await this.SendAsync<PresenceClearpresenceParameter, PresenceClearpresenceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/presence-clearpresence?view=graph-rest-1.0
        /// </summary>
        public async Task<PresenceClearpresenceResponse> PresenceClearpresenceAsync(PresenceClearpresenceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PresenceClearpresenceParameter, PresenceClearpresenceResponse>(parameter, cancellationToken);
        }
    }
}
