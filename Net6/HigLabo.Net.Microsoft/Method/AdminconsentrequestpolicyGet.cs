using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdminconsentrequestpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class AdminconsentrequestpolicyGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestpolicyGetResponse> AdminconsentrequestpolicyGetAsync()
        {
            var p = new AdminconsentrequestpolicyGetParameter();
            return await this.SendAsync<AdminconsentrequestpolicyGetParameter, AdminconsentrequestpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestpolicyGetResponse> AdminconsentrequestpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AdminconsentrequestpolicyGetParameter();
            return await this.SendAsync<AdminconsentrequestpolicyGetParameter, AdminconsentrequestpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestpolicyGetResponse> AdminconsentrequestpolicyGetAsync(AdminconsentrequestpolicyGetParameter parameter)
        {
            return await this.SendAsync<AdminconsentrequestpolicyGetParameter, AdminconsentrequestpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/adminconsentrequestpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AdminconsentrequestpolicyGetResponse> AdminconsentrequestpolicyGetAsync(AdminconsentrequestpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminconsentrequestpolicyGetParameter, AdminconsentrequestpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
