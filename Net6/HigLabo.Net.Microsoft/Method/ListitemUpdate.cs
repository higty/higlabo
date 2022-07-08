using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListitemUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SiteId { get; set; }
            public string ListId { get; set; }
            public string ItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items_ItemId: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists/{ListId}/items/{ItemId}";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items_ItemId_Fields: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists/{ListId}/items/{ItemId}/fields";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items_ItemId,
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists_ListId_Items_ItemId_Fields,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class ListitemUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemUpdateResponse> ListitemUpdateAsync()
        {
            var p = new ListitemUpdateParameter();
            return await this.SendAsync<ListitemUpdateParameter, ListitemUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemUpdateResponse> ListitemUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ListitemUpdateParameter();
            return await this.SendAsync<ListitemUpdateParameter, ListitemUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemUpdateResponse> ListitemUpdateAsync(ListitemUpdateParameter parameter)
        {
            return await this.SendAsync<ListitemUpdateParameter, ListitemUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemUpdateResponse> ListitemUpdateAsync(ListitemUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListitemUpdateParameter, ListitemUpdateResponse>(parameter, cancellationToken);
        }
    }
}
