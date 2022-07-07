using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerplanGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Planner_Plans_PlanId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Plans_PlanId: return $"/planner/plans/{PlanId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string PlanId { get; set; }
    }
    public partial class PlannerplanGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanGetResponse> PlannerplanGetAsync()
        {
            var p = new PlannerplanGetParameter();
            return await this.SendAsync<PlannerplanGetParameter, PlannerplanGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanGetResponse> PlannerplanGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerplanGetParameter();
            return await this.SendAsync<PlannerplanGetParameter, PlannerplanGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanGetResponse> PlannerplanGetAsync(PlannerplanGetParameter parameter)
        {
            return await this.SendAsync<PlannerplanGetParameter, PlannerplanGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanGetResponse> PlannerplanGetAsync(PlannerplanGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerplanGetParameter, PlannerplanGetResponse>(parameter, cancellationToken);
        }
    }
}
