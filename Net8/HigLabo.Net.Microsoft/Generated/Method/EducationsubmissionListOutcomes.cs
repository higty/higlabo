using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
/// </summary>
public partial class EducationsubmissionListOutcomesParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Outcomes: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/outcomes";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Outcomes,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class EducationsubmissionListOutcomesResponse : RestApiResponse<EducationOutcome>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionListOutcomesResponse> EducationsubmissionListOutcomesAsync()
    {
        var p = new EducationsubmissionListOutcomesParameter();
        return await this.SendAsync<EducationsubmissionListOutcomesParameter, EducationsubmissionListOutcomesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionListOutcomesResponse> EducationsubmissionListOutcomesAsync(CancellationToken cancellationToken)
    {
        var p = new EducationsubmissionListOutcomesParameter();
        return await this.SendAsync<EducationsubmissionListOutcomesParameter, EducationsubmissionListOutcomesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionListOutcomesResponse> EducationsubmissionListOutcomesAsync(EducationsubmissionListOutcomesParameter parameter)
    {
        return await this.SendAsync<EducationsubmissionListOutcomesParameter, EducationsubmissionListOutcomesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmissionListOutcomesResponse> EducationsubmissionListOutcomesAsync(EducationsubmissionListOutcomesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationsubmissionListOutcomesParameter, EducationsubmissionListOutcomesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<EducationOutcome> EducationsubmissionListOutcomesEnumerateAsync(EducationsubmissionListOutcomesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EducationsubmissionListOutcomesParameter, EducationsubmissionListOutcomesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<EducationOutcome>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
