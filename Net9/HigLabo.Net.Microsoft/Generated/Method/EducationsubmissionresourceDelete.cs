using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
/// </summary>
public partial class EducationsubmissionResourceDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ClassId { get; set; }
        public string? AssignmentId { get; set; }
        public string? SubmissionId { get; set; }
        public string? ResourceId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources_ResourceId: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/resources/{ResourceId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources_ResourceId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class EducationsubmissionResourceDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionResourceDeleteResponse> EducationsubmissionResourceDeleteAsync()
    {
        var p = new EducationsubmissionResourceDeleteParameter();
        return await this.SendAsync<EducationsubmissionResourceDeleteParameter, EducationsubmissionResourceDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionResourceDeleteResponse> EducationsubmissionResourceDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new EducationsubmissionResourceDeleteParameter();
        return await this.SendAsync<EducationsubmissionResourceDeleteParameter, EducationsubmissionResourceDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionResourceDeleteResponse> EducationsubmissionResourceDeleteAsync(EducationsubmissionResourceDeleteParameter parameter)
    {
        return await this.SendAsync<EducationsubmissionResourceDeleteParameter, EducationsubmissionResourceDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmissionresource-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionResourceDeleteResponse> EducationsubmissionResourceDeleteAsync(EducationsubmissionResourceDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationsubmissionResourceDeleteParameter, EducationsubmissionResourceDeleteResponse>(parameter, cancellationToken);
    }
}
