using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MailFolderPostChildFoldersParameter : IRestApiParameter
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
    public partial class MailFolderPostChildFoldersResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderPostChildFoldersResponse> MailFolderPostChildFoldersAsync()
        {
            var p = new MailFolderPostChildFoldersParameter();
            return await this.SendAsync<MailFolderPostChildFoldersParameter, MailFolderPostChildFoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderPostChildFoldersResponse> MailFolderPostChildFoldersAsync(CancellationToken cancellationToken)
        {
            var p = new MailFolderPostChildFoldersParameter();
            return await this.SendAsync<MailFolderPostChildFoldersParameter, MailFolderPostChildFoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderPostChildFoldersResponse> MailFolderPostChildFoldersAsync(MailFolderPostChildFoldersParameter parameter)
        {
            return await this.SendAsync<MailFolderPostChildFoldersParameter, MailFolderPostChildFoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-post-childfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderPostChildFoldersResponse> MailFolderPostChildFoldersAsync(MailFolderPostChildFoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailFolderPostChildFoldersParameter, MailFolderPostChildFoldersResponse>(parameter, cancellationToken);
        }
    }
}
