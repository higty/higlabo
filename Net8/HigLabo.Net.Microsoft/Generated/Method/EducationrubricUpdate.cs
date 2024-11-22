using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationrubric-update?view=graph-rest-1.0
/// </summary>
public partial class EducationrubricUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Me_Rubrics_Ceb3863e69124ea9Ac413c2bb7b6672d: return $"/education/me/rubrics/ceb3863e-6912-4ea9-ac41-3c2bb7b6672d";
                case ApiPath.Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric: return $"/education/classes/acdefc6b-2dc6-4e71-b1e9-6d9810ab1793/assignments/cf6005fc-9e13-44a2-a6ac-a53322006454/rubric";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Education_Me_Rubrics_Ceb3863e69124ea9Ac413c2bb7b6672d,
        Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public ItemBody? Description { get; set; }
    public string? DisplayName { get; set; }
    public EducationAssignmentGradeType? Grading { get; set; }
    public RubricLevel[]? Levels { get; set; }
    public RubricQuality[]? Qualities { get; set; }
}
public partial class EducationrubricUpdateResponse : RestApiResponse
{
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public ItemBody? Description { get; set; }
    public string? DisplayName { get; set; }
    public EducationAssignmentGradeType? Grading { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public RubricLevel[]? Levels { get; set; }
    public RubricQuality[]? Qualities { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationrubric-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationrubric-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationrubricUpdateResponse> EducationrubricUpdateAsync()
    {
        var p = new EducationrubricUpdateParameter();
        return await this.SendAsync<EducationrubricUpdateParameter, EducationrubricUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationrubric-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationrubricUpdateResponse> EducationrubricUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new EducationrubricUpdateParameter();
        return await this.SendAsync<EducationrubricUpdateParameter, EducationrubricUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationrubric-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationrubricUpdateResponse> EducationrubricUpdateAsync(EducationrubricUpdateParameter parameter)
    {
        return await this.SendAsync<EducationrubricUpdateParameter, EducationrubricUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationrubric-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationrubricUpdateResponse> EducationrubricUpdateAsync(EducationrubricUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationrubricUpdateParameter, EducationrubricUpdateResponse>(parameter, cancellationToken);
    }
}
