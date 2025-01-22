using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
/// </summary>
public partial class EducationAssignmentRemoveCategoryParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ClassesId { get; set; }
        public string? AssignmentsId { get; set; }
        public string? CategoriesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_Id_Assignments_Id_Categories_Id_ref: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/categories/{CategoriesId}/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Education_Classes_Id_Assignments_Id_Categories_Id_ref,
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
public partial class EducationAssignmentRemoveCategoryResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentRemoveCategoryResponse> EducationAssignmentRemoveCategoryAsync()
    {
        var p = new EducationAssignmentRemoveCategoryParameter();
        return await this.SendAsync<EducationAssignmentRemoveCategoryParameter, EducationAssignmentRemoveCategoryResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentRemoveCategoryResponse> EducationAssignmentRemoveCategoryAsync(CancellationToken cancellationToken)
    {
        var p = new EducationAssignmentRemoveCategoryParameter();
        return await this.SendAsync<EducationAssignmentRemoveCategoryParameter, EducationAssignmentRemoveCategoryResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentRemoveCategoryResponse> EducationAssignmentRemoveCategoryAsync(EducationAssignmentRemoveCategoryParameter parameter)
    {
        return await this.SendAsync<EducationAssignmentRemoveCategoryParameter, EducationAssignmentRemoveCategoryResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentRemoveCategoryResponse> EducationAssignmentRemoveCategoryAsync(EducationAssignmentRemoveCategoryParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationAssignmentRemoveCategoryParameter, EducationAssignmentRemoveCategoryResponse>(parameter, cancellationToken);
    }
}
