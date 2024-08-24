using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookCommentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ItemsId { get; set; }
            public string? CommentsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Comments_Id: return $"/me/drive/items/{ItemsId}/workbook/comments/{CommentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Comments_Id,
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
    public partial class WorkbookCommentGetResponse : RestApiResponse
    {
        public string? Content { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public WorkbookCommentReply[]? Replies { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookCommentGetResponse> WorkbookCommentGetAsync()
        {
            var p = new WorkbookCommentGetParameter();
            return await this.SendAsync<WorkbookCommentGetParameter, WorkbookCommentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookCommentGetResponse> WorkbookCommentGetAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookCommentGetParameter();
            return await this.SendAsync<WorkbookCommentGetParameter, WorkbookCommentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookCommentGetResponse> WorkbookCommentGetAsync(WorkbookCommentGetParameter parameter)
        {
            return await this.SendAsync<WorkbookCommentGetParameter, WorkbookCommentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookCommentGetResponse> WorkbookCommentGetAsync(WorkbookCommentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookCommentGetParameter, WorkbookCommentGetResponse>(parameter, cancellationToken);
        }
    }
}
