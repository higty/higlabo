using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
/// </summary>
public partial class EducationsubmittedsubmissionResourceGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ClassesId { get; set; }
        public string? AssignmentsId { get; set; }
        public string? SubmissionsId { get; set; }
        public string? SubmittedResourcesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_Id_Assignments_Id_Submissions_Id_SubmittedResources_Id: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/submissions/{SubmissionsId}/submittedResources/{SubmittedResourcesId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Classes_Id_Assignments_Id_Submissions_Id_SubmittedResources_Id,
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
public partial class EducationsubmittedsubmissionResourceGetResponse : RestApiResponse
{
    public string? AssignmentResourceUrl { get; set; }
    public string? Id { get; set; }
    public EducationResource? Resource { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmittedsubmissionResourceGetResponse> EducationsubmittedsubmissionResourceGetAsync()
    {
        var p = new EducationsubmittedsubmissionResourceGetParameter();
        return await this.SendAsync<EducationsubmittedsubmissionResourceGetParameter, EducationsubmittedsubmissionResourceGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmittedsubmissionResourceGetResponse> EducationsubmittedsubmissionResourceGetAsync(CancellationToken cancellationToken)
    {
        var p = new EducationsubmittedsubmissionResourceGetParameter();
        return await this.SendAsync<EducationsubmittedsubmissionResourceGetParameter, EducationsubmittedsubmissionResourceGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmittedsubmissionResourceGetResponse> EducationsubmittedsubmissionResourceGetAsync(EducationsubmittedsubmissionResourceGetParameter parameter)
    {
        return await this.SendAsync<EducationsubmittedsubmissionResourceGetParameter, EducationsubmittedsubmissionResourceGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmittedsubmissionresource-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationsubmittedsubmissionResourceGetResponse> EducationsubmittedsubmissionResourceGetAsync(EducationsubmittedsubmissionResourceGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationsubmittedsubmissionResourceGetParameter, EducationsubmittedsubmissionResourceGetResponse>(parameter, cancellationToken);
    }
}
