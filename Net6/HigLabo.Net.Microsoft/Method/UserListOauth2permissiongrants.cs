using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListOauth2permissiongrantsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Oauth2PermissionGrants,
            Users_IdOrUserPrincipalName_Oauth2PermissionGrants,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Oauth2PermissionGrants: return $"/me/oauth2PermissionGrants";
                    case ApiPath.Users_IdOrUserPrincipalName_Oauth2PermissionGrants: return $"/users/{IdOrUserPrincipalName}/oauth2PermissionGrants";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserListOauth2permissiongrantsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/oauth2permissiongrant?view=graph-rest-1.0
        /// </summary>
        public partial class OAuth2PermissionGrant
        {
            public string? Id { get; set; }
            public string? ClientId { get; set; }
            public string? ConsentType { get; set; }
            public string? PrincipalId { get; set; }
            public string? ResourceId { get; set; }
            public string? Scope { get; set; }
        }

        public OAuth2PermissionGrant[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOauth2permissiongrantsResponse> UserListOauth2permissiongrantsAsync()
        {
            var p = new UserListOauth2permissiongrantsParameter();
            return await this.SendAsync<UserListOauth2permissiongrantsParameter, UserListOauth2permissiongrantsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOauth2permissiongrantsResponse> UserListOauth2permissiongrantsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListOauth2permissiongrantsParameter();
            return await this.SendAsync<UserListOauth2permissiongrantsParameter, UserListOauth2permissiongrantsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOauth2permissiongrantsResponse> UserListOauth2permissiongrantsAsync(UserListOauth2permissiongrantsParameter parameter)
        {
            return await this.SendAsync<UserListOauth2permissiongrantsParameter, UserListOauth2permissiongrantsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOauth2permissiongrantsResponse> UserListOauth2permissiongrantsAsync(UserListOauth2permissiongrantsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListOauth2permissiongrantsParameter, UserListOauth2permissiongrantsResponse>(parameter, cancellationToken);
        }
    }
}
