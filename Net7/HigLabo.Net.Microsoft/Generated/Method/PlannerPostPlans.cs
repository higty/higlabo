using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerPostPlansParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Plans: return $"/planner/plans";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Planner_Plans,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public PlannerPlanContainer? Container { get; set; }
        public string? Title { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public PlannerBucket[]? Buckets { get; set; }
        public PlannerPlanDetails? Details { get; set; }
        public PlannerTask[]? Tasks { get; set; }
    }
    public partial class PlannerPostPlansResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerPostPlansResponse> PlannerPostPlansAsync()
        {
            var p = new PlannerPostPlansParameter();
            return await this.SendAsync<PlannerPostPlansParameter, PlannerPostPlansResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerPostPlansResponse> PlannerPostPlansAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerPostPlansParameter();
            return await this.SendAsync<PlannerPostPlansParameter, PlannerPostPlansResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerPostPlansResponse> PlannerPostPlansAsync(PlannerPostPlansParameter parameter)
        {
            return await this.SendAsync<PlannerPostPlansParameter, PlannerPostPlansResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PlannerPostPlansResponse> PlannerPostPlansAsync(PlannerPostPlansParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerPostPlansParameter, PlannerPostPlansResponse>(parameter, cancellationToken);
        }
    }
}
