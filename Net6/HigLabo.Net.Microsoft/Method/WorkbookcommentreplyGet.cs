using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookcommentreplyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Comments_Id_Replies_Id,
            Me_Drive_Root_ItemPath_Workbook_Comments_Id_Replies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Comments_Id_Replies_Id: return $"/me/drive/items/{ItemsId}/workbook/comments/{CommentsId}/replies/{RepliesId}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Comments_Id_Replies_Id: return $"/me/drive/root:/{RootItemPath}/workbook/comments/{CommentsId}/replies/{RepliesId}";
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
        public string RepliesId { get; set; }
        public string RootItemPath { get; set; }
    }
    public partial class WorkbookcommentreplyGetResponse : RestApiResponse
    {
        public string? Content { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcommentreply-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentreplyGetResponse> WorkbookcommentreplyGetAsync()
        {
            var p = new WorkbookcommentreplyGetParameter();
            return await this.SendAsync<WorkbookcommentreplyGetParameter, WorkbookcommentreplyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcommentreply-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentreplyGetResponse> WorkbookcommentreplyGetAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookcommentreplyGetParameter();
            return await this.SendAsync<WorkbookcommentreplyGetParameter, WorkbookcommentreplyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcommentreply-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentreplyGetResponse> WorkbookcommentreplyGetAsync(WorkbookcommentreplyGetParameter parameter)
        {
            return await this.SendAsync<WorkbookcommentreplyGetParameter, WorkbookcommentreplyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcommentreply-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentreplyGetResponse> WorkbookcommentreplyGetAsync(WorkbookcommentreplyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookcommentreplyGetParameter, WorkbookcommentreplyGetResponse>(parameter, cancellationToken);
        }
    }
}
