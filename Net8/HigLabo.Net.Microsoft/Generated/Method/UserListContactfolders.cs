using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
    /// </summary>
    public partial class UserListContactFoldersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_ContactFolders: return $"/me/contactFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_ContactFolders: return $"/users/{IdOrUserPrincipalName}/contactFolders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_ContactFolders,
            Users_IdOrUserPrincipalName_ContactFolders,
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
    public partial class UserListContactFoldersResponse : RestApiResponse<ContactFolder>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactFoldersResponse> UserListContactFoldersAsync()
        {
            var p = new UserListContactFoldersParameter();
            return await this.SendAsync<UserListContactFoldersParameter, UserListContactFoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactFoldersResponse> UserListContactFoldersAsync(CancellationToken cancellationToken)
        {
            var p = new UserListContactFoldersParameter();
            return await this.SendAsync<UserListContactFoldersParameter, UserListContactFoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactFoldersResponse> UserListContactFoldersAsync(UserListContactFoldersParameter parameter)
        {
            return await this.SendAsync<UserListContactFoldersParameter, UserListContactFoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactFoldersResponse> UserListContactFoldersAsync(UserListContactFoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListContactFoldersParameter, UserListContactFoldersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ContactFolder> UserListContactFoldersEnumerateAsync(UserListContactFoldersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListContactFoldersParameter, UserListContactFoldersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ContactFolder>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
