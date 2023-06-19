using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-update?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreTermUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? SetId { get; set; }
            public string? TermId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Terms_TermId: return $"/sites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_TermStore_Sets_SetId_Terms_TermId,
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
        public TermStoreLocalizedlabel[]? Labels { get; set; }
        public TermStoreLocalizeddescription[]? Descriptions { get; set; }
        public KeyValue[]? Properties { get; set; }
    }
    public partial class TermStoreTermUpdateResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TermStoreLocalizeddescription[]? Descriptions { get; set; }
        public string? Id { get; set; }
        public TermStoreLocalizedlabel[]? Labels { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public KeyValue[]? Properties { get; set; }
        public TermStoreTerm[]? Children { get; set; }
        public TermStoreRelation[]? Relations { get; set; }
        public TermStoreSet? Set { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermUpdateResponse> TermStoreTermUpdateAsync()
        {
            var p = new TermStoreTermUpdateParameter();
            return await this.SendAsync<TermStoreTermUpdateParameter, TermStoreTermUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermUpdateResponse> TermStoreTermUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreTermUpdateParameter();
            return await this.SendAsync<TermStoreTermUpdateParameter, TermStoreTermUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermUpdateResponse> TermStoreTermUpdateAsync(TermStoreTermUpdateParameter parameter)
        {
            return await this.SendAsync<TermStoreTermUpdateParameter, TermStoreTermUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermUpdateResponse> TermStoreTermUpdateAsync(TermStoreTermUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreTermUpdateParameter, TermStoreTermUpdateResponse>(parameter, cancellationToken);
        }
    }
}
