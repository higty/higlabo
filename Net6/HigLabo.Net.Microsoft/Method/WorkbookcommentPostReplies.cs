using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookcommentPostRepliesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ItemsId { get; set; }
            public string CommentsId { get; set; }
            public string ItemPath { get; set; }
            public string Id { get; set; }

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
    public partial class WorkbookcommentPostRepliesResponse : RestApiResponse
    {
        public string? Content { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentPostRepliesResponse> WorkbookcommentPostRepliesAsync()
        {
            var p = new WorkbookcommentPostRepliesParameter();
            return await this.SendAsync<WorkbookcommentPostRepliesParameter, WorkbookcommentPostRepliesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentPostRepliesResponse> WorkbookcommentPostRepliesAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookcommentPostRepliesParameter();
            return await this.SendAsync<WorkbookcommentPostRepliesParameter, WorkbookcommentPostRepliesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentPostRepliesResponse> WorkbookcommentPostRepliesAsync(WorkbookcommentPostRepliesParameter parameter)
        {
            return await this.SendAsync<WorkbookcommentPostRepliesParameter, WorkbookcommentPostRepliesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbookcomment-post-replies?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookcommentPostRepliesResponse> WorkbookcommentPostRepliesAsync(WorkbookcommentPostRepliesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookcommentPostRepliesParameter, WorkbookcommentPostRepliesResponse>(parameter, cancellationToken);
        }
    }
}
