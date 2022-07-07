using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreSetDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets_SetId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId: return $"/ites/{SiteId}/termStore/sets/{SetId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string SiteId { get; set; }
        public string SetId { get; set; }
    }
    public partial class TermstoreSetDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetDeleteResponse> TermstoreSetDeleteAsync()
        {
            var p = new TermstoreSetDeleteParameter();
            return await this.SendAsync<TermstoreSetDeleteParameter, TermstoreSetDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetDeleteResponse> TermstoreSetDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreSetDeleteParameter();
            return await this.SendAsync<TermstoreSetDeleteParameter, TermstoreSetDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetDeleteResponse> TermstoreSetDeleteAsync(TermstoreSetDeleteParameter parameter)
        {
            return await this.SendAsync<TermstoreSetDeleteParameter, TermstoreSetDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetDeleteResponse> TermstoreSetDeleteAsync(TermstoreSetDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreSetDeleteParameter, TermstoreSetDeleteResponse>(parameter, cancellationToken);
        }
    }
}
