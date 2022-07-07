using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreTermDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets_SetId_Terms_TermId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Terms_TermId: return $"/ites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string SiteId { get; set; }
        public string SetId { get; set; }
        public string TermId { get; set; }
    }
    public partial class TermstoreTermDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermDeleteResponse> TermstoreTermDeleteAsync()
        {
            var p = new TermstoreTermDeleteParameter();
            return await this.SendAsync<TermstoreTermDeleteParameter, TermstoreTermDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermDeleteResponse> TermstoreTermDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreTermDeleteParameter();
            return await this.SendAsync<TermstoreTermDeleteParameter, TermstoreTermDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermDeleteResponse> TermstoreTermDeleteAsync(TermstoreTermDeleteParameter parameter)
        {
            return await this.SendAsync<TermstoreTermDeleteParameter, TermstoreTermDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermDeleteResponse> TermstoreTermDeleteAsync(TermstoreTermDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreTermDeleteParameter, TermstoreTermDeleteResponse>(parameter, cancellationToken);
        }
    }
}
