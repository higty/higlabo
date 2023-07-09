using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class AppconsentrequestListUserconsentrequestsParameter : IRestApiParameter, IQueryParameterProperty
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
            ApprovalId,
            CompletedDateTime,
            CreatedBy,
            CreatedDateTime,
            CustomData,
            Id,
            Reason,
            Status,
            Approval,
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
    public partial class AppconsentrequestListUserconsentrequestsResponse : RestApiResponse
    {
        public UserConsentRequest[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentrequestListUserconsentrequestsResponse> AppconsentrequestListUserconsentrequestsAsync()
        {
            var p = new AppconsentrequestListUserconsentrequestsParameter();
            return await this.SendAsync<AppconsentrequestListUserconsentrequestsParameter, AppconsentrequestListUserconsentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentrequestListUserconsentrequestsResponse> AppconsentrequestListUserconsentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new AppconsentrequestListUserconsentrequestsParameter();
            return await this.SendAsync<AppconsentrequestListUserconsentrequestsParameter, AppconsentrequestListUserconsentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentrequestListUserconsentrequestsResponse> AppconsentrequestListUserconsentrequestsAsync(AppconsentrequestListUserconsentrequestsParameter parameter)
        {
            return await this.SendAsync<AppconsentrequestListUserconsentrequestsParameter, AppconsentrequestListUserconsentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appconsentrequest-list-userconsentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppconsentrequestListUserconsentrequestsResponse> AppconsentrequestListUserconsentrequestsAsync(AppconsentrequestListUserconsentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppconsentrequestListUserconsentrequestsParameter, AppconsentrequestListUserconsentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
