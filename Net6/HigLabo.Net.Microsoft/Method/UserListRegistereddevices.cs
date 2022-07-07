using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListRegistereddevicesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_RegisteredDevices,
            Users_IdOrUserPrincipalName_RegisteredDevices,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_RegisteredDevices: return $"/me/registeredDevices";
                    case ApiPath.Users_IdOrUserPrincipalName_RegisteredDevices: return $"/users/{IdOrUserPrincipalName}/registeredDevices";
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
    public partial class UserListRegistereddevicesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync()
        {
            var p = new UserListRegistereddevicesParameter();
            return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync(CancellationToken cancellationToken)
        {
            var p = new UserListRegistereddevicesParameter();
            return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync(UserListRegistereddevicesParameter parameter)
        {
            return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync(UserListRegistereddevicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(parameter, cancellationToken);
        }
    }
}
