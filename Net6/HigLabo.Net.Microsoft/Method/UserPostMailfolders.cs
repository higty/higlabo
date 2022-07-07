using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserPostMailfoldersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_MailFolders,
            Users_IdOrUserPrincipalName_MailFolders,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders: return $"/me/mailFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders: return $"/users/{IdOrUserPrincipalName}/mailFolders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public bool? IsHidden { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserPostMailfoldersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostMailfoldersResponse> UserPostMailfoldersAsync()
        {
            var p = new UserPostMailfoldersParameter();
            return await this.SendAsync<UserPostMailfoldersParameter, UserPostMailfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostMailfoldersResponse> UserPostMailfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostMailfoldersParameter();
            return await this.SendAsync<UserPostMailfoldersParameter, UserPostMailfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostMailfoldersResponse> UserPostMailfoldersAsync(UserPostMailfoldersParameter parameter)
        {
            return await this.SendAsync<UserPostMailfoldersParameter, UserPostMailfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostMailfoldersResponse> UserPostMailfoldersAsync(UserPostMailfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostMailfoldersParameter, UserPostMailfoldersResponse>(parameter, cancellationToken);
        }
    }
}
