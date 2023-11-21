using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class AdminconsentrequestPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class AdminconsentrequestPolicyGetResponse : RestApiResponse
    {
        public bool? IsEnabled { get; set; }
        public bool? NotifyReviewers { get; set; }
        public bool? RemindersEnabled { get; set; }
        public Int32? RequestDurationInDays { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
        public Int32? Version { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdminconsentrequestPolicyGetResponse> AdminconsentrequestPolicyGetAsync()
        {
            var p = new AdminconsentrequestPolicyGetParameter();
            return await this.SendAsync<AdminconsentrequestPolicyGetParameter, AdminconsentrequestPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdminconsentrequestPolicyGetResponse> AdminconsentrequestPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AdminconsentrequestPolicyGetParameter();
            return await this.SendAsync<AdminconsentrequestPolicyGetParameter, AdminconsentrequestPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdminconsentrequestPolicyGetResponse> AdminconsentrequestPolicyGetAsync(AdminconsentrequestPolicyGetParameter parameter)
        {
            return await this.SendAsync<AdminconsentrequestPolicyGetParameter, AdminconsentrequestPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdminconsentrequestPolicyGetResponse> AdminconsentrequestPolicyGetAsync(AdminconsentrequestPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminconsentrequestPolicyGetParameter, AdminconsentrequestPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
