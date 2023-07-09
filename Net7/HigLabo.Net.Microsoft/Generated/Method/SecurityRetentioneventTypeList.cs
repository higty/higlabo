using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventTypeListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_TriggerTypes_RetentionEventTypes: return $"/security/triggerTypes/retentionEventTypes";
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
            Id,
            LastModifiedBy,
            LastModifiedDateTime,
        }
        public enum ApiPath
        {
            Security_TriggerTypes_RetentionEventTypes,
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
    public partial class SecurityRetentioneventTypeListResponse : RestApiResponse
    {
        public RetentionEventType[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeListResponse> SecurityRetentioneventTypeListAsync()
        {
            var p = new SecurityRetentioneventTypeListParameter();
            return await this.SendAsync<SecurityRetentioneventTypeListParameter, SecurityRetentioneventTypeListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeListResponse> SecurityRetentioneventTypeListAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventTypeListParameter();
            return await this.SendAsync<SecurityRetentioneventTypeListParameter, SecurityRetentioneventTypeListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeListResponse> SecurityRetentioneventTypeListAsync(SecurityRetentioneventTypeListParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventTypeListParameter, SecurityRetentioneventTypeListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeListResponse> SecurityRetentioneventTypeListAsync(SecurityRetentioneventTypeListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventTypeListParameter, SecurityRetentioneventTypeListResponse>(parameter, cancellationToken);
        }
    }
}
