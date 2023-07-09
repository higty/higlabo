using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class UserListTransitivememberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_TransitiveMemberOf: return $"/me/transitiveMemberOf";
                    case ApiPath.Users_IdOrUserPrincipalName_TransitiveMemberOf: return $"/users/{IdOrUserPrincipalName}/transitiveMemberOf";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            Me_TransitiveMemberOf,
            Users_IdOrUserPrincipalName_TransitiveMemberOf,
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
    public partial class UserListTransitivememberofResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListTransitivememberofResponse> UserListTransitivememberofAsync()
        {
            var p = new UserListTransitivememberofParameter();
            return await this.SendAsync<UserListTransitivememberofParameter, UserListTransitivememberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListTransitivememberofResponse> UserListTransitivememberofAsync(CancellationToken cancellationToken)
        {
            var p = new UserListTransitivememberofParameter();
            return await this.SendAsync<UserListTransitivememberofParameter, UserListTransitivememberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListTransitivememberofResponse> UserListTransitivememberofAsync(UserListTransitivememberofParameter parameter)
        {
            return await this.SendAsync<UserListTransitivememberofParameter, UserListTransitivememberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListTransitivememberofResponse> UserListTransitivememberofAsync(UserListTransitivememberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListTransitivememberofParameter, UserListTransitivememberofResponse>(parameter, cancellationToken);
        }
    }
}
