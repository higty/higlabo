using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookListCommentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Comments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Comments: return $"/me/drive/items/{Id}/workbook/comments";
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
    public partial class WorkbookListCommentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/workbookcomment?view=graph-rest-1.0
        /// </summary>
        public partial class WorkbookComment
        {
            public string? Content { get; set; }
            public string? ContentType { get; set; }
            public string? Id { get; set; }
        }

        public WorkbookComment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListCommentsResponse> WorkbookListCommentsAsync()
        {
            var p = new WorkbookListCommentsParameter();
            return await this.SendAsync<WorkbookListCommentsParameter, WorkbookListCommentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListCommentsResponse> WorkbookListCommentsAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookListCommentsParameter();
            return await this.SendAsync<WorkbookListCommentsParameter, WorkbookListCommentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListCommentsResponse> WorkbookListCommentsAsync(WorkbookListCommentsParameter parameter)
        {
            return await this.SendAsync<WorkbookListCommentsParameter, WorkbookListCommentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListCommentsResponse> WorkbookListCommentsAsync(WorkbookListCommentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookListCommentsParameter, WorkbookListCommentsResponse>(parameter, cancellationToken);
        }
    }
}
