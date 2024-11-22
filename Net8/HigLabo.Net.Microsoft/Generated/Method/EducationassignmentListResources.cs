using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
/// </summary>
public partial class EducationAssignmentListResourcesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ClassesId { get; set; }
        public string? AssignmentsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_Id_Assignments_Id_Resources: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/resources";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Classes_Id_Assignments_Id_Resources,
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
public partial class EducationAssignmentListResourcesResponse : RestApiResponse<EducationAssignmentResource>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentListResourcesResponse> EducationAssignmentListResourcesAsync()
    {
        var p = new EducationAssignmentListResourcesParameter();
        return await this.SendAsync<EducationAssignmentListResourcesParameter, EducationAssignmentListResourcesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentListResourcesResponse> EducationAssignmentListResourcesAsync(CancellationToken cancellationToken)
    {
        var p = new EducationAssignmentListResourcesParameter();
        return await this.SendAsync<EducationAssignmentListResourcesParameter, EducationAssignmentListResourcesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentListResourcesResponse> EducationAssignmentListResourcesAsync(EducationAssignmentListResourcesParameter parameter)
    {
        return await this.SendAsync<EducationAssignmentListResourcesParameter, EducationAssignmentListResourcesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentListResourcesResponse> EducationAssignmentListResourcesAsync(EducationAssignmentListResourcesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationAssignmentListResourcesParameter, EducationAssignmentListResourcesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-resources?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<EducationAssignmentResource> EducationAssignmentListResourcesEnumerateAsync(EducationAssignmentListResourcesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EducationAssignmentListResourcesParameter, EducationAssignmentListResourcesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<EducationAssignmentResource>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
