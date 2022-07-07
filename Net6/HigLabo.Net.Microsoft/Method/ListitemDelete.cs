using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListitemDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items_ItemId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items_ItemId: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists/{ListId}/items/{ItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string SiteId { get; set; }
        public string ListId { get; set; }
        public string ItemId { get; set; }
    }
    public partial class ListitemDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemDeleteResponse> ListitemDeleteAsync()
        {
            var p = new ListitemDeleteParameter();
            return await this.SendAsync<ListitemDeleteParameter, ListitemDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemDeleteResponse> ListitemDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ListitemDeleteParameter();
            return await this.SendAsync<ListitemDeleteParameter, ListitemDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemDeleteResponse> ListitemDeleteAsync(ListitemDeleteParameter parameter)
        {
            return await this.SendAsync<ListitemDeleteParameter, ListitemDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemDeleteResponse> ListitemDeleteAsync(ListitemDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListitemDeleteParameter, ListitemDeleteResponse>(parameter, cancellationToken);
        }
    }
}
