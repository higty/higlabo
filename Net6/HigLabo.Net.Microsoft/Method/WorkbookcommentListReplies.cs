using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookcommentListRepliesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Comments_Id_Replies,
            Me_Drive_Root_ItemPath_Workbook_Comments_Id_Replies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Comments_Id_Replies: return $"/me/drive/items/{ItemsId}/workbook/comments/{CommentsId}/replies";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Comments_Id_Replies: return $"/me/drive/root:/{ItemPath}:/workbook/comments/{Id}/replies";
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
        public string ItemPath { get; set; }
        public string Id { get; set; }
    }
    public partial class WorkbookcommentListRepliesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/workbookcommentreply?view=graph-rest-1.0
        /// </summary>
        public partial class WorkbookCommentReply
        {
            public string? Content { get; set; }
            public string? ContentType { get; set; }
            public string? Id { get; set; }
        }

        public WorkbookCommentReply[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-list-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentListRepliesResponse> WorkbookcommentListRepliesAsync()
        {
            var p = new WorkbookcommentListRepliesParameter();
            return await this.SendAsync<WorkbookcommentListRepliesParameter, WorkbookcommentListRepliesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-list-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentListRepliesResponse> WorkbookcommentListRepliesAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookcommentListRepliesParameter();
            return await this.SendAsync<WorkbookcommentListRepliesParameter, WorkbookcommentListRepliesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-list-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentListRepliesResponse> WorkbookcommentListRepliesAsync(WorkbookcommentListRepliesParameter parameter)
        {
            return await this.SendAsync<WorkbookcommentListRepliesParameter, WorkbookcommentListRepliesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-list-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentListRepliesResponse> WorkbookcommentListRepliesAsync(WorkbookcommentListRepliesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookcommentListRepliesParameter, WorkbookcommentListRepliesResponse>(parameter, cancellationToken);
        }
    }
}
