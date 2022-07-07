using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdminconsentrequestpolicyUpdateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_AdminConsentRequestPolicy,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_AdminConsentRequestPolicy: return $"/policies/adminConsentRequestPolicy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public bool? IsEnabled { get; set; }
        public bool? NotifyReviewers { get; set; }
        public bool? RemindersEnabled { get; set; }
        public Int32? RequestDurationInDays { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
    }
    public partial class AdminconsentrequestpolicyUpdateResponse : RestApiResponse
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
        public async Task<AdminconsentrequestpolicyUpdateResponse> AdminconsentrequestpolicyUpdateAsync()
        {
            var p = new AdminconsentrequestpolicyUpdateParameter();
            return await this.SendAsync<AdminconsentrequestpolicyUpdateParameter, AdminconsentrequestpolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestpolicyUpdateResponse> AdminconsentrequestpolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AdminconsentrequestpolicyUpdateParameter();
            return await this.SendAsync<AdminconsentrequestpolicyUpdateParameter, AdminconsentrequestpolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestpolicyUpdateResponse> AdminconsentrequestpolicyUpdateAsync(AdminconsentrequestpolicyUpdateParameter parameter)
        {
            return await this.SendAsync<AdminconsentrequestpolicyUpdateParameter, AdminconsentrequestpolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestpolicyUpdateResponse> AdminconsentrequestpolicyUpdateAsync(AdminconsentrequestpolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminconsentrequestpolicyUpdateParameter, AdminconsentrequestpolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
