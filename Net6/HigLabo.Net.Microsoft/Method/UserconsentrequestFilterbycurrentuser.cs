using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserconsentrequestFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AppConsent_AppConsentRequests_Id_UserConsentRequests_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests_Id_UserConsentRequests_FilterByCurrentUser: return $"/identityGovernance/appConsent/appConsentRequests/{Id}/userConsentRequests/filterByCurrentUser";
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
    public partial class UserconsentrequestFilterbycurrentuserResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UserconsentrequestFilterbycurrentuserResponse> UserconsentrequestFilterbycurrentuserAsync()
        {
            var p = new UserconsentrequestFilterbycurrentuserParameter();
            return await this.SendAsync<UserconsentrequestFilterbycurrentuserParameter, UserconsentrequestFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UserconsentrequestFilterbycurrentuserResponse> UserconsentrequestFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new UserconsentrequestFilterbycurrentuserParameter();
            return await this.SendAsync<UserconsentrequestFilterbycurrentuserParameter, UserconsentrequestFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UserconsentrequestFilterbycurrentuserResponse> UserconsentrequestFilterbycurrentuserAsync(UserconsentrequestFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<UserconsentrequestFilterbycurrentuserParameter, UserconsentrequestFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UserconsentrequestFilterbycurrentuserResponse> UserconsentrequestFilterbycurrentuserAsync(UserconsentrequestFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserconsentrequestFilterbycurrentuserParameter, UserconsentrequestFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
