using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryDeleteditemsGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class DirectoryDeleteditemsGetResponse : RestApiResponse
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
        public async Task<DirectoryDeleteditemsGetResponse> DirectoryDeleteditemsGetAsync()
        {
            var p = new DirectoryDeleteditemsGetParameter();
            return await this.SendAsync<DirectoryDeleteditemsGetParameter, DirectoryDeleteditemsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetResponse> DirectoryDeleteditemsGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeleteditemsGetParameter();
            return await this.SendAsync<DirectoryDeleteditemsGetParameter, DirectoryDeleteditemsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetResponse> DirectoryDeleteditemsGetAsync(DirectoryDeleteditemsGetParameter parameter)
        {
            return await this.SendAsync<DirectoryDeleteditemsGetParameter, DirectoryDeleteditemsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetResponse> DirectoryDeleteditemsGetAsync(DirectoryDeleteditemsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeleteditemsGetParameter, DirectoryDeleteditemsGetResponse>(parameter, cancellationToken);
        }
    }
}
