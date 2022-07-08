using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceStopParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string AccessReviewScheduleDefinitionId { get; set; }
            public string AccessReviewInstanceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stop: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stop";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stop,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class AccessreviewinstanceStopResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceStopResponse> AccessreviewinstanceStopAsync()
        {
            var p = new AccessreviewinstanceStopParameter();
            return await this.SendAsync<AccessreviewinstanceStopParameter, AccessreviewinstanceStopResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceStopResponse> AccessreviewinstanceStopAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceStopParameter();
            return await this.SendAsync<AccessreviewinstanceStopParameter, AccessreviewinstanceStopResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceStopResponse> AccessreviewinstanceStopAsync(AccessreviewinstanceStopParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceStopParameter, AccessreviewinstanceStopResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceStopResponse> AccessreviewinstanceStopAsync(AccessreviewinstanceStopParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceStopParameter, AccessreviewinstanceStopResponse>(parameter, cancellationToken);
        }
    }
}
