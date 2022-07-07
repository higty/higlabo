using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryDeleteditemsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Directory_DeletedItems_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_DeletedItems_Id: return $"/directory/deletedItems/{Id}";
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
    }
    public partial class DirectoryDeleteditemsGetResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetResponse> DirectoryDeleteditemsGetAsync()
        {
            var p = new DirectoryDeleteditemsGetParameter();
            return await this.SendAsync<DirectoryDeleteditemsGetParameter, DirectoryDeleteditemsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetResponse> DirectoryDeleteditemsGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeleteditemsGetParameter();
            return await this.SendAsync<DirectoryDeleteditemsGetParameter, DirectoryDeleteditemsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetResponse> DirectoryDeleteditemsGetAsync(DirectoryDeleteditemsGetParameter parameter)
        {
            return await this.SendAsync<DirectoryDeleteditemsGetParameter, DirectoryDeleteditemsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetResponse> DirectoryDeleteditemsGetAsync(DirectoryDeleteditemsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeleteditemsGetParameter, DirectoryDeleteditemsGetResponse>(parameter, cancellationToken);
        }
    }
}
