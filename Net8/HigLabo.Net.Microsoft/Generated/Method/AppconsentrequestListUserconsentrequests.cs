using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class AppconsentRequestListUserconsentRequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests_Id_UserConsentRequests: return $"/identityGovernance/appConsent/appConsentRequests/{Id}/userConsentRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AppConsent_AppConsentRequests_Id_UserConsentRequests,
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
    public partial class AppconsentRequestListUserconsentRequestsResponse : RestApiResponse<UserConsentRequest>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentRequestListUserconsentRequestsResponse> AppconsentRequestListUserconsentRequestsAsync()
        {
            var p = new AppconsentRequestListUserconsentRequestsParameter();
            return await this.SendAsync<AppconsentRequestListUserconsentRequestsParameter, AppconsentRequestListUserconsentRequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentRequestListUserconsentRequestsResponse> AppconsentRequestListUserconsentRequestsAsync(CancellationToken cancellationToken)
        {
            var p = new AppconsentRequestListUserconsentRequestsParameter();
            return await this.SendAsync<AppconsentRequestListUserconsentRequestsParameter, AppconsentRequestListUserconsentRequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentRequestListUserconsentRequestsResponse> AppconsentRequestListUserconsentRequestsAsync(AppconsentRequestListUserconsentRequestsParameter parameter)
        {
            return await this.SendAsync<AppconsentRequestListUserconsentRequestsParameter, AppconsentRequestListUserconsentRequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentRequestListUserconsentRequestsResponse> AppconsentRequestListUserconsentRequestsAsync(AppconsentRequestListUserconsentRequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppconsentRequestListUserconsentRequestsParameter, AppconsentRequestListUserconsentRequestsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UserConsentRequest> AppconsentRequestListUserconsentRequestsEnumerateAsync(AppconsentRequestListUserconsentRequestsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AppconsentRequestListUserconsentRequestsParameter, AppconsentRequestListUserconsentRequestsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<UserConsentRequest>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
