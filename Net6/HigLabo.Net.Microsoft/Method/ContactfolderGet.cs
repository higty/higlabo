using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContactfolderGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ContactfolderGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderGetResponse> ContactfolderGetAsync()
        {
            var p = new ContactfolderGetParameter();
            return await this.SendAsync<ContactfolderGetParameter, ContactfolderGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderGetResponse> ContactfolderGetAsync(CancellationToken cancellationToken)
        {
            var p = new ContactfolderGetParameter();
            return await this.SendAsync<ContactfolderGetParameter, ContactfolderGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderGetResponse> ContactfolderGetAsync(ContactfolderGetParameter parameter)
        {
            return await this.SendAsync<ContactfolderGetParameter, ContactfolderGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contactfolder-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ContactfolderGetResponse> ContactfolderGetAsync(ContactfolderGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContactfolderGetParameter, ContactfolderGetResponse>(parameter, cancellationToken);
        }
    }
}
