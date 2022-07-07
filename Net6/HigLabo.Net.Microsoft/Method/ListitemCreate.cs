using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListitemCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists/{ListId}/items";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string SiteId { get; set; }
        public string ListId { get; set; }
    }
    public partial class ListitemCreateResponse : RestApiResponse
    {
        public ContentTypeInfo? ContentType { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemCreateResponse> ListitemCreateAsync()
        {
            var p = new ListitemCreateParameter();
            return await this.SendAsync<ListitemCreateParameter, ListitemCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemCreateResponse> ListitemCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ListitemCreateParameter();
            return await this.SendAsync<ListitemCreateParameter, ListitemCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemCreateResponse> ListitemCreateAsync(ListitemCreateParameter parameter)
        {
            return await this.SendAsync<ListitemCreateParameter, ListitemCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemCreateResponse> ListitemCreateAsync(ListitemCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListitemCreateParameter, ListitemCreateResponse>(parameter, cancellationToken);
        }
    }
}
