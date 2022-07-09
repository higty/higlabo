using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermStoreStoreUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Ites_SiteId_TermStore: return $"/ites/{SiteId}/termStore";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Ites_SiteId_TermStore,
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
        public string? DefaultLanguageTag { get; set; }
        public String[]? LanguageTags { get; set; }
    }
    public partial class TermStoreStoreUpdateResponse : RestApiResponse
    {
        public string? DefaultLanguageTag { get; set; }
        public string? Id { get; set; }
        public String[]? LanguageTags { get; set; }
        public TermStoreGroup[]? Groups { get; set; }
        public TermStoreSet[]? Sets { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-store-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreStoreUpdateResponse> TermStoreStoreUpdateAsync()
        {
            var p = new TermStoreStoreUpdateParameter();
            return await this.SendAsync<TermStoreStoreUpdateParameter, TermStoreStoreUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-store-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreStoreUpdateResponse> TermStoreStoreUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreStoreUpdateParameter();
            return await this.SendAsync<TermStoreStoreUpdateParameter, TermStoreStoreUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-store-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreStoreUpdateResponse> TermStoreStoreUpdateAsync(TermStoreStoreUpdateParameter parameter)
        {
            return await this.SendAsync<TermStoreStoreUpdateParameter, TermStoreStoreUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-store-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreStoreUpdateResponse> TermStoreStoreUpdateAsync(TermStoreStoreUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreStoreUpdateParameter, TermStoreStoreUpdateResponse>(parameter, cancellationToken);
        }
    }
}
