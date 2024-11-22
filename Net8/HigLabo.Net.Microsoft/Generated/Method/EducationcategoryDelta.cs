using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
/// </summary>
public partial class EducationCategoryDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EducationClassId { get; set; }
        public string? EducationAssignmentId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_EducationClassId_AssignmentCategories_Delta: return $"/education/classes/{EducationClassId}/assignmentCategories/delta";
                case ApiPath.Education_Classes_EducationClassId_Assignments_EducationAssignmentId_Categories_Delta: return $"/education/classes/{EducationClassId}/assignments/{EducationAssignmentId}/categories/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Classes_EducationClassId_AssignmentCategories_Delta,
        Education_Classes_EducationClassId_Assignments_EducationAssignmentId_Categories_Delta,
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
public partial class EducationCategoryDeltaResponse : RestApiResponse<EducationCategory>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationCategoryDeltaResponse> EducationCategoryDeltaAsync()
    {
        var p = new EducationCategoryDeltaParameter();
        return await this.SendAsync<EducationCategoryDeltaParameter, EducationCategoryDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationCategoryDeltaResponse> EducationCategoryDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new EducationCategoryDeltaParameter();
        return await this.SendAsync<EducationCategoryDeltaParameter, EducationCategoryDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationCategoryDeltaResponse> EducationCategoryDeltaAsync(EducationCategoryDeltaParameter parameter)
    {
        return await this.SendAsync<EducationCategoryDeltaParameter, EducationCategoryDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationCategoryDeltaResponse> EducationCategoryDeltaAsync(EducationCategoryDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationCategoryDeltaParameter, EducationCategoryDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<EducationCategory> EducationCategoryDeltaEnumerateAsync(EducationCategoryDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EducationCategoryDeltaParameter, EducationCategoryDeltaResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<EducationCategory>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
