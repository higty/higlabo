using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-restore?view=graph-rest-1.0
    /// </summary>
    public partial class DocumentsetversionReStoreParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }
            public string? ItemId { get; set; }
            public string? DocumentSetVersionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions_DocumentSetVersionId_Restore: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}/documentSetVersions/{DocumentSetVersionId}/restore";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions_DocumentSetVersionId_Restore,
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
    }
    public partial class DocumentsetversionReStoreResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-restore?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DocumentsetversionReStoreResponse> DocumentsetversionReStoreAsync()
        {
            var p = new DocumentsetversionReStoreParameter();
            return await this.SendAsync<DocumentsetversionReStoreParameter, DocumentsetversionReStoreResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DocumentsetversionReStoreResponse> DocumentsetversionReStoreAsync(CancellationToken cancellationToken)
        {
            var p = new DocumentsetversionReStoreParameter();
            return await this.SendAsync<DocumentsetversionReStoreParameter, DocumentsetversionReStoreResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DocumentsetversionReStoreResponse> DocumentsetversionReStoreAsync(DocumentsetversionReStoreParameter parameter)
        {
            return await this.SendAsync<DocumentsetversionReStoreParameter, DocumentsetversionReStoreResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-restore?view=graph-rest-1.0
        /// </summary>
        public async Task<DocumentsetversionReStoreResponse> DocumentsetversionReStoreAsync(DocumentsetversionReStoreParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DocumentsetversionReStoreParameter, DocumentsetversionReStoreResponse>(parameter, cancellationToken);
        }
    }
}
