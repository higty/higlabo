using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryDeletedItemsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ObjectId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_DeletedItems_ObjectId: return $"/directory/deletedItems/{ObjectId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Directory_DeletedItems_ObjectId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class DirectoryDeletedItemsGetResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsGetResponse> DirectoryDeletedItemsGetAsync()
        {
            var p = new DirectoryDeletedItemsGetParameter();
            return await this.SendAsync<DirectoryDeletedItemsGetParameter, DirectoryDeletedItemsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsGetResponse> DirectoryDeletedItemsGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeletedItemsGetParameter();
            return await this.SendAsync<DirectoryDeletedItemsGetParameter, DirectoryDeletedItemsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsGetResponse> DirectoryDeletedItemsGetAsync(DirectoryDeletedItemsGetParameter parameter)
        {
            return await this.SendAsync<DirectoryDeletedItemsGetParameter, DirectoryDeletedItemsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsGetResponse> DirectoryDeletedItemsGetAsync(DirectoryDeletedItemsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeletedItemsGetParameter, DirectoryDeletedItemsGetResponse>(parameter, cancellationToken);
        }
    }
}
