using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
    /// </summary>
    public partial class UserListRegistereddevicesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_RegisteredDevices: return $"/me/registeredDevices";
                    case ApiPath.Users_IdOrUserPrincipalName_RegisteredDevices: return $"/users/{IdOrUserPrincipalName}/registeredDevices";
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
            Me_RegisteredDevices,
            Users_IdOrUserPrincipalName_RegisteredDevices,
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
    public partial class UserListRegistereddevicesResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync()
        {
            var p = new UserListRegistereddevicesParameter();
            return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync(CancellationToken cancellationToken)
        {
            var p = new UserListRegistereddevicesParameter();
            return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync(UserListRegistereddevicesParameter parameter)
        {
            return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-registereddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListRegistereddevicesResponse> UserListRegistereddevicesAsync(UserListRegistereddevicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListRegistereddevicesParameter, UserListRegistereddevicesResponse>(parameter, cancellationToken);
        }
    }
}
