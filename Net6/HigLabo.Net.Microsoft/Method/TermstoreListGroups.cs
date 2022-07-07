using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreListGroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string SiteId { get; set; }
    }
    public partial class TermstoreListGroupsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-group?view=graph-rest-1.0
        /// </summary>
        public partial class Group
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

        public Group[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreListGroupsResponse> TermstoreListGroupsAsync()
        {
            var p = new TermstoreListGroupsParameter();
            return await this.SendAsync<TermstoreListGroupsParameter, TermstoreListGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreListGroupsResponse> TermstoreListGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreListGroupsParameter();
            return await this.SendAsync<TermstoreListGroupsParameter, TermstoreListGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreListGroupsResponse> TermstoreListGroupsAsync(TermstoreListGroupsParameter parameter)
        {
            return await this.SendAsync<TermstoreListGroupsParameter, TermstoreListGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreListGroupsResponse> TermstoreListGroupsAsync(TermstoreListGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreListGroupsParameter, TermstoreListGroupsResponse>(parameter, cancellationToken);
        }
    }
}
