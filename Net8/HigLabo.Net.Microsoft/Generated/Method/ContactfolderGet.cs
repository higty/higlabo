using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
    /// </summary>
    public partial class ContactFolderGetParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_ContactFolders_Id: return $"/me/contactFolders/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_ContactFolders_Id: return $"/users/{IdOrUserPrincipalName}/contactFolders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_ContactFolders_Id,
            Users_IdOrUserPrincipalName_ContactFolders_Id,
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
    public partial class ContactFolderGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? ParentFolderId { get; set; }
        public ContactFolder[]? ChildFolders { get; set; }
        public Contact[]? Contacts { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactFolderGetResponse> ContactFolderGetAsync()
        {
            var p = new ContactFolderGetParameter();
            return await this.SendAsync<ContactFolderGetParameter, ContactFolderGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactFolderGetResponse> ContactFolderGetAsync(CancellationToken cancellationToken)
        {
            var p = new ContactFolderGetParameter();
            return await this.SendAsync<ContactFolderGetParameter, ContactFolderGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactFolderGetResponse> ContactFolderGetAsync(ContactFolderGetParameter parameter)
        {
            return await this.SendAsync<ContactFolderGetParameter, ContactFolderGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContactFolderGetResponse> ContactFolderGetAsync(ContactFolderGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactFolderGetParameter, ContactFolderGetResponse>(parameter, cancellationToken);
        }
    }
}
