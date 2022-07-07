using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerassignedtotaskboardtaskformatGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Planner_Tasks_Id_AssignedToTaskBoardFormat,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Tasks_Id_AssignedToTaskBoardFormat: return $"/planner/tasks/{Id}/assignedToTaskBoardFormat";
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
        public string Id { get; set; }
    }
    public partial class PlannerassignedtotaskboardtaskformatGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public PlannerOrderHintsByAssignee? OrderHintsByAssignee { get; set; }
        public string? UnassignedOrderHint { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerassignedtotaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerassignedtotaskboardtaskformatGetResponse> PlannerassignedtotaskboardtaskformatGetAsync()
        {
            var p = new PlannerassignedtotaskboardtaskformatGetParameter();
            return await this.SendAsync<PlannerassignedtotaskboardtaskformatGetParameter, PlannerassignedtotaskboardtaskformatGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerassignedtotaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerassignedtotaskboardtaskformatGetResponse> PlannerassignedtotaskboardtaskformatGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerassignedtotaskboardtaskformatGetParameter();
            return await this.SendAsync<PlannerassignedtotaskboardtaskformatGetParameter, PlannerassignedtotaskboardtaskformatGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerassignedtotaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerassignedtotaskboardtaskformatGetResponse> PlannerassignedtotaskboardtaskformatGetAsync(PlannerassignedtotaskboardtaskformatGetParameter parameter)
        {
            return await this.SendAsync<PlannerassignedtotaskboardtaskformatGetParameter, PlannerassignedtotaskboardtaskformatGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerassignedtotaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerassignedtotaskboardtaskformatGetResponse> PlannerassignedtotaskboardtaskformatGetAsync(PlannerassignedtotaskboardtaskformatGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerassignedtotaskboardtaskformatGetParameter, PlannerassignedtotaskboardtaskformatGetResponse>(parameter, cancellationToken);
        }
    }
}
