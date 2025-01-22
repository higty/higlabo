using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmission-submit?view=graph-rest-1.0
/// </summary>
public partial class EducationsubmissionSubmitParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ClassId { get; set; }
        public string? AssignmentId { get; set; }
        public string? SubmissionId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Submit: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/submit";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum EducationSubmissionstring
    {
        Working,
        Submitted,
        Released,
        Returned,
        Reassigned,
    }
    public enum ApiPath
    {
        Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Submit,
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
    public string? Id { get; set; }
    public IdentitySet? ReassignedBy { get; set; }
    public DateTimeOffset? ReassignedDateTime { get; set; }
    public EducationSubmissionRecipient? Recipient { get; set; }
    public string? ResourcesFolderUrl { get; set; }
    public IdentitySet? ReturnedBy { get; set; }
    public DateTimeOffset? ReturnedDateTime { get; set; }
    public EducationSubmissionstring Status { get; set; }
    public IdentitySet? SubmittedBy { get; set; }
    public DateTimeOffset? SubmittedDateTime { get; set; }
    public IdentitySet? UnsubmittedBy { get; set; }
    public DateTimeOffset? UnsubmittedDateTime { get; set; }
    public EducationOutcome? Outcomes { get; set; }
    public EducationSubmissionResource[]? Resources { get; set; }
    public EducationSubmissionResource[]? SubmittedResources { get; set; }
}
public partial class EducationsubmissionSubmitResponse : RestApiResponse
{
    public enum EducationSubmissionstring
    {
        Working,
        Submitted,
        Released,
        Returned,
        Reassigned,
    }

    public string? Id { get; set; }
    public IdentitySet? ReassignedBy { get; set; }
    public DateTimeOffset? ReassignedDateTime { get; set; }
    public EducationSubmissionRecipient? Recipient { get; set; }
    public string? ResourcesFolderUrl { get; set; }
    public IdentitySet? ReturnedBy { get; set; }
    public DateTimeOffset? ReturnedDateTime { get; set; }
    public EducationSubmissionstring Status { get; set; }
    public IdentitySet? SubmittedBy { get; set; }
    public DateTimeOffset? SubmittedDateTime { get; set; }
    public IdentitySet? UnsubmittedBy { get; set; }
    public DateTimeOffset? UnsubmittedDateTime { get; set; }
    public EducationOutcome? Outcomes { get; set; }
    public EducationSubmissionResource[]? Resources { get; set; }
    public EducationSubmissionResource[]? SubmittedResources { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmission-submit?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-submit?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionSubmitResponse> EducationsubmissionSubmitAsync()
    {
        var p = new EducationsubmissionSubmitParameter();
        return await this.SendAsync<EducationsubmissionSubmitParameter, EducationsubmissionSubmitResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-submit?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionSubmitResponse> EducationsubmissionSubmitAsync(CancellationToken cancellationToken)
    {
        var p = new EducationsubmissionSubmitParameter();
        return await this.SendAsync<EducationsubmissionSubmitParameter, EducationsubmissionSubmitResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-submit?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionSubmitResponse> EducationsubmissionSubmitAsync(EducationsubmissionSubmitParameter parameter)
    {
        return await this.SendAsync<EducationsubmissionSubmitParameter, EducationsubmissionSubmitResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-submit?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionSubmitResponse> EducationsubmissionSubmitAsync(EducationsubmissionSubmitParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationsubmissionSubmitParameter, EducationsubmissionSubmitResponse>(parameter, cancellationToken);
    }
}
