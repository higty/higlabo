using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/approvalstage?view=graph-rest-1.0
    /// </summary>
    public partial class ApprovalStage
    {
        public bool AssignedToMe { get; set; }
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public string Justification { get; set; }
        public string ReviewResult { get; set; }
        public Identity? ReviewedBy { get; set; }
        public DateTimeOffset ReviewedDateTime { get; set; }
        public string Status { get; set; }
    }
}
