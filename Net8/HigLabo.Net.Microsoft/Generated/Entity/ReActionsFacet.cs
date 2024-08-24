using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/reactionsfacet?view=graph-rest-1.0
    /// </summary>
    public partial class ReActionsFacet
    {
        public Int32? CommentCount { get; set; }
        public Int32? LikeCount { get; set; }
        public Int32? ShareCount { get; set; }
    }
}
