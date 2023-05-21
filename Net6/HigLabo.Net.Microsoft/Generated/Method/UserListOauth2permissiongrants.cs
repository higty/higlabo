using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
    /// </summary>
    public partial class UserListOauth2permissiongrantsParameter : IRestApiParameter, IQueryParameterProperty
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
            ClientId,
            ConsentType,
            Id,
            PrincipalId,
            ResourceId,
            Scope,
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
    public partial class UserListOauth2permissiongrantsResponse : RestApiResponse
    {
        public OAuth2PermissionGrant[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOauth2permissiongrantsResponse> UserListOauth2permissiongrantsAsync()
        {
            var p = new UserListOauth2permissiongrantsParameter();
            return await this.SendAsync<UserListOauth2permissiongrantsParameter, UserListOauth2permissiongrantsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOauth2permissiongrantsResponse> UserListOauth2permissiongrantsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListOauth2permissiongrantsParameter();
            return await this.SendAsync<UserListOauth2permissiongrantsParameter, UserListOauth2permissiongrantsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOauth2permissiongrantsResponse> UserListOauth2permissiongrantsAsync(UserListOauth2permissiongrantsParameter parameter)
        {
            return await this.SendAsync<UserListOauth2permissiongrantsParameter, UserListOauth2permissiongrantsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOauth2permissiongrantsResponse> UserListOauth2permissiongrantsAsync(UserListOauth2permissiongrantsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListOauth2permissiongrantsParameter, UserListOauth2permissiongrantsResponse>(parameter, cancellationToken);
        }
    }
}
