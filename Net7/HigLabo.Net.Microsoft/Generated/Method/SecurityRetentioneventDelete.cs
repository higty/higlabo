using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-delete?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? RetentionEventId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Triggers_RetentionEvents_RetentionEventId: return $"/security/triggers/retentionEvents/{RetentionEventId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Triggers_RetentionEvents_RetentionEventId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class SecurityRetentioneventDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventDeleteResponse> SecurityRetentioneventDeleteAsync()
        {
            var p = new SecurityRetentioneventDeleteParameter();
            return await this.SendAsync<SecurityRetentioneventDeleteParameter, SecurityRetentioneventDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventDeleteResponse> SecurityRetentioneventDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventDeleteParameter();
            return await this.SendAsync<SecurityRetentioneventDeleteParameter, SecurityRetentioneventDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventDeleteResponse> SecurityRetentioneventDeleteAsync(SecurityRetentioneventDeleteParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventDeleteParameter, SecurityRetentioneventDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventDeleteResponse> SecurityRetentioneventDeleteAsync(SecurityRetentioneventDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventDeleteParameter, SecurityRetentioneventDeleteResponse>(parameter, cancellationToken);
        }
    }
}
