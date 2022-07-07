using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreGroupPostParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Groups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Groups: return $"/ites/{SiteId}/termStore/groups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string SiteId { get; set; }
    }
    public partial class TermstoreGroupPostResponse : RestApiResponse
    {
        public enum Groupstring
        {
            Global,
            System,
            SiteCollection,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public Groupstring Scope { get; set; }
        public string? ParentSiteId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupPostResponse> TermstoreGroupPostAsync()
        {
            var p = new TermstoreGroupPostParameter();
            return await this.SendAsync<TermstoreGroupPostParameter, TermstoreGroupPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupPostResponse> TermstoreGroupPostAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreGroupPostParameter();
            return await this.SendAsync<TermstoreGroupPostParameter, TermstoreGroupPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupPostResponse> TermstoreGroupPostAsync(TermstoreGroupPostParameter parameter)
        {
            return await this.SendAsync<TermstoreGroupPostParameter, TermstoreGroupPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupPostResponse> TermstoreGroupPostAsync(TermstoreGroupPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreGroupPostParameter, TermstoreGroupPostResponse>(parameter, cancellationToken);
        }
    }
}
