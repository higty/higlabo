using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Triggers_RetentionEvents: return $"/security/triggers/retentionEvents";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedBy,
            CreatedDateTime,
            Description,
            DisplayName,
            EventPropagationResult,
            EventQueries,
            RetentionEventStatus,
            EventTriggerDateTime,
            Id,
            LastModifiedBy,
            LastModifiedDateTime,
            LastStatusUpdateDateTime,
            RetentionEventType,
        }
        public enum ApiPath
        {
            Security_Triggers_RetentionEvents,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class SecurityRetentioneventListResponse : RestApiResponse
    {
        public RetentionEvent[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventListResponse> SecurityRetentioneventListAsync()
        {
            var p = new SecurityRetentioneventListParameter();
            return await this.SendAsync<SecurityRetentioneventListParameter, SecurityRetentioneventListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventListResponse> SecurityRetentioneventListAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventListParameter();
            return await this.SendAsync<SecurityRetentioneventListParameter, SecurityRetentioneventListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventListResponse> SecurityRetentioneventListAsync(SecurityRetentioneventListParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventListParameter, SecurityRetentioneventListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventListResponse> SecurityRetentioneventListAsync(SecurityRetentioneventListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventListParameter, SecurityRetentioneventListResponse>(parameter, cancellationToken);
        }
    }
}
