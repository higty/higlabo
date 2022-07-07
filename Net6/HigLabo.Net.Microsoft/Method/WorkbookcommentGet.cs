using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookcommentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Comments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Comments_Id: return $"/me/drive/items/{ItemsId}/workbook/comments/{CommentsId}";
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
        public string ItemsId { get; set; }
        public string CommentsId { get; set; }
    }
    public partial class WorkbookcommentGetResponse : RestApiResponse
    {
        public string? Content { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentGetResponse> WorkbookcommentGetAsync()
        {
            var p = new WorkbookcommentGetParameter();
            return await this.SendAsync<WorkbookcommentGetParameter, WorkbookcommentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentGetResponse> WorkbookcommentGetAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookcommentGetParameter();
            return await this.SendAsync<WorkbookcommentGetParameter, WorkbookcommentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentGetResponse> WorkbookcommentGetAsync(WorkbookcommentGetParameter parameter)
        {
            return await this.SendAsync<WorkbookcommentGetParameter, WorkbookcommentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentGetResponse> WorkbookcommentGetAsync(WorkbookcommentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookcommentGetParameter, WorkbookcommentGetResponse>(parameter, cancellationToken);
        }
    }
}
