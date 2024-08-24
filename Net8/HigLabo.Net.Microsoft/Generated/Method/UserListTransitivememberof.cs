using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class UserListTransitiveMemberofParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class UserListTransitiveMemberofResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListTransitiveMemberofResponse> UserListTransitiveMemberofAsync()
        {
            var p = new UserListTransitiveMemberofParameter();
            return await this.SendAsync<UserListTransitiveMemberofParameter, UserListTransitiveMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListTransitiveMemberofResponse> UserListTransitiveMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new UserListTransitiveMemberofParameter();
            return await this.SendAsync<UserListTransitiveMemberofParameter, UserListTransitiveMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListTransitiveMemberofResponse> UserListTransitiveMemberofAsync(UserListTransitiveMemberofParameter parameter)
        {
            return await this.SendAsync<UserListTransitiveMemberofParameter, UserListTransitiveMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListTransitiveMemberofResponse> UserListTransitiveMemberofAsync(UserListTransitiveMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListTransitiveMemberofParameter, UserListTransitiveMemberofResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> UserListTransitiveMemberofEnumerateAsync(UserListTransitiveMemberofParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListTransitiveMemberofParameter, UserListTransitiveMemberofResponse>(parameter, cancellationToken);
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
