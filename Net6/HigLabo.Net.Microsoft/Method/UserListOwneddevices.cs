using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListOwneddevicesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_OwnedDevices,
            Users_IdOrUserPrincipalName_OwnedDevices,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_OwnedDevices: return $"/me/ownedDevices";
                    case ApiPath.Users_IdOrUserPrincipalName_OwnedDevices: return $"/users/{IdOrUserPrincipalName}/ownedDevices";
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
    public partial class UserListOwneddevicesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOwneddevicesResponse> UserListOwneddevicesAsync()
        {
            var p = new UserListOwneddevicesParameter();
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOwneddevicesResponse> UserListOwneddevicesAsync(CancellationToken cancellationToken)
        {
            var p = new UserListOwneddevicesParameter();
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOwneddevicesResponse> UserListOwneddevicesAsync(UserListOwneddevicesParameter parameter)
        {
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOwneddevicesResponse> UserListOwneddevicesAsync(UserListOwneddevicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(parameter, cancellationToken);
        }
    }
}
