using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailfolderPostChildfoldersParameter : IRestApiParameter
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
                    case ApiPath.Me_MailFolders_Id_ChildFolders: return $"/me/mailFolders/{Id}/childFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}/childFolders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_MailFolders_Id_ChildFolders,
            Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders,
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
        public bool? IsHidden { get; set; }
        public Int32? ChildFolderCount { get; set; }
        public string? Id { get; set; }
        public string? ParentFolderId { get; set; }
        public Int32? TotalItemCount { get; set; }
        public Int32? UnreadItemCount { get; set; }
        public MailFolder[]? ChildFolders { get; set; }
        public MessageRule[]? MessageRules { get; set; }
        public Message[]? Messages { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class MailfolderPostChildfoldersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderPostChildfoldersResponse> MailfolderPostChildfoldersAsync()
        {
            var p = new MailfolderPostChildfoldersParameter();
            return await this.SendAsync<MailfolderPostChildfoldersParameter, MailfolderPostChildfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderPostChildfoldersResponse> MailfolderPostChildfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderPostChildfoldersParameter();
            return await this.SendAsync<MailfolderPostChildfoldersParameter, MailfolderPostChildfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderPostChildfoldersResponse> MailfolderPostChildfoldersAsync(MailfolderPostChildfoldersParameter parameter)
        {
            return await this.SendAsync<MailfolderPostChildfoldersParameter, MailfolderPostChildfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderPostChildfoldersResponse> MailfolderPostChildfoldersAsync(MailfolderPostChildfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderPostChildfoldersParameter, MailfolderPostChildfoldersResponse>(parameter, cancellationToken);
        }
    }
}
