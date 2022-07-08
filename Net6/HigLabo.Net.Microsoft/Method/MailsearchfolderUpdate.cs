using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailsearchfolderUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public bool? IncludeNestedFolders { get; set; }
        public String[]? SourceFolderIds { get; set; }
        public string? FilterQuery { get; set; }
    }
    public partial class MailsearchfolderUpdateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/mailsearchfolder-update?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderUpdateResponse> MailsearchfolderUpdateAsync()
        {
            var p = new MailsearchfolderUpdateParameter();
            return await this.SendAsync<MailsearchfolderUpdateParameter, MailsearchfolderUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailsearchfolder-update?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderUpdateResponse> MailsearchfolderUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new MailsearchfolderUpdateParameter();
            return await this.SendAsync<MailsearchfolderUpdateParameter, MailsearchfolderUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailsearchfolder-update?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderUpdateResponse> MailsearchfolderUpdateAsync(MailsearchfolderUpdateParameter parameter)
        {
            return await this.SendAsync<MailsearchfolderUpdateParameter, MailsearchfolderUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailsearchfolder-update?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderUpdateResponse> MailsearchfolderUpdateAsync(MailsearchfolderUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailsearchfolderUpdateParameter, MailsearchfolderUpdateResponse>(parameter, cancellationToken);
        }
    }
}
