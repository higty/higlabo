using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListMemberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_MemberOf,
            Users_IdOrUserPrincipalName_MemberOf,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MemberOf: return $"/me/memberOf";
                    case ApiPath.Users_IdOrUserPrincipalName_MemberOf: return $"/users/{IdOrUserPrincipalName}/memberOf";
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
    public partial class UserListMemberofResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryobject?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryObject
        {
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMemberofResponse> UserListMemberofAsync()
        {
            var p = new UserListMemberofParameter();
            return await this.SendAsync<UserListMemberofParameter, UserListMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMemberofResponse> UserListMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new UserListMemberofParameter();
            return await this.SendAsync<UserListMemberofParameter, UserListMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMemberofResponse> UserListMemberofAsync(UserListMemberofParameter parameter)
        {
            return await this.SendAsync<UserListMemberofParameter, UserListMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMemberofResponse> UserListMemberofAsync(UserListMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListMemberofParameter, UserListMemberofResponse>(parameter, cancellationToken);
        }
    }
}
