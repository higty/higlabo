using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
    /// </summary>
    public partial class UserListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users: return $"/users";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Users,
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
    public partial class UserListResponse : RestApiResponse<User>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListResponse> UserListAsync()
        {
            var p = new UserListParameter();
            return await this.SendAsync<UserListParameter, UserListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListResponse> UserListAsync(CancellationToken cancellationToken)
        {
            var p = new UserListParameter();
            return await this.SendAsync<UserListParameter, UserListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListResponse> UserListAsync(UserListParameter parameter)
        {
            return await this.SendAsync<UserListParameter, UserListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListResponse> UserListAsync(UserListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListParameter, UserListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<User> UserListEnumerateAsync(UserListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListParameter, UserListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<User>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
