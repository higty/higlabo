using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
/// </summary>
public partial class EducationAssignmentDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EducationClassId { get; set; }
        public string? EducationUserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_EducationClassId_Assignments_Delta: return $"/education/classes/{EducationClassId}/assignments/delta";
                case ApiPath.Education_Classes_EducationClassId_Members_EducationUserId_Assignments_Delta: return $"/education/classes/{EducationClassId}/members/{EducationUserId}/assignments/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Classes_EducationClassId_Assignments_Delta,
        Education_Classes_EducationClassId_Members_EducationUserId_Assignments_Delta,
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
public partial class EducationAssignmentDeltaResponse : RestApiResponse<EducationAssignment>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentDeltaResponse> EducationAssignmentDeltaAsync()
    {
        var p = new EducationAssignmentDeltaParameter();
        return await this.SendAsync<EducationAssignmentDeltaParameter, EducationAssignmentDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentDeltaResponse> EducationAssignmentDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new EducationAssignmentDeltaParameter();
        return await this.SendAsync<EducationAssignmentDeltaParameter, EducationAssignmentDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentDeltaResponse> EducationAssignmentDeltaAsync(EducationAssignmentDeltaParameter parameter)
    {
        return await this.SendAsync<EducationAssignmentDeltaParameter, EducationAssignmentDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentDeltaResponse> EducationAssignmentDeltaAsync(EducationAssignmentDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationAssignmentDeltaParameter, EducationAssignmentDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<EducationAssignment> EducationAssignmentDeltaEnumerateAsync(EducationAssignmentDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EducationAssignmentDeltaParameter, EducationAssignmentDeltaResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<EducationAssignment>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
