using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-delete?view=graph-rest-1.0
    /// </summary>
    public partial class DocumentsetversionDeleteParameter : IRestApiParameter
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
                    case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions_DocumentSetVersionId: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}/documentSetVersions/{DocumentSetVersionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions_DocumentSetVersionId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class DocumentsetversionDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DocumentsetversionDeleteResponse> DocumentsetversionDeleteAsync()
        {
            var p = new DocumentsetversionDeleteParameter();
            return await this.SendAsync<DocumentsetversionDeleteParameter, DocumentsetversionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DocumentsetversionDeleteResponse> DocumentsetversionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DocumentsetversionDeleteParameter();
            return await this.SendAsync<DocumentsetversionDeleteParameter, DocumentsetversionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DocumentsetversionDeleteResponse> DocumentsetversionDeleteAsync(DocumentsetversionDeleteParameter parameter)
        {
            return await this.SendAsync<DocumentsetversionDeleteParameter, DocumentsetversionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DocumentsetversionDeleteResponse> DocumentsetversionDeleteAsync(DocumentsetversionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DocumentsetversionDeleteParameter, DocumentsetversionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
