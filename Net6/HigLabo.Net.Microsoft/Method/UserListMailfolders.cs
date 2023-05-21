using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
    /// </summary>
    public partial class UserListMailfoldersParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_MailFolders_: return $"/me/mailFolders/";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_: return $"/users/{IdOrUserPrincipalName}/mailFolders/";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ChildFolderCount,
            DisplayName,
            Id,
            IsHidden,
            ParentFolderId,
            TotalItemCount,
            UnreadItemCount,
            ChildFolders,
            MessageRules,
            Messages,
            MultiValueExtendedProperties,
            SingleValueExtendedProperties,
        }
        public enum ApiPath
        {
            Me_MailFolders,
            Users_IdOrUserPrincipalName_MailFolders,
            Me_MailFolders_,
            Users_IdOrUserPrincipalName_MailFolders_,
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
    public partial class UserListMailfoldersResponse : RestApiResponse
    {
        public MailFolder[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMailfoldersResponse> UserListMailfoldersAsync()
        {
            var p = new UserListMailfoldersParameter();
            return await this.SendAsync<UserListMailfoldersParameter, UserListMailfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMailfoldersResponse> UserListMailfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new UserListMailfoldersParameter();
            return await this.SendAsync<UserListMailfoldersParameter, UserListMailfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMailfoldersResponse> UserListMailfoldersAsync(UserListMailfoldersParameter parameter)
        {
            return await this.SendAsync<UserListMailfoldersParameter, UserListMailfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMailfoldersResponse> UserListMailfoldersAsync(UserListMailfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListMailfoldersParameter, UserListMailfoldersResponse>(parameter, cancellationToken);
        }
    }
}
