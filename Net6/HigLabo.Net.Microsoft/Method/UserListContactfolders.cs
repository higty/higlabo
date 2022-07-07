using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListContactfoldersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_ContactFolders,
            Users_IdOrUserPrincipalName_ContactFolders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_ContactFolders: return $"/me/contactFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_ContactFolders: return $"/users/{IdOrUserPrincipalName}/contactFolders";
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
    public partial class UserListContactfoldersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/contactfolder?view=graph-rest-1.0
        /// </summary>
        public partial class ContactFolder
        {
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? ParentFolderId { get; set; }
        }

        public ContactFolder[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListContactfoldersResponse> UserListContactfoldersAsync()
        {
            var p = new UserListContactfoldersParameter();
            return await this.SendAsync<UserListContactfoldersParameter, UserListContactfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListContactfoldersResponse> UserListContactfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new UserListContactfoldersParameter();
            return await this.SendAsync<UserListContactfoldersParameter, UserListContactfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListContactfoldersResponse> UserListContactfoldersAsync(UserListContactfoldersParameter parameter)
        {
            return await this.SendAsync<UserListContactfoldersParameter, UserListContactfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListContactfoldersResponse> UserListContactfoldersAsync(UserListContactfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListContactfoldersParameter, UserListContactfoldersResponse>(parameter, cancellationToken);
        }
    }
}
