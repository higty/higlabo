using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
    /// </summary>
    public partial class MailsearchfolderPostParameter : IRestApiParameter
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
        public bool? IncludeNestedFolders { get; set; }
        public String[]? SourceFolderIds { get; set; }
        public string? FilterQuery { get; set; }
        public bool? IsSupported { get; set; }
    }
    public partial class MailsearchfolderPostResponse : RestApiResponse
    {
        public string? FilterQuery { get; set; }
        public bool? IncludeNestedFolders { get; set; }
        public bool? IsSupported { get; set; }
        public String[]? SourceFolderIds { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderPostResponse> MailsearchfolderPostAsync()
        {
            var p = new MailsearchfolderPostParameter();
            return await this.SendAsync<MailsearchfolderPostParameter, MailsearchfolderPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderPostResponse> MailsearchfolderPostAsync(CancellationToken cancellationToken)
        {
            var p = new MailsearchfolderPostParameter();
            return await this.SendAsync<MailsearchfolderPostParameter, MailsearchfolderPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderPostResponse> MailsearchfolderPostAsync(MailsearchfolderPostParameter parameter)
        {
            return await this.SendAsync<MailsearchfolderPostParameter, MailsearchfolderPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderPostResponse> MailsearchfolderPostAsync(MailsearchfolderPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailsearchfolderPostParameter, MailsearchfolderPostResponse>(parameter, cancellationToken);
        }
    }
}
