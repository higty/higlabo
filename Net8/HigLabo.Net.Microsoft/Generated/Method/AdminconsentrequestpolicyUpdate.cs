using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class AdminconsentRequestPolicyUpdateParameter : IRestApiParameter
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
    public partial class AdminconsentRequestPolicyUpdateResponse : RestApiResponse
    {
        public bool? IsEnabled { get; set; }
        public bool? NotifyReviewers { get; set; }
        public bool? RemindersEnabled { get; set; }
        public Int32? RequestDurationInDays { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
        public Int32? Version { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdminconsentRequestPolicyUpdateResponse> AdminconsentRequestPolicyUpdateAsync()
        {
            var p = new AdminconsentRequestPolicyUpdateParameter();
            return await this.SendAsync<AdminconsentRequestPolicyUpdateParameter, AdminconsentRequestPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdminconsentRequestPolicyUpdateResponse> AdminconsentRequestPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AdminconsentRequestPolicyUpdateParameter();
            return await this.SendAsync<AdminconsentRequestPolicyUpdateParameter, AdminconsentRequestPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdminconsentRequestPolicyUpdateResponse> AdminconsentRequestPolicyUpdateAsync(AdminconsentRequestPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<AdminconsentRequestPolicyUpdateParameter, AdminconsentRequestPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdminconsentRequestPolicyUpdateResponse> AdminconsentRequestPolicyUpdateAsync(AdminconsentRequestPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminconsentRequestPolicyUpdateParameter, AdminconsentRequestPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
