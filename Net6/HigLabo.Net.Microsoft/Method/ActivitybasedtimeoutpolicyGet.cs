using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ActivitybasedtimeoutpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_ActivityBasedTimeoutPolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_ActivityBasedTimeoutPolicies_Id: return $"/policies/activityBasedTimeoutPolicies/{Id}";
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
        public string Id { get; set; }
    }
    public partial class ActivitybasedtimeoutpolicyGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyGetResponse> ActivitybasedtimeoutpolicyGetAsync()
        {
            var p = new ActivitybasedtimeoutpolicyGetParameter();
            return await this.SendAsync<ActivitybasedtimeoutpolicyGetParameter, ActivitybasedtimeoutpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyGetResponse> ActivitybasedtimeoutpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new ActivitybasedtimeoutpolicyGetParameter();
            return await this.SendAsync<ActivitybasedtimeoutpolicyGetParameter, ActivitybasedtimeoutpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyGetResponse> ActivitybasedtimeoutpolicyGetAsync(ActivitybasedtimeoutpolicyGetParameter parameter)
        {
            return await this.SendAsync<ActivitybasedtimeoutpolicyGetParameter, ActivitybasedtimeoutpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyGetResponse> ActivitybasedtimeoutpolicyGetAsync(ActivitybasedtimeoutpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ActivitybasedtimeoutpolicyGetParameter, ActivitybasedtimeoutpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
