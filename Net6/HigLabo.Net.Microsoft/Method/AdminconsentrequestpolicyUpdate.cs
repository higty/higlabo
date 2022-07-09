using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdminconsentrequestPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AdminConsentRequestPolicy: return $"/policies/adminConsentRequestPolicy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_AdminConsentRequestPolicy,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public bool? IsEnabled { get; set; }
        public bool? NotifyReviewers { get; set; }
        public bool? RemindersEnabled { get; set; }
        public Int32? RequestDurationInDays { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
    }
    public partial class AdminconsentrequestPolicyUpdateResponse : RestApiResponse
    {
        public bool? IsEnabled { get; set; }
        public bool? NotifyReviewers { get; set; }
        public bool? RemindersEnabled { get; set; }
        public Int32? RequestDurationInDays { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
        public Int32? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestPolicyUpdateResponse> AdminconsentrequestPolicyUpdateAsync()
        {
            var p = new AdminconsentrequestPolicyUpdateParameter();
            return await this.SendAsync<AdminconsentrequestPolicyUpdateParameter, AdminconsentrequestPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestPolicyUpdateResponse> AdminconsentrequestPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AdminconsentrequestPolicyUpdateParameter();
            return await this.SendAsync<AdminconsentrequestPolicyUpdateParameter, AdminconsentrequestPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestPolicyUpdateResponse> AdminconsentrequestPolicyUpdateAsync(AdminconsentrequestPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<AdminconsentrequestPolicyUpdateParameter, AdminconsentrequestPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestPolicyUpdateResponse> AdminconsentrequestPolicyUpdateAsync(AdminconsentrequestPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminconsentrequestPolicyUpdateParameter, AdminconsentrequestPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
