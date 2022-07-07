using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AppconsentrequestFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AppConsent_AppConsentRequests_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests_FilterByCurrentUser: return $"/identityGovernance/appConsent/appConsentRequests/filterByCurrentUser";
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
    public partial class AppconsentrequestFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/appconsentrequest?view=graph-rest-1.0
        /// </summary>
        public partial class AppConsentRequest
        {
            public string? AppDisplayName { get; set; }
            public string? AppId { get; set; }
            public string? Id { get; set; }
            public AppConsentRequestScope[]? PendingScopes { get; set; }
        }

        public AppConsentRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestFilterbycurrentuserResponse> AppconsentrequestFilterbycurrentuserAsync()
        {
            var p = new AppconsentrequestFilterbycurrentuserParameter();
            return await this.SendAsync<AppconsentrequestFilterbycurrentuserParameter, AppconsentrequestFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestFilterbycurrentuserResponse> AppconsentrequestFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new AppconsentrequestFilterbycurrentuserParameter();
            return await this.SendAsync<AppconsentrequestFilterbycurrentuserParameter, AppconsentrequestFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestFilterbycurrentuserResponse> AppconsentrequestFilterbycurrentuserAsync(AppconsentrequestFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<AppconsentrequestFilterbycurrentuserParameter, AppconsentrequestFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestFilterbycurrentuserResponse> AppconsentrequestFilterbycurrentuserAsync(AppconsentrequestFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppconsentrequestFilterbycurrentuserParameter, AppconsentrequestFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
