using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ActivitybasedtimeoutpolicyDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class ActivitybasedtimeoutpolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyDeleteResponse> ActivitybasedtimeoutpolicyDeleteAsync()
        {
            var p = new ActivitybasedtimeoutpolicyDeleteParameter();
            return await this.SendAsync<ActivitybasedtimeoutpolicyDeleteParameter, ActivitybasedtimeoutpolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyDeleteResponse> ActivitybasedtimeoutpolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ActivitybasedtimeoutpolicyDeleteParameter();
            return await this.SendAsync<ActivitybasedtimeoutpolicyDeleteParameter, ActivitybasedtimeoutpolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyDeleteResponse> ActivitybasedtimeoutpolicyDeleteAsync(ActivitybasedtimeoutpolicyDeleteParameter parameter)
        {
            return await this.SendAsync<ActivitybasedtimeoutpolicyDeleteParameter, ActivitybasedtimeoutpolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyDeleteResponse> ActivitybasedtimeoutpolicyDeleteAsync(ActivitybasedtimeoutpolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ActivitybasedtimeoutpolicyDeleteParameter, ActivitybasedtimeoutpolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
