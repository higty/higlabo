using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/subjectrightsrequeststagedetail?view=graph-rest-1.0
/// </summary>
public partial class SubjectRightsRequestStageDetail
{
    public enum SubjectRightsRequestStageDetailSubjectRightsRequestStage
    {
        ContentRetrieval,
        ContentReview,
        GenerateReport,
        ContentDeletion,
        CaseResolved,
        UnknownFutureValue,
    }
    public enum SubjectRightsRequestStageDetailSubjectRightsRequestStageStatus
    {
        NotStarted,
        Current,
        Completed,
        Failed,
        UnknownFutureValue,
    }

    public PublicError? Error { get; set; }
    public SubjectRightsRequestStageDetailSubjectRightsRequestStage Stage { get; set; }
    public SubjectRightsRequestStageDetailSubjectRightsRequestStageStatus Status { get; set; }
}
