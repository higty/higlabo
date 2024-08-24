using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookCommentPostRepliesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ItemsId { get; set; }
            public string? CommentsId { get; set; }
            public string? ItemPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Comments_Id_Replies: return $"/me/drive/items/{ItemsId}/workbook/comments/{CommentsId}/replies";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Comments_Id_Replies: return $"/me/drive/root:/{ItemPath}:/workbook/comments/{Id}/replies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Comments_Id_Replies,
            Me_Drive_Root_ItemPath_Workbook_Comments_Id_Replies,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Content { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
    }
    public partial class WorkbookCommentPostRepliesResponse : RestApiResponse
    {
        public string? Content { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookCommentPostRepliesResponse> WorkbookCommentPostRepliesAsync()
        {
            var p = new WorkbookCommentPostRepliesParameter();
            return await this.SendAsync<WorkbookCommentPostRepliesParameter, WorkbookCommentPostRepliesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookCommentPostRepliesResponse> WorkbookCommentPostRepliesAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookCommentPostRepliesParameter();
            return await this.SendAsync<WorkbookCommentPostRepliesParameter, WorkbookCommentPostRepliesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookCommentPostRepliesResponse> WorkbookCommentPostRepliesAsync(WorkbookCommentPostRepliesParameter parameter)
        {
            return await this.SendAsync<WorkbookCommentPostRepliesParameter, WorkbookCommentPostRepliesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookCommentPostRepliesResponse> WorkbookCommentPostRepliesAsync(WorkbookCommentPostRepliesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookCommentPostRepliesParameter, WorkbookCommentPostRepliesResponse>(parameter, cancellationToken);
        }
    }
}
