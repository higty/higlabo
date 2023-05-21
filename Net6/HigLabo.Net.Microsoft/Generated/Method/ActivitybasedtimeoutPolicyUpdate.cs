using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class ActivitybasedtimeoutPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_ActivityBasedTimeoutPolicies_Id: return $"/policies/activityBasedTimeoutPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
    }
    public partial class ActivitybasedtimeoutPolicyUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyUpdateResponse> ActivitybasedtimeoutPolicyUpdateAsync()
        {
            var p = new ActivitybasedtimeoutPolicyUpdateParameter();
            return await this.SendAsync<ActivitybasedtimeoutPolicyUpdateParameter, ActivitybasedtimeoutPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyUpdateResponse> ActivitybasedtimeoutPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ActivitybasedtimeoutPolicyUpdateParameter();
            return await this.SendAsync<ActivitybasedtimeoutPolicyUpdateParameter, ActivitybasedtimeoutPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyUpdateResponse> ActivitybasedtimeoutPolicyUpdateAsync(ActivitybasedtimeoutPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<ActivitybasedtimeoutPolicyUpdateParameter, ActivitybasedtimeoutPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyUpdateResponse> ActivitybasedtimeoutPolicyUpdateAsync(ActivitybasedtimeoutPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ActivitybasedtimeoutPolicyUpdateParameter, ActivitybasedtimeoutPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
