using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SectionListPagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Onenote_Sections_Id_Pages,
            Users_IdOrUserPrincipalName_Onenote_Sections_Id_Pages,
            Groups_Id_Onenote_Sections_Id_Pages,
            Sites_Id_Onenote_Sections_Id_Pages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Sections_Id_Pages: return $"/me/onenote/sections/{Id}/pages";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections_Id_Pages: return $"/users/{IdOrUserPrincipalName}/onenote/sections/{Id}/pages";
                    case ApiPath.Groups_Id_Onenote_Sections_Id_Pages: return $"/groups/{GroupsId}/onenote/sections/{SectionsId}/pages";
                    case ApiPath.Sites_Id_Onenote_Sections_Id_Pages: return $"/sites/{SitesId}/onenote/sections/{SectionsId}/pages";
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
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string SectionsId { get; set; }
        public string SitesId { get; set; }
    }
    public partial class SectionListPagesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/page?view=graph-rest-1.0
        /// </summary>
        public partial class Page
        {
            public Stream? Content { get; set; }
            public string? ContentUrl { get; set; }
            public string? CreatedByAppId { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public Int32? Level { get; set; }
            public PageLinks? Links { get; set; }
            public Int32? Order { get; set; }
            public string? Self { get; set; }
            public string? Title { get; set; }
        }

        public Page[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionListPagesResponse> SectionListPagesAsync()
        {
            var p = new SectionListPagesParameter();
            return await this.SendAsync<SectionListPagesParameter, SectionListPagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionListPagesResponse> SectionListPagesAsync(CancellationToken cancellationToken)
        {
            var p = new SectionListPagesParameter();
            return await this.SendAsync<SectionListPagesParameter, SectionListPagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionListPagesResponse> SectionListPagesAsync(SectionListPagesParameter parameter)
        {
            return await this.SendAsync<SectionListPagesParameter, SectionListPagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<SectionListPagesResponse> SectionListPagesAsync(SectionListPagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectionListPagesParameter, SectionListPagesResponse>(parameter, cancellationToken);
        }
    }
}
