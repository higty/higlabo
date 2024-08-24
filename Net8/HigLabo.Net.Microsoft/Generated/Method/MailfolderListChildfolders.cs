using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MailFolderListChildFoldersParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class MailFolderListChildFoldersResponse : RestApiResponse<MailFolder>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderListChildFoldersResponse> MailFolderListChildFoldersAsync()
        {
            var p = new MailFolderListChildFoldersParameter();
            return await this.SendAsync<MailFolderListChildFoldersParameter, MailFolderListChildFoldersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderListChildFoldersResponse> MailFolderListChildFoldersAsync(CancellationToken cancellationToken)
        {
            var p = new MailFolderListChildFoldersParameter();
            return await this.SendAsync<MailFolderListChildFoldersParameter, MailFolderListChildFoldersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderListChildFoldersResponse> MailFolderListChildFoldersAsync(MailFolderListChildFoldersParameter parameter)
        {
            return await this.SendAsync<MailFolderListChildFoldersParameter, MailFolderListChildFoldersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MailFolderListChildFoldersResponse> MailFolderListChildFoldersAsync(MailFolderListChildFoldersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailFolderListChildFoldersParameter, MailFolderListChildFoldersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-list-childfolders?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<MailFolder> MailFolderListChildFoldersEnumerateAsync(MailFolderListChildFoldersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<MailFolderListChildFoldersParameter, MailFolderListChildFoldersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<MailFolder>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
