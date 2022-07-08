using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailfolderGetParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_MailFolders_Id: return $"/me/mailFolders/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_MailFolders_Id,
            Users_IdOrUserPrincipalName_MailFolders_Id,
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
    public partial class MailfolderGetResponse : RestApiResponse
    {
        public Int32? ChildFolderCount { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHidden { get; set; }
        public string? ParentFolderId { get; set; }
        public Int32? TotalItemCount { get; set; }
        public Int32? UnreadItemCount { get; set; }
        public MailFolder[]? ChildFolders { get; set; }
        public MessageRule[]? MessageRules { get; set; }
        public Message[]? Messages { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderGetResponse> MailfolderGetAsync()
        {
            var p = new MailfolderGetParameter();
            return await this.SendAsync<MailfolderGetParameter, MailfolderGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderGetResponse> MailfolderGetAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderGetParameter();
            return await this.SendAsync<MailfolderGetParameter, MailfolderGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderGetResponse> MailfolderGetAsync(MailfolderGetParameter parameter)
        {
            return await this.SendAsync<MailfolderGetParameter, MailfolderGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderGetResponse> MailfolderGetAsync(MailfolderGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderGetParameter, MailfolderGetResponse>(parameter, cancellationToken);
        }
    }
}
