using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesResponse> ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesAsync()
        {
            var p = new ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesParameter();
            return await this.SendAsync<ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesParameter, ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesResponse> ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesParameter();
            return await this.SendAsync<ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesParameter, ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesResponse> ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesAsync(ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesParameter parameter)
        {
            return await this.SendAsync<ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesParameter, ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesResponse> ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesAsync(ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesParameter, ActivitybasedtimeoutpolicyPostActivitybasedtimeoutpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
