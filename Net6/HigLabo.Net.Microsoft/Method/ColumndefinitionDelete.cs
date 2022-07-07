using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ColumndefinitionDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SiteId_Columns_ColumnId,
            Sites_SiteId_Lists_ListId_Columns_ColumnId,
            Sites_SiteId_ContentTypes_ContentTypeId_Columns_ColumnId,
            Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId_Columns_ColumnId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_Columns_ColumnId: return $"/sites/{SiteId}/columns/{ColumnId}";
                    case ApiPath.Sites_SiteId_Lists_ListId_Columns_ColumnId: return $"/sites/{SiteId}/lists/{ListId}/columns/{ColumnId}";
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_Columns_ColumnId: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/columns/{ColumnId}";
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId_Columns_ColumnId: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/{ContentTypeId}/columns/{ColumnId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string SiteId { get; set; }
        public string ColumnId { get; set; }
        public string ListId { get; set; }
        public string ContentTypeId { get; set; }
    }
    public partial class ColumndefinitionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ColumndefinitionDeleteResponse> ColumndefinitionDeleteAsync()
        {
            var p = new ColumndefinitionDeleteParameter();
            return await this.SendAsync<ColumndefinitionDeleteParameter, ColumndefinitionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ColumndefinitionDeleteResponse> ColumndefinitionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ColumndefinitionDeleteParameter();
            return await this.SendAsync<ColumndefinitionDeleteParameter, ColumndefinitionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ColumndefinitionDeleteResponse> ColumndefinitionDeleteAsync(ColumndefinitionDeleteParameter parameter)
        {
            return await this.SendAsync<ColumndefinitionDeleteParameter, ColumndefinitionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ColumndefinitionDeleteResponse> ColumndefinitionDeleteAsync(ColumndefinitionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ColumndefinitionDeleteParameter, ColumndefinitionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
