using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Users,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users: return $"/users";
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
    }
    public partial class UserListResponse : RestApiResponse
    {
        public User[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListResponse> UserListAsync()
        {
            var p = new UserListParameter();
            return await this.SendAsync<UserListParameter, UserListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListResponse> UserListAsync(CancellationToken cancellationToken)
        {
            var p = new UserListParameter();
            return await this.SendAsync<UserListParameter, UserListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListResponse> UserListAsync(UserListParameter parameter)
        {
            return await this.SendAsync<UserListParameter, UserListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListResponse> UserListAsync(UserListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListParameter, UserListResponse>(parameter, cancellationToken);
        }
    }
}
