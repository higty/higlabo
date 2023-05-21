using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-set-update?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreSetUpdateParameter : IRestApiParameter
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
                    case ApiPath.Sites_SiteId_TermStore_Sets_SetId: return $"/sites/{SiteId}/termStore/sets/{SetId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_TermStore_Sets_SetId,
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
        public TermStoreLocalizedname[]? LocalizedNames { get; set; }
        public string? Description { get; set; }
        public KeyValue[]? Properties { get; set; }
    }
    public partial class TermStoreSetUpdateResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public TermStoreLocalizedname[]? LocalizedNames { get; set; }
        public KeyValue[]? Properties { get; set; }
        public TermStoreTerm[]? Children { get; set; }
        public TermStoreGroup? ParentGroup { get; set; }
        public TermStoreRelation[]? Relations { get; set; }
        public TermStoreTerm[]? Terms { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-set-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-set-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetUpdateResponse> TermStoreSetUpdateAsync()
        {
            var p = new TermStoreSetUpdateParameter();
            return await this.SendAsync<TermStoreSetUpdateParameter, TermStoreSetUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-set-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetUpdateResponse> TermStoreSetUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreSetUpdateParameter();
            return await this.SendAsync<TermStoreSetUpdateParameter, TermStoreSetUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-set-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetUpdateResponse> TermStoreSetUpdateAsync(TermStoreSetUpdateParameter parameter)
        {
            return await this.SendAsync<TermStoreSetUpdateParameter, TermStoreSetUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-set-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetUpdateResponse> TermStoreSetUpdateAsync(TermStoreSetUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreSetUpdateParameter, TermStoreSetUpdateResponse>(parameter, cancellationToken);
        }
    }
}
