using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailfolderListChildfoldersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_MailFolders_Id_ChildFolders,
            Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders_Id_ChildFolders: return $"/me/mailFolders/{Id}/childFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}/childFolders";
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
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class MailfolderListChildfoldersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListChildfoldersResponse> MailfolderListChildfoldersAsync()
        {
            var p = new MailfolderListChildfoldersParameter();
            return await this.SendAsync<MailfolderListChildfoldersParameter, MailfolderListChildfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListChildfoldersResponse> MailfolderListChildfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderListChildfoldersParameter();
            return await this.SendAsync<MailfolderListChildfoldersParameter, MailfolderListChildfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListChildfoldersResponse> MailfolderListChildfoldersAsync(MailfolderListChildfoldersParameter parameter)
        {
            return await this.SendAsync<MailfolderListChildfoldersParameter, MailfolderListChildfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListChildfoldersResponse> MailfolderListChildfoldersAsync(MailfolderListChildfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderListChildfoldersParameter, MailfolderListChildfoldersResponse>(parameter, cancellationToken);
        }
    }
}
