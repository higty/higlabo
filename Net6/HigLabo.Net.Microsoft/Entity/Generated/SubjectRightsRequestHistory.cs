using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/subjectrightsrequesthistory?view=graph-rest-1.0
    /// </summary>
    public partial class SubjectRightsRequestHistory
    {
        public IdentitySet? ChangedBy { get; set; }
        public DateTimeOffset EventDateTime { get; set; }
        public SubjectRightsRequestHistorySubjectRightsRequestStage Stage { get; set; }
        public SubjectRightsRequestHistorySubjectRightsRequestStageStatus StageStatus { get; set; }
        public string Type { get; set; }
    }
}
