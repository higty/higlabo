using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserPostContactfoldersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_ContactFolders: return $"/me/contactFolders";
                    case ApiPath.Users_IdOrUserPrincipalName_ContactFolders: return $"/users/{IdOrUserPrincipalName}/contactFolders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_ContactFolders,
            Users_IdOrUserPrincipalName_ContactFolders,
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
        public string? Id { get; set; }
        public string? ParentFolderId { get; set; }
        public ContactFolder[]? ChildFolders { get; set; }
        public Contact[]? Contacts { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class UserPostContactfoldersResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? ParentFolderId { get; set; }
        public ContactFolder[]? ChildFolders { get; set; }
        public Contact[]? Contacts { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostContactfoldersResponse> UserPostContactfoldersAsync()
        {
            var p = new UserPostContactfoldersParameter();
            return await this.SendAsync<UserPostContactfoldersParameter, UserPostContactfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostContactfoldersResponse> UserPostContactfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostContactfoldersParameter();
            return await this.SendAsync<UserPostContactfoldersParameter, UserPostContactfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostContactfoldersResponse> UserPostContactfoldersAsync(UserPostContactfoldersParameter parameter)
        {
            return await this.SendAsync<UserPostContactfoldersParameter, UserPostContactfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostContactfoldersResponse> UserPostContactfoldersAsync(UserPostContactfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostContactfoldersParameter, UserPostContactfoldersResponse>(parameter, cancellationToken);
        }
    }
}
