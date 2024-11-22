using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-update?view=graph-rest-1.0
/// </summary>
public partial class PlannerplandetailsUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Planner_Plans_Id_Details: return $"/planner/plans/{Id}/details";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Planner_Plans_Id_Details,
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
    public PlannerCategoryDescriptions? CategoryDescriptions { get; set; }
    public PlannerUserIds? SharedWith { get; set; }
}
public partial class PlannerplandetailsUpdateResponse : RestApiResponse
{
    public PlannerCategoryDescriptions? CategoryDescriptions { get; set; }
    public string? Id { get; set; }
    public PlannerUserIds? SharedWith { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplandetailsUpdateResponse> PlannerplandetailsUpdateAsync()
    {
        var p = new PlannerplandetailsUpdateParameter();
        return await this.SendAsync<PlannerplandetailsUpdateParameter, PlannerplandetailsUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplandetailsUpdateResponse> PlannerplandetailsUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new PlannerplandetailsUpdateParameter();
        return await this.SendAsync<PlannerplandetailsUpdateParameter, PlannerplandetailsUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplandetailsUpdateResponse> PlannerplandetailsUpdateAsync(PlannerplandetailsUpdateParameter parameter)
    {
        return await this.SendAsync<PlannerplandetailsUpdateParameter, PlannerplandetailsUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplandetails-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerplandetailsUpdateResponse> PlannerplandetailsUpdateAsync(PlannerplandetailsUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlannerplandetailsUpdateParameter, PlannerplandetailsUpdateResponse>(parameter, cancellationToken);
    }
}
