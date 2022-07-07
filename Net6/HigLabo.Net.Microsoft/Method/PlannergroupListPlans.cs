using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannergroupListPlansParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_GroupId_Planner_Plans,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_GroupId_Planner_Plans: return $"/groups/{GroupId}/planner/plans";
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
        public string GroupId { get; set; }
    }
    public partial class PlannergroupListPlansResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/plannerplan?view=graph-rest-1.0
        /// </summary>
        public partial class PlannerPlan
        {
            public PlannerPlanContainer? Container { get; set; }
            public IdentitySet? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Id { get; set; }
            public string? Title { get; set; }
        }

        public PlannerPlan[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannergroupListPlansResponse> PlannergroupListPlansAsync()
        {
            var p = new PlannergroupListPlansParameter();
            return await this.SendAsync<PlannergroupListPlansParameter, PlannergroupListPlansResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannergroupListPlansResponse> PlannergroupListPlansAsync(CancellationToken cancellationToken)
        {
            var p = new PlannergroupListPlansParameter();
            return await this.SendAsync<PlannergroupListPlansParameter, PlannergroupListPlansResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannergroupListPlansResponse> PlannergroupListPlansAsync(PlannergroupListPlansParameter parameter)
        {
            return await this.SendAsync<PlannergroupListPlansParameter, PlannergroupListPlansResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannergroup-list-plans?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannergroupListPlansResponse> PlannergroupListPlansAsync(PlannergroupListPlansParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannergroupListPlansParameter, PlannergroupListPlansResponse>(parameter, cancellationToken);
        }
    }
}
