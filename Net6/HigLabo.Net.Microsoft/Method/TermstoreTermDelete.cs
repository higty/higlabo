using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermStoreTermDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SiteId { get; set; }
            public string SetId { get; set; }
            public string TermId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Terms_TermId: return $"/ites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets_SetId_Terms_TermId,
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
    public partial class TermStoreTermDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermDeleteResponse> TermStoreTermDeleteAsync()
        {
            var p = new TermStoreTermDeleteParameter();
            return await this.SendAsync<TermStoreTermDeleteParameter, TermStoreTermDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermDeleteResponse> TermStoreTermDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreTermDeleteParameter();
            return await this.SendAsync<TermStoreTermDeleteParameter, TermStoreTermDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermDeleteResponse> TermStoreTermDeleteAsync(TermStoreTermDeleteParameter parameter)
        {
            return await this.SendAsync<TermStoreTermDeleteParameter, TermStoreTermDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermDeleteResponse> TermStoreTermDeleteAsync(TermStoreTermDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreTermDeleteParameter, TermStoreTermDeleteResponse>(parameter, cancellationToken);
        }
    }
}
