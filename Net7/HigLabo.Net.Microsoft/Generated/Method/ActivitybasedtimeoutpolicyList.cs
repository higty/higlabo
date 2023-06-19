using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class ActivitybasedtimeoutPolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Olicies_ActivityBasedTimeoutPolicies: return $"/olicies/activityBasedTimeoutPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Definition,
            Description,
            DisplayName,
            Id,
            IsOrganizationDefault,
        }
        public enum ApiPath
        {
            Olicies_ActivityBasedTimeoutPolicies,
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
    public partial class ActivitybasedtimeoutPolicyListResponse : RestApiResponse
    {
        public ActivityBasedTimeoutPolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ActivitybasedtimeoutPolicyListResponse> ActivitybasedtimeoutPolicyListAsync()
        {
            var p = new ActivitybasedtimeoutPolicyListParameter();
            return await this.SendAsync<ActivitybasedtimeoutPolicyListParameter, ActivitybasedtimeoutPolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ActivitybasedtimeoutPolicyListResponse> ActivitybasedtimeoutPolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new ActivitybasedtimeoutPolicyListParameter();
            return await this.SendAsync<ActivitybasedtimeoutPolicyListParameter, ActivitybasedtimeoutPolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ActivitybasedtimeoutPolicyListResponse> ActivitybasedtimeoutPolicyListAsync(ActivitybasedtimeoutPolicyListParameter parameter)
        {
            return await this.SendAsync<ActivitybasedtimeoutPolicyListParameter, ActivitybasedtimeoutPolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ActivitybasedtimeoutPolicyListResponse> ActivitybasedtimeoutPolicyListAsync(ActivitybasedtimeoutPolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ActivitybasedtimeoutPolicyListParameter, ActivitybasedtimeoutPolicyListResponse>(parameter, cancellationToken);
        }
    }
}
