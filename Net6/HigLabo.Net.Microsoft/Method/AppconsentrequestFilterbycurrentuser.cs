using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AppconsentrequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests_FilterByCurrentUser: return $"/identityGovernance/appConsent/appConsentRequests/filterByCurrentUser";
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
            IdentityGovernance_AppConsent_AppConsentRequests_FilterByCurrentUser,
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
    public partial class AppconsentrequestFilterbycurrentUserResponse : RestApiResponse
    {
        public AppConsentRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestFilterbycurrentUserResponse> AppconsentrequestFilterbycurrentUserAsync()
        {
            var p = new AppconsentrequestFilterbycurrentUserParameter();
            return await this.SendAsync<AppconsentrequestFilterbycurrentUserParameter, AppconsentrequestFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestFilterbycurrentUserResponse> AppconsentrequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AppconsentrequestFilterbycurrentUserParameter();
            return await this.SendAsync<AppconsentrequestFilterbycurrentUserParameter, AppconsentrequestFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestFilterbycurrentUserResponse> AppconsentrequestFilterbycurrentUserAsync(AppconsentrequestFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AppconsentrequestFilterbycurrentUserParameter, AppconsentrequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AppconsentrequestFilterbycurrentUserResponse> AppconsentrequestFilterbycurrentUserAsync(AppconsentrequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppconsentrequestFilterbycurrentUserParameter, AppconsentrequestFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
