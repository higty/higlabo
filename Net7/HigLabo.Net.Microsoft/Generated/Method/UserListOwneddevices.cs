using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
    /// </summary>
    public partial class UserListOwneddevicesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_OwnedDevices: return $"/me/ownedDevices";
                    case ApiPath.Users_IdOrUserPrincipalName_OwnedDevices: return $"/users/{IdOrUserPrincipalName}/ownedDevices";
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
            Me_OwnedDevices,
            Users_IdOrUserPrincipalName_OwnedDevices,
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
    public partial class UserListOwneddevicesResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOwneddevicesResponse> UserListOwneddevicesAsync()
        {
            var p = new UserListOwneddevicesParameter();
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOwneddevicesResponse> UserListOwneddevicesAsync(CancellationToken cancellationToken)
        {
            var p = new UserListOwneddevicesParameter();
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOwneddevicesResponse> UserListOwneddevicesAsync(UserListOwneddevicesParameter parameter)
        {
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListOwneddevicesResponse> UserListOwneddevicesAsync(UserListOwneddevicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(parameter, cancellationToken);
        }
    }
}
