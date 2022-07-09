using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ActivitybasedtimeoutPolicyDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ActivitybasedtimeoutPolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyDeleteResponse> ActivitybasedtimeoutPolicyDeleteAsync()
        {
            var p = new ActivitybasedtimeoutPolicyDeleteParameter();
            return await this.SendAsync<ActivitybasedtimeoutPolicyDeleteParameter, ActivitybasedtimeoutPolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyDeleteResponse> ActivitybasedtimeoutPolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ActivitybasedtimeoutPolicyDeleteParameter();
            return await this.SendAsync<ActivitybasedtimeoutPolicyDeleteParameter, ActivitybasedtimeoutPolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyDeleteResponse> ActivitybasedtimeoutPolicyDeleteAsync(ActivitybasedtimeoutPolicyDeleteParameter parameter)
        {
            return await this.SendAsync<ActivitybasedtimeoutPolicyDeleteParameter, ActivitybasedtimeoutPolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ActivitybasedtimeoutPolicyDeleteResponse> ActivitybasedtimeoutPolicyDeleteAsync(ActivitybasedtimeoutPolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ActivitybasedtimeoutPolicyDeleteParameter, ActivitybasedtimeoutPolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
