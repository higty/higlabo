using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ActivitybasedtimeoutpolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Olicies_ActivityBasedTimeoutPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Olicies_ActivityBasedTimeoutPolicies: return $"/olicies/activityBasedTimeoutPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class ActivitybasedtimeoutpolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/activitybasedtimeoutpolicy?view=graph-rest-1.0
        /// </summary>
        public partial class ActivityBasedTimeoutPolicy
        {
            public string? Id { get; set; }
            public String[]? Definition { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsOrganizationDefault { get; set; }
        }

        public ActivityBasedTimeoutPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyListResponse> ActivitybasedtimeoutpolicyListAsync()
        {
            var p = new ActivitybasedtimeoutpolicyListParameter();
            return await this.SendAsync<ActivitybasedtimeoutpolicyListParameter, ActivitybasedtimeoutpolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyListResponse> ActivitybasedtimeoutpolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new ActivitybasedtimeoutpolicyListParameter();
            return await this.SendAsync<ActivitybasedtimeoutpolicyListParameter, ActivitybasedtimeoutpolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyListResponse> ActivitybasedtimeoutpolicyListAsync(ActivitybasedtimeoutpolicyListParameter parameter)
        {
            return await this.SendAsync<ActivitybasedtimeoutpolicyListParameter, ActivitybasedtimeoutpolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyListResponse> ActivitybasedtimeoutpolicyListAsync(ActivitybasedtimeoutpolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ActivitybasedtimeoutpolicyListParameter, ActivitybasedtimeoutpolicyListResponse>(parameter, cancellationToken);
        }
    }
}
