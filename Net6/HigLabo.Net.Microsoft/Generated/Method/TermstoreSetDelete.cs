using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreSetDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? SetId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId: return $"/ites/{SiteId}/termStore/sets/{SetId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets_SetId,
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
    public partial class TermStoreSetDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetDeleteResponse> TermStoreSetDeleteAsync()
        {
            var p = new TermStoreSetDeleteParameter();
            return await this.SendAsync<TermStoreSetDeleteParameter, TermStoreSetDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetDeleteResponse> TermStoreSetDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreSetDeleteParameter();
            return await this.SendAsync<TermStoreSetDeleteParameter, TermStoreSetDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetDeleteResponse> TermStoreSetDeleteAsync(TermStoreSetDeleteParameter parameter)
        {
            return await this.SendAsync<TermStoreSetDeleteParameter, TermStoreSetDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-set-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetDeleteResponse> TermStoreSetDeleteAsync(TermStoreSetDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreSetDeleteParameter, TermStoreSetDeleteResponse>(parameter, cancellationToken);
        }
    }
}
