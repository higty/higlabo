using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AppconsentrequestListUserconsentrequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AppConsent_AppConsentRequests_Id_UserConsentRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests_Id_UserConsentRequests: return $"/identityGovernance/appConsent/appConsentRequests/{Id}/userConsentRequests";
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
        public string Id { get; set; }
    }
    public partial class AppconsentrequestListUserconsentrequestsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/userconsentrequest?view=graph-rest-1.0
        /// </summary>
        public partial class UserConsentRequest
        {
            public string? ApprovalId { get; set; }
            public DateTimeOffset? CompletedDateTime { get; set; }
            public IdentitySet? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? CustomData { get; set; }
            public string? Id { get; set; }
            public string? Reason { get; set; }
            public string? Status { get; set; }
        }

        public UserConsentRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestListUserconsentrequestsResponse> AppconsentrequestListUserconsentrequestsAsync()
        {
            var p = new AppconsentrequestListUserconsentrequestsParameter();
            return await this.SendAsync<AppconsentrequestListUserconsentrequestsParameter, AppconsentrequestListUserconsentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestListUserconsentrequestsResponse> AppconsentrequestListUserconsentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new AppconsentrequestListUserconsentrequestsParameter();
            return await this.SendAsync<AppconsentrequestListUserconsentrequestsParameter, AppconsentrequestListUserconsentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestListUserconsentrequestsResponse> AppconsentrequestListUserconsentrequestsAsync(AppconsentrequestListUserconsentrequestsParameter parameter)
        {
            return await this.SendAsync<AppconsentrequestListUserconsentrequestsParameter, AppconsentrequestListUserconsentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestListUserconsentrequestsResponse> AppconsentrequestListUserconsentrequestsAsync(AppconsentrequestListUserconsentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppconsentrequestListUserconsentrequestsParameter, AppconsentrequestListUserconsentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
