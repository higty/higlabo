using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListMailfoldersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_MailFolders,
            Users_IdOrUserPrincipalName_MailFolders,
            Me_MailFolders_,
            Users_IdOrUserPrincipalName_MailFolders_,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders: return $"/me/mailFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders: return $"/users/{IdOrUserPrincipalName}/mailFolders";
                    case ApiPath.Me_MailFolders_: return $"/me/mailFolders/";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_: return $"/users/{IdOrUserPrincipalName}/mailFolders/";
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
    public partial class UserListMailfoldersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/mailfolder?view=graph-rest-1.0
        /// </summary>
        public partial class MailFolder
        {
            public Int32? ChildFolderCount { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public bool? IsHidden { get; set; }
            public string? ParentFolderId { get; set; }
            public Int32? TotalItemCount { get; set; }
            public Int32? UnreadItemCount { get; set; }
        }

        public MailFolder[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMailfoldersResponse> UserListMailfoldersAsync()
        {
            var p = new UserListMailfoldersParameter();
            return await this.SendAsync<UserListMailfoldersParameter, UserListMailfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMailfoldersResponse> UserListMailfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new UserListMailfoldersParameter();
            return await this.SendAsync<UserListMailfoldersParameter, UserListMailfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMailfoldersResponse> UserListMailfoldersAsync(UserListMailfoldersParameter parameter)
        {
            return await this.SendAsync<UserListMailfoldersParameter, UserListMailfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMailfoldersResponse> UserListMailfoldersAsync(UserListMailfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListMailfoldersParameter, UserListMailfoldersResponse>(parameter, cancellationToken);
        }
    }
}
