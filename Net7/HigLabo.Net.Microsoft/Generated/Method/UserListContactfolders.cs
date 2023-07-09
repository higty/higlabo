using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
    /// </summary>
    public partial class UserListContactfoldersParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            DisplayName,
            Id,
            ParentFolderId,
            ChildFolders,
            Contacts,
            MultiValueExtendedProperties,
            SingleValueExtendedProperties,
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
    public partial class UserListContactfoldersResponse : RestApiResponse
    {
        public ContactFolder[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactfoldersResponse> UserListContactfoldersAsync()
        {
            var p = new UserListContactfoldersParameter();
            return await this.SendAsync<UserListContactfoldersParameter, UserListContactfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactfoldersResponse> UserListContactfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new UserListContactfoldersParameter();
            return await this.SendAsync<UserListContactfoldersParameter, UserListContactfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactfoldersResponse> UserListContactfoldersAsync(UserListContactfoldersParameter parameter)
        {
            return await this.SendAsync<UserListContactfoldersParameter, UserListContactfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-contactfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListContactfoldersResponse> UserListContactfoldersAsync(UserListContactfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListContactfoldersParameter, UserListContactfoldersResponse>(parameter, cancellationToken);
        }
    }
}
