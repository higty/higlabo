using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

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
    public partial class UserListOwneddevicesResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOwneddevicesResponse> UserListOwneddevicesAsync()
        {
            var p = new UserListOwneddevicesParameter();
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOwneddevicesResponse> UserListOwneddevicesAsync(CancellationToken cancellationToken)
        {
            var p = new UserListOwneddevicesParameter();
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOwneddevicesResponse> UserListOwneddevicesAsync(UserListOwneddevicesParameter parameter)
        {
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOwneddevicesResponse> UserListOwneddevicesAsync(UserListOwneddevicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-owneddevices?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> UserListOwneddevicesEnumerateAsync(UserListOwneddevicesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListOwneddevicesParameter, UserListOwneddevicesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
