using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
/// </summary>
public partial class EducationCategoryDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ClassesId { get; set; }
        public string? AssignmentCategoriesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_Id_AssignmentCategories_Id: return $"/education/classes/{ClassesId}/assignmentCategories/{AssignmentCategoriesId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Education_Classes_Id_AssignmentCategories_Id,
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
public partial class EducationCategoryDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationCategoryDeleteResponse> EducationCategoryDeleteAsync()
    {
        var p = new EducationCategoryDeleteParameter();
        return await this.SendAsync<EducationCategoryDeleteParameter, EducationCategoryDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationCategoryDeleteResponse> EducationCategoryDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new EducationCategoryDeleteParameter();
        return await this.SendAsync<EducationCategoryDeleteParameter, EducationCategoryDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationCategoryDeleteResponse> EducationCategoryDeleteAsync(EducationCategoryDeleteParameter parameter)
    {
        return await this.SendAsync<EducationCategoryDeleteParameter, EducationCategoryDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationCategoryDeleteResponse> EducationCategoryDeleteAsync(EducationCategoryDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationCategoryDeleteParameter, EducationCategoryDeleteResponse>(parameter, cancellationToken);
    }
}
