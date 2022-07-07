using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactfolderListChildfoldersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_ContactFolders_Id_ChildFolders,
            Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_ContactFolders_Id_ChildFolders: return $"/me/contactFolders/{Id}/childFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders: return $"/users/{IdOrUserPrincipalName}/contactFolders/{Id}/childFolders";
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
    public partial class ContactfolderListChildfoldersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderListChildfoldersResponse> ContactfolderListChildfoldersAsync()
        {
            var p = new ContactfolderListChildfoldersParameter();
            return await this.SendAsync<ContactfolderListChildfoldersParameter, ContactfolderListChildfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderListChildfoldersResponse> ContactfolderListChildfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new ContactfolderListChildfoldersParameter();
            return await this.SendAsync<ContactfolderListChildfoldersParameter, ContactfolderListChildfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderListChildfoldersResponse> ContactfolderListChildfoldersAsync(ContactfolderListChildfoldersParameter parameter)
        {
            return await this.SendAsync<ContactfolderListChildfoldersParameter, ContactfolderListChildfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderListChildfoldersResponse> ContactfolderListChildfoldersAsync(ContactfolderListChildfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactfolderListChildfoldersParameter, ContactfolderListChildfoldersResponse>(parameter, cancellationToken);
        }
    }
}
