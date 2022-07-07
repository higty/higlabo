using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailsearchfolderPostParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_MailFolders_Id_ChildFolders,
            Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders_Id_ChildFolders: return $"/me/mailFolders/{Id}/childFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}/childFolders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public bool? IncludeNestedFolders { get; set; }
        public String[]? SourceFolderIds { get; set; }
        public string? FilterQuery { get; set; }
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class MailsearchfolderPostResponse : RestApiResponse
    {
        public bool? IsSupported { get; set; }
        public bool? IncludeNestedFolders { get; set; }
        public String[]? SourceFolderIds { get; set; }
        public string? FilterQuery { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderPostResponse> MailsearchfolderPostAsync()
        {
            var p = new MailsearchfolderPostParameter();
            return await this.SendAsync<MailsearchfolderPostParameter, MailsearchfolderPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderPostResponse> MailsearchfolderPostAsync(CancellationToken cancellationToken)
        {
            var p = new MailsearchfolderPostParameter();
            return await this.SendAsync<MailsearchfolderPostParameter, MailsearchfolderPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderPostResponse> MailsearchfolderPostAsync(MailsearchfolderPostParameter parameter)
        {
            return await this.SendAsync<MailsearchfolderPostParameter, MailsearchfolderPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailsearchfolder-post?view=graph-rest-1.0
        /// </summary>
        public async Task<MailsearchfolderPostResponse> MailsearchfolderPostAsync(MailsearchfolderPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailsearchfolderPostParameter, MailsearchfolderPostResponse>(parameter, cancellationToken);
        }
    }
}
