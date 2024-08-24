using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class AppconsentRequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests_Id: return $"/identityGovernance/appConsent/appConsentRequests/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AppConsent_AppConsentRequests_Id,
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
    public partial class AppconsentRequestGetResponse : RestApiResponse
    {
        public string? AppDisplayName { get; set; }
        public string? AppId { get; set; }
        public string? Id { get; set; }
        public AppConsentRequestScope[]? PendingScopes { get; set; }
        public UserConsentRequest[]? UserConsentRequests { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentRequestGetResponse> AppconsentRequestGetAsync()
        {
            var p = new AppconsentRequestGetParameter();
            return await this.SendAsync<AppconsentRequestGetParameter, AppconsentRequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentRequestGetResponse> AppconsentRequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new AppconsentRequestGetParameter();
            return await this.SendAsync<AppconsentRequestGetParameter, AppconsentRequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentRequestGetResponse> AppconsentRequestGetAsync(AppconsentRequestGetParameter parameter)
        {
            return await this.SendAsync<AppconsentRequestGetParameter, AppconsentRequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentRequestGetResponse> AppconsentRequestGetAsync(AppconsentRequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppconsentRequestGetParameter, AppconsentRequestGetResponse>(parameter, cancellationToken);
        }
    }
}
