using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class AppconsentapprovalrouteListAppconsentrequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests: return $"/identityGovernance/appConsent/appConsentRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppDisplayName,
            AppId,
            Id,
            PendingScopes,
            UserConsentRequests,
        }
        public enum ApiPath
        {
            IdentityGovernance_AppConsent_AppConsentRequests,
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
    public partial class AppconsentapprovalrouteListAppconsentrequestsResponse : RestApiResponse
    {
        public AppConsentRequest[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentapprovalrouteListAppconsentrequestsResponse> AppconsentapprovalrouteListAppconsentrequestsAsync()
        {
            var p = new AppconsentapprovalrouteListAppconsentrequestsParameter();
            return await this.SendAsync<AppconsentapprovalrouteListAppconsentrequestsParameter, AppconsentapprovalrouteListAppconsentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentapprovalrouteListAppconsentrequestsResponse> AppconsentapprovalrouteListAppconsentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new AppconsentapprovalrouteListAppconsentrequestsParameter();
            return await this.SendAsync<AppconsentapprovalrouteListAppconsentrequestsParameter, AppconsentapprovalrouteListAppconsentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentapprovalrouteListAppconsentrequestsResponse> AppconsentapprovalrouteListAppconsentrequestsAsync(AppconsentapprovalrouteListAppconsentrequestsParameter parameter)
        {
            return await this.SendAsync<AppconsentapprovalrouteListAppconsentrequestsParameter, AppconsentapprovalrouteListAppconsentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentapprovalroute-list-appconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentapprovalrouteListAppconsentrequestsResponse> AppconsentapprovalrouteListAppconsentrequestsAsync(AppconsentapprovalrouteListAppconsentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppconsentapprovalrouteListAppconsentrequestsParameter, AppconsentapprovalrouteListAppconsentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
