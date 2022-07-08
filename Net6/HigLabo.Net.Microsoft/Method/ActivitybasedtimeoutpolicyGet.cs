using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ActivitybasedtimeoutPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_ActivityBasedTimeoutPolicies_Id: return $"/policies/activityBasedTimeoutPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_ActivityBasedTimeoutPolicies_Id,
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
    public partial class ActivitybasedtimeoutPolicyGetResponse : RestApiResponse
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
        public async Task<ActivitybasedtimeoutPolicyGetResponse> ActivitybasedtimeoutPolicyGetAsync()
        {
            var p = new ActivitybasedtimeoutPolicyGetParameter();
            return await this.SendAsync<ActivitybasedtimeoutPolicyGetParameter, ActivitybasedtimeoutPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyGetResponse> ActivitybasedtimeoutPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new ActivitybasedtimeoutPolicyGetParameter();
            return await this.SendAsync<ActivitybasedtimeoutPolicyGetParameter, ActivitybasedtimeoutPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyGetResponse> ActivitybasedtimeoutPolicyGetAsync(ActivitybasedtimeoutPolicyGetParameter parameter)
        {
            return await this.SendAsync<ActivitybasedtimeoutPolicyGetParameter, ActivitybasedtimeoutPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyGetResponse> ActivitybasedtimeoutPolicyGetAsync(ActivitybasedtimeoutPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ActivitybasedtimeoutPolicyGetParameter, ActivitybasedtimeoutPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
