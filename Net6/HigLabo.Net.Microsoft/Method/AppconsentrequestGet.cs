using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AppconsentrequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
    public partial class AppconsentrequestGetResponse : RestApiResponse
    {
        public string? AppDisplayName { get; set; }
        public string? AppId { get; set; }
        public string? Id { get; set; }
        public AppConsentRequestScope[]? PendingScopes { get; set; }
        public UserConsentRequest[]? UserConsentRequests { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestGetResponse> AppconsentrequestGetAsync()
        {
            var p = new AppconsentrequestGetParameter();
            return await this.SendAsync<AppconsentrequestGetParameter, AppconsentrequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestGetResponse> AppconsentrequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new AppconsentrequestGetParameter();
            return await this.SendAsync<AppconsentrequestGetParameter, AppconsentrequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestGetResponse> AppconsentrequestGetAsync(AppconsentrequestGetParameter parameter)
        {
            return await this.SendAsync<AppconsentrequestGetParameter, AppconsentrequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestGetResponse> AppconsentrequestGetAsync(AppconsentrequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppconsentrequestGetParameter, AppconsentrequestGetResponse>(parameter, cancellationToken);
        }
    }
}
