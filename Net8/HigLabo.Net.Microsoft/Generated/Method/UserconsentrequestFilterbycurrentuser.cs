using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class UserconsentRequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class UserconsentRequestFilterbycurrentUserResponse : RestApiResponse<UserConsentRequest>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserconsentRequestFilterbycurrentUserResponse> UserconsentRequestFilterbycurrentUserAsync()
        {
            var p = new UserconsentRequestFilterbycurrentUserParameter();
            return await this.SendAsync<UserconsentRequestFilterbycurrentUserParameter, UserconsentRequestFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserconsentRequestFilterbycurrentUserResponse> UserconsentRequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new UserconsentRequestFilterbycurrentUserParameter();
            return await this.SendAsync<UserconsentRequestFilterbycurrentUserParameter, UserconsentRequestFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserconsentRequestFilterbycurrentUserResponse> UserconsentRequestFilterbycurrentUserAsync(UserconsentRequestFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<UserconsentRequestFilterbycurrentUserParameter, UserconsentRequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserconsentRequestFilterbycurrentUserResponse> UserconsentRequestFilterbycurrentUserAsync(UserconsentRequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserconsentRequestFilterbycurrentUserParameter, UserconsentRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userconsentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UserConsentRequest> UserconsentRequestFilterbycurrentUserEnumerateAsync(UserconsentRequestFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserconsentRequestFilterbycurrentUserParameter, UserconsentRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
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
