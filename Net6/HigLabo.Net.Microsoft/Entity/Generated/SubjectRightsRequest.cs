using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/subjectrightsrequest?view=graph-rest-1.0
    /// </summary>
    public partial class SubjectRightsRequest
    {
        public Identity? AssignedTo { get; set; }
        public DateTimeOffset ClosedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DataSubject? DataSubject { get; set; }
        public SubjectRightsRequestDataSubjectType DataSubjectType { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public SubjectRightsRequestHistory[] History { get; set; }
        public SubjectRightsRequestDetail? Insight { get; set; }
        public DateTimeOffset InternalDueDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public String[] Regulations { get; set; }
        public SubjectRightsRequestStageDetail[] Stages { get; set; }
        public SubjectRightsRequestSubjectRightsRequestStatus Status { get; set; }
        public SubjectRightsRequestSubjectRightsRequestType Type { get; set; }
    }
}
