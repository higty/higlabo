using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerPostPlansParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Planner_Plans,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Plans: return $"/planner/plans";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class PlannerPostPlansResponse : RestApiResponse
    {
        public PlannerPlanContainer? Container { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Title { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostPlansResponse> PlannerPostPlansAsync()
        {
            var p = new PlannerPostPlansParameter();
            return await this.SendAsync<PlannerPostPlansParameter, PlannerPostPlansResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostPlansResponse> PlannerPostPlansAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerPostPlansParameter();
            return await this.SendAsync<PlannerPostPlansParameter, PlannerPostPlansResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostPlansResponse> PlannerPostPlansAsync(PlannerPostPlansParameter parameter)
        {
            return await this.SendAsync<PlannerPostPlansParameter, PlannerPostPlansResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planner-post-plans?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerPostPlansResponse> PlannerPostPlansAsync(PlannerPostPlansParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerPostPlansParameter, PlannerPostPlansResponse>(parameter, cancellationToken);
        }
    }
}
