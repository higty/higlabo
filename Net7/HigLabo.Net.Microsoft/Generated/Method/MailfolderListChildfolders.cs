using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MailfolderListChildfoldersParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class MailfolderListChildfoldersResponse : RestApiResponse
    {
        public MailFolder[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListChildfoldersResponse> MailfolderListChildfoldersAsync()
        {
            var p = new MailfolderListChildfoldersParameter();
            return await this.SendAsync<MailfolderListChildfoldersParameter, MailfolderListChildfoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListChildfoldersResponse> MailfolderListChildfoldersAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderListChildfoldersParameter();
            return await this.SendAsync<MailfolderListChildfoldersParameter, MailfolderListChildfoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListChildfoldersResponse> MailfolderListChildfoldersAsync(MailfolderListChildfoldersParameter parameter)
        {
            return await this.SendAsync<MailfolderListChildfoldersParameter, MailfolderListChildfoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderListChildfoldersResponse> MailfolderListChildfoldersAsync(MailfolderListChildfoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderListChildfoldersParameter, MailfolderListChildfoldersResponse>(parameter, cancellationToken);
        }
    }
}
