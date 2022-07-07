using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnenoteListPagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Onenote_Pages,
            Users_IdOrUserPrincipalName_Onenote_Pages,
            Groups_Id_Onenote_Pages,
            Sites_Id_Onenote_Pages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Pages: return $"/me/onenote/pages";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Pages: return $"/users/{IdOrUserPrincipalName}/onenote/pages";
                    case ApiPath.Groups_Id_Onenote_Pages: return $"/groups/{Id}/onenote/pages";
                    case ApiPath.Sites_Id_Onenote_Pages: return $"/sites/{Id}/onenote/pages";
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
        public string IdOrUserPrincipalName { get; set; }
        public string Id { get; set; }
    }
    public partial class OnenoteListPagesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListPagesResponse> OnenoteListPagesAsync()
        {
            var p = new OnenoteListPagesParameter();
            return await this.SendAsync<OnenoteListPagesParameter, OnenoteListPagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListPagesResponse> OnenoteListPagesAsync(CancellationToken cancellationToken)
        {
            var p = new OnenoteListPagesParameter();
            return await this.SendAsync<OnenoteListPagesParameter, OnenoteListPagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListPagesResponse> OnenoteListPagesAsync(OnenoteListPagesParameter parameter)
        {
            return await this.SendAsync<OnenoteListPagesParameter, OnenoteListPagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListPagesResponse> OnenoteListPagesAsync(OnenoteListPagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnenoteListPagesParameter, OnenoteListPagesResponse>(parameter, cancellationToken);
        }
    }
}
