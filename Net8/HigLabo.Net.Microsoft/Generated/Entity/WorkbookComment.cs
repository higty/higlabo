using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookcomment?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookComment
    {
        public string? Content { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public WorkbookCommentReply[]? Replies { get; set; }
    }
}
