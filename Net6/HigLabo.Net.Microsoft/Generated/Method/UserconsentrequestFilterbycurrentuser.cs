using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class UserconsentrequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AppConsent_AppConsentRequests_Id_UserConsentRequests_FilterByCurrentUser: return $"/identityGovernance/appConsent/appConsentRequests/{Id}/userConsentRequests/filterByCurrentUser";
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
            IdentityGovernance_AppConsent_AppConsentRequests_Id_UserConsentRequests_FilterByCurrentUser,
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
    public partial class UserconsentrequestFilterbycurrentUserResponse : RestApiResponse
    {
        public UserConsentRequest[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UserconsentrequestFilterbycurrentUserResponse> UserconsentrequestFilterbycurrentUserAsync()
        {
            var p = new UserconsentrequestFilterbycurrentUserParameter();
            return await this.SendAsync<UserconsentrequestFilterbycurrentUserParameter, UserconsentrequestFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UserconsentrequestFilterbycurrentUserResponse> UserconsentrequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new UserconsentrequestFilterbycurrentUserParameter();
            return await this.SendAsync<UserconsentrequestFilterbycurrentUserParameter, UserconsentrequestFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UserconsentrequestFilterbycurrentUserResponse> UserconsentrequestFilterbycurrentUserAsync(UserconsentrequestFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<UserconsentrequestFilterbycurrentUserParameter, UserconsentrequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UserconsentrequestFilterbycurrentUserResponse> UserconsentrequestFilterbycurrentUserAsync(UserconsentrequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserconsentrequestFilterbycurrentUserParameter, UserconsentrequestFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
