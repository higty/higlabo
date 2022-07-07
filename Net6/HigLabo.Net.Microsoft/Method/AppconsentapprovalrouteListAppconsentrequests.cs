using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AppconsentapprovalrouteListAppconsentrequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AppConsent_AppConsentRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests: return $"/identityGovernance/appConsent/appConsentRequests";
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
    public partial class AppconsentapprovalrouteListAppconsentrequestsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentapprovalrouteListAppconsentrequestsResponse> AppconsentapprovalrouteListAppconsentrequestsAsync()
        {
            var p = new AppconsentapprovalrouteListAppconsentrequestsParameter();
            return await this.SendAsync<AppconsentapprovalrouteListAppconsentrequestsParameter, AppconsentapprovalrouteListAppconsentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentapprovalrouteListAppconsentrequestsResponse> AppconsentapprovalrouteListAppconsentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new AppconsentapprovalrouteListAppconsentrequestsParameter();
            return await this.SendAsync<AppconsentapprovalrouteListAppconsentrequestsParameter, AppconsentapprovalrouteListAppconsentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentapprovalrouteListAppconsentrequestsResponse> AppconsentapprovalrouteListAppconsentrequestsAsync(AppconsentapprovalrouteListAppconsentrequestsParameter parameter)
        {
            return await this.SendAsync<AppconsentapprovalrouteListAppconsentrequestsParameter, AppconsentapprovalrouteListAppconsentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentapprovalrouteListAppconsentrequestsResponse> AppconsentapprovalrouteListAppconsentrequestsAsync(AppconsentapprovalrouteListAppconsentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppconsentapprovalrouteListAppconsentrequestsParameter, AppconsentapprovalrouteListAppconsentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
