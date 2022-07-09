using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermStoreGroupPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Ites_SiteId_TermStore_Groups: return $"/ites/{SiteId}/termStore/groups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum TermStoreGroupstring
        {
            Global,
            System,
            SiteCollection,
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Groups,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public TermStoreGroupstring Scope { get; set; }
        public string? ParentSiteId { get; set; }
        public TermStoreSet[]? Sets { get; set; }
    }
    public partial class TermStoreGroupPostResponse : RestApiResponse
    {
        public enum TermStoreGroupstring
        {
            Global,
            System,
            SiteCollection,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public TermStoreGroupstring Scope { get; set; }
        public string? ParentSiteId { get; set; }
        public TermStoreSet[]? Sets { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreGroupPostResponse> TermStoreGroupPostAsync()
        {
            var p = new TermStoreGroupPostParameter();
            return await this.SendAsync<TermStoreGroupPostParameter, TermStoreGroupPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreGroupPostResponse> TermStoreGroupPostAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreGroupPostParameter();
            return await this.SendAsync<TermStoreGroupPostParameter, TermStoreGroupPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreGroupPostResponse> TermStoreGroupPostAsync(TermStoreGroupPostParameter parameter)
        {
            return await this.SendAsync<TermStoreGroupPostParameter, TermStoreGroupPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreGroupPostResponse> TermStoreGroupPostAsync(TermStoreGroupPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreGroupPostParameter, TermStoreGroupPostResponse>(parameter, cancellationToken);
        }
    }
}
