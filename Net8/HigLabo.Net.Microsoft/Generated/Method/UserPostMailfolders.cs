using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
    /// </summary>
    public partial class UserPostMailfoldersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_MailFolders: return $"/me/mailFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders: return $"/users/{IdOrUserPrincipalName}/mailFolders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_MailFolders,
            Users_IdOrUserPrincipalName_MailFolders,
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
    public partial class UserPostMailfoldersResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserPostMailfoldersResponse> UserPostMailfoldersAsync()
        {
            var p = new UserPostMailfoldersParameter();
            return await this.SendAsync<UserPostMailfoldersParameter, UserPostMailfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserPostMailfoldersResponse> UserPostMailfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostMailfoldersParameter();
            return await this.SendAsync<UserPostMailfoldersParameter, UserPostMailfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserPostMailfoldersResponse> UserPostMailfoldersAsync(UserPostMailfoldersParameter parameter)
        {
            return await this.SendAsync<UserPostMailfoldersParameter, UserPostMailfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserPostMailfoldersResponse> UserPostMailfoldersAsync(UserPostMailfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostMailfoldersParameter, UserPostMailfoldersResponse>(parameter, cancellationToken);
        }
    }
}
