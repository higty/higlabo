using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class UserconsentrequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AppconsentrequestId { get; set; }
            public string? UserconsentrequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests_AppconsentrequestId_UserConsentRequests_UserconsentrequestId: return $"/identityGovernance/appConsent/appConsentRequests/{AppconsentrequestId}/userConsentRequests/{UserconsentrequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AppConsent_AppConsentRequests_AppconsentrequestId_UserConsentRequests_UserconsentrequestId,
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
    public partial class UserconsentrequestGetResponse : RestApiResponse
    {
        public string? ApprovalId { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? CustomData { get; set; }
        public string? Id { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public Approval? Approval { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserconsentrequestGetResponse> UserconsentrequestGetAsync()
        {
            var p = new UserconsentrequestGetParameter();
            return await this.SendAsync<UserconsentrequestGetParameter, UserconsentrequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserconsentrequestGetResponse> UserconsentrequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new UserconsentrequestGetParameter();
            return await this.SendAsync<UserconsentrequestGetParameter, UserconsentrequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserconsentrequestGetResponse> UserconsentrequestGetAsync(UserconsentrequestGetParameter parameter)
        {
            return await this.SendAsync<UserconsentrequestGetParameter, UserconsentrequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserconsentrequestGetResponse> UserconsentrequestGetAsync(UserconsentrequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserconsentrequestGetParameter, UserconsentrequestGetResponse>(parameter, cancellationToken);
        }
    }
}
