using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
    /// </summary>
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
                    case ApiPath.Sites_SiteId_TermStore_Groups: return $"/sites/{SiteId}/termStore/groups";
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
            Sites_SiteId_TermStore_Groups,
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
        public string? ParentSiteId { get; set; }
        public TermStoreGroupstring Scope { get; set; }
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
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? ParentSiteId { get; set; }
        public TermStoreGroupstring Scope { get; set; }
        public TermStoreSet[]? Sets { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreGroupPostResponse> TermStoreGroupPostAsync()
        {
            var p = new TermStoreGroupPostParameter();
            return await this.SendAsync<TermStoreGroupPostParameter, TermStoreGroupPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreGroupPostResponse> TermStoreGroupPostAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreGroupPostParameter();
            return await this.SendAsync<TermStoreGroupPostParameter, TermStoreGroupPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreGroupPostResponse> TermStoreGroupPostAsync(TermStoreGroupPostParameter parameter)
        {
            return await this.SendAsync<TermStoreGroupPostParameter, TermStoreGroupPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreGroupPostResponse> TermStoreGroupPostAsync(TermStoreGroupPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreGroupPostParameter, TermStoreGroupPostResponse>(parameter, cancellationToken);
        }
    }
}
