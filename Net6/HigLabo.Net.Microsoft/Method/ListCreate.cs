using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Sites_SiteId_Lists: return $"/ttps://graph.microsoft.com/v1.0/sites/{SiteId}/lists";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string SiteId { get; set; }
    }
    public partial class ListCreateResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public ListInfo? List { get; set; }
        public System? System { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ListCreateResponse> ListCreateAsync()
        {
            var p = new ListCreateParameter();
            return await this.SendAsync<ListCreateParameter, ListCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ListCreateResponse> ListCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ListCreateParameter();
            return await this.SendAsync<ListCreateParameter, ListCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ListCreateResponse> ListCreateAsync(ListCreateParameter parameter)
        {
            return await this.SendAsync<ListCreateParameter, ListCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-create?view=graph-rest-1.0
        /// </summary>
        public async Task<ListCreateResponse> ListCreateAsync(ListCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListCreateParameter, ListCreateResponse>(parameter, cancellationToken);
        }
    }
}
