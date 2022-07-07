using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MailfolderCopyParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_MailFolders_Id_Copy,
            Users_IdOrUserPrincipalName_MailFolders_Id_Copy,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders_Id_Copy: return $"/me/mailFolders/{Id}/copy";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Copy: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}/copy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DestinationId { get; set; }
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class MailfolderCopyResponse : RestApiResponse
    {
        public Int32? ChildFolderCount { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHidden { get; set; }
        public string? ParentFolderId { get; set; }
        public Int32? TotalItemCount { get; set; }
        public Int32? UnreadItemCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderCopyResponse> MailfolderCopyAsync()
        {
            var p = new MailfolderCopyParameter();
            return await this.SendAsync<MailfolderCopyParameter, MailfolderCopyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderCopyResponse> MailfolderCopyAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderCopyParameter();
            return await this.SendAsync<MailfolderCopyParameter, MailfolderCopyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderCopyResponse> MailfolderCopyAsync(MailfolderCopyParameter parameter)
        {
            return await this.SendAsync<MailfolderCopyParameter, MailfolderCopyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/mailfolder-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderCopyResponse> MailfolderCopyAsync(MailfolderCopyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderCopyParameter, MailfolderCopyResponse>(parameter, cancellationToken);
        }
    }
}
