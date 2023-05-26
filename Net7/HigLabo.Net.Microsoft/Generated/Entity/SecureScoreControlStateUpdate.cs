using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/securescorecontrolstateupdate?view=graph-rest-1.0
    /// </summary>
    public partial class SecureScoreControlStateUpdate
    {
        public string? AssignedTo { get; set; }
        public string? Comment { get; set; }
        public string? State { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDateTime { get; set; }
    }
}
