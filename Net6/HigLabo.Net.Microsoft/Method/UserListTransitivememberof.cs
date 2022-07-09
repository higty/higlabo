using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListTransitivememberofResponse> UserListTransitivememberofAsync()
        {
            var p = new UserListTransitivememberofParameter();
            return await this.SendAsync<UserListTransitivememberofParameter, UserListTransitivememberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListTransitivememberofResponse> UserListTransitivememberofAsync(CancellationToken cancellationToken)
        {
            var p = new UserListTransitivememberofParameter();
            return await this.SendAsync<UserListTransitivememberofParameter, UserListTransitivememberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListTransitivememberofResponse> UserListTransitivememberofAsync(UserListTransitivememberofParameter parameter)
        {
            return await this.SendAsync<UserListTransitivememberofParameter, UserListTransitivememberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListTransitivememberofResponse> UserListTransitivememberofAsync(UserListTransitivememberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListTransitivememberofParameter, UserListTransitivememberofResponse>(parameter, cancellationToken);
        }
    }
}
