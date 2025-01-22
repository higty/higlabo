using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-delete?view=graph-rest-1.0
/// </summary>
public partial class EducationfeedbackResourceoutcomeDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ClassId { get; set; }
        public string? AssignmentId { get; set; }
        public string? SubmissionId { get; set; }
        public string? OutcomeId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Outcomes_OutcomeId: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/outcomes/{OutcomeId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Outcomes_OutcomeId,
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
public partial class EducationfeedbackResourceoutcomeDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationfeedbackResourceoutcomeDeleteResponse> EducationfeedbackResourceoutcomeDeleteAsync()
    {
        var p = new EducationfeedbackResourceoutcomeDeleteParameter();
        return await this.SendAsync<EducationfeedbackResourceoutcomeDeleteParameter, EducationfeedbackResourceoutcomeDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationfeedbackResourceoutcomeDeleteResponse> EducationfeedbackResourceoutcomeDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new EducationfeedbackResourceoutcomeDeleteParameter();
        return await this.SendAsync<EducationfeedbackResourceoutcomeDeleteParameter, EducationfeedbackResourceoutcomeDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationfeedbackResourceoutcomeDeleteResponse> EducationfeedbackResourceoutcomeDeleteAsync(EducationfeedbackResourceoutcomeDeleteParameter parameter)
    {
        return await this.SendAsync<EducationfeedbackResourceoutcomeDeleteParameter, EducationfeedbackResourceoutcomeDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationfeedbackResourceoutcomeDeleteResponse> EducationfeedbackResourceoutcomeDeleteAsync(EducationfeedbackResourceoutcomeDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationfeedbackResourceoutcomeDeleteParameter, EducationfeedbackResourceoutcomeDeleteResponse>(parameter, cancellationToken);
    }
}
