using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactfolderPostChildfoldersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? ParentFolderId { get; set; }
        public ContactFolder[]? ChildFolders { get; set; }
        public Contact[]? Contacts { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class ContactfolderPostChildfoldersResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? ParentFolderId { get; set; }
        public ContactFolder[]? ChildFolders { get; set; }
        public Contact[]? Contacts { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderPostChildfoldersResponse> ContactfolderPostChildfoldersAsync()
        {
            var p = new ContactfolderPostChildfoldersParameter();
            return await this.SendAsync<ContactfolderPostChildfoldersParameter, ContactfolderPostChildfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderPostChildfoldersResponse> ContactfolderPostChildfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new ContactfolderPostChildfoldersParameter();
            return await this.SendAsync<ContactfolderPostChildfoldersParameter, ContactfolderPostChildfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderPostChildfoldersResponse> ContactfolderPostChildfoldersAsync(ContactfolderPostChildfoldersParameter parameter)
        {
            return await this.SendAsync<ContactfolderPostChildfoldersParameter, ContactfolderPostChildfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderPostChildfoldersResponse> ContactfolderPostChildfoldersAsync(ContactfolderPostChildfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactfolderPostChildfoldersParameter, ContactfolderPostChildfoldersResponse>(parameter, cancellationToken);
        }
    }
}
