using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
    /// </summary>
    public partial class UserListOauth2PermissionGrantsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Oauth2PermissionGrants: return $"/me/oauth2PermissionGrants";
                    case ApiPath.Users_IdOrUserPrincipalName_Oauth2PermissionGrants: return $"/users/{IdOrUserPrincipalName}/oauth2PermissionGrants";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Oauth2PermissionGrants,
            Users_IdOrUserPrincipalName_Oauth2PermissionGrants,
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
    public partial class UserListOauth2PermissionGrantsResponse : RestApiResponse<OAuth2PermissionGrant>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOauth2PermissionGrantsResponse> UserListOauth2PermissionGrantsAsync()
        {
            var p = new UserListOauth2PermissionGrantsParameter();
            return await this.SendAsync<UserListOauth2PermissionGrantsParameter, UserListOauth2PermissionGrantsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOauth2PermissionGrantsResponse> UserListOauth2PermissionGrantsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListOauth2PermissionGrantsParameter();
            return await this.SendAsync<UserListOauth2PermissionGrantsParameter, UserListOauth2PermissionGrantsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOauth2PermissionGrantsResponse> UserListOauth2PermissionGrantsAsync(UserListOauth2PermissionGrantsParameter parameter)
        {
            return await this.SendAsync<UserListOauth2PermissionGrantsParameter, UserListOauth2PermissionGrantsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOauth2PermissionGrantsResponse> UserListOauth2PermissionGrantsAsync(UserListOauth2PermissionGrantsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListOauth2PermissionGrantsParameter, UserListOauth2PermissionGrantsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<OAuth2PermissionGrant> UserListOauth2PermissionGrantsEnumerateAsync(UserListOauth2PermissionGrantsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListOauth2PermissionGrantsParameter, UserListOauth2PermissionGrantsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<OAuth2PermissionGrant>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
