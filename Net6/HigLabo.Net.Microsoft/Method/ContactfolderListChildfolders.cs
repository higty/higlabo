using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactfolderListChildfoldersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_ContactFolders_Id_ChildFolders: return $"/me/contactFolders/{Id}/childFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders: return $"/users/{IdOrUserPrincipalName}/contactFolders/{Id}/childFolders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            ParentFolderId,
            ChildFolders,
            Contacts,
            MultiValueExtendedProperties,
            SingleValueExtendedProperties,
        }
        public enum ApiPath
        {
            Me_ContactFolders_Id_ChildFolders,
            Users_IdOrUserPrincipalName_ContactFolders_Id_ChildFolders,
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
    public partial class ContactfolderListChildfoldersResponse : RestApiResponse
    {
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
