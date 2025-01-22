using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
/// </summary>
public partial class EducationsubmissionPostResourcesParameter : IRestApiParameter
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
                case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/resources";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Resources,
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
}
public partial class EducationsubmissionPostResourcesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionPostResourcesResponse> EducationsubmissionPostResourcesAsync()
    {
        var p = new EducationsubmissionPostResourcesParameter();
        return await this.SendAsync<EducationsubmissionPostResourcesParameter, EducationsubmissionPostResourcesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionPostResourcesResponse> EducationsubmissionPostResourcesAsync(CancellationToken cancellationToken)
    {
        var p = new EducationsubmissionPostResourcesParameter();
        return await this.SendAsync<EducationsubmissionPostResourcesParameter, EducationsubmissionPostResourcesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionPostResourcesResponse> EducationsubmissionPostResourcesAsync(EducationsubmissionPostResourcesParameter parameter)
    {
        return await this.SendAsync<EducationsubmissionPostResourcesParameter, EducationsubmissionPostResourcesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-post-resources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionPostResourcesResponse> EducationsubmissionPostResourcesAsync(EducationsubmissionPostResourcesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationsubmissionPostResourcesParameter, EducationsubmissionPostResourcesResponse>(parameter, cancellationToken);
    }
}
