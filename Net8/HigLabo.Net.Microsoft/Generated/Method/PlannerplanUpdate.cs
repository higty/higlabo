using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-update?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerplanUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PlanId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Plans_PlanId: return $"/planner/plans/{PlanId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Planner_Plans_PlanId,
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
        public string? Title { get; set; }
    }
    public partial class PlannerplanUpdateResponse : RestApiResponse
    {
        public PlannerPlanContainer? Container { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Title { get; set; }
        public PlannerBucket[]? Buckets { get; set; }
        public PlannerPlanDetails? Details { get; set; }
        public PlannerTask[]? Tasks { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerplan-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerplan-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerplanUpdateResponse> PlannerplanUpdateAsync()
        {
            var p = new PlannerplanUpdateParameter();
            return await this.SendAsync<PlannerplanUpdateParameter, PlannerplanUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerplan-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerplanUpdateResponse> PlannerplanUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerplanUpdateParameter();
            return await this.SendAsync<PlannerplanUpdateParameter, PlannerplanUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerplan-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerplanUpdateResponse> PlannerplanUpdateAsync(PlannerplanUpdateParameter parameter)
        {
            return await this.SendAsync<PlannerplanUpdateParameter, PlannerplanUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/plannerplan-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerplanUpdateResponse> PlannerplanUpdateAsync(PlannerplanUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerplanUpdateParameter, PlannerplanUpdateResponse>(parameter, cancellationToken);
        }
    }
}
