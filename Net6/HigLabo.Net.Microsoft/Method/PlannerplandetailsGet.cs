using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerplandetailsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Planner_Plans_Id_Details,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Plans_Id_Details: return $"/planner/plans/{Id}/details";
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
    public partial class PlannerplandetailsGetResponse : RestApiResponse
    {
        public PlannerCategoryDescriptions? CategoryDescriptions { get; set; }
        public string? Id { get; set; }
        public PlannerUserIds? SharedWith { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplandetailsGetResponse> PlannerplandetailsGetAsync()
        {
            var p = new PlannerplandetailsGetParameter();
            return await this.SendAsync<PlannerplandetailsGetParameter, PlannerplandetailsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplandetailsGetResponse> PlannerplandetailsGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerplandetailsGetParameter();
            return await this.SendAsync<PlannerplandetailsGetParameter, PlannerplandetailsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplandetailsGetResponse> PlannerplandetailsGetAsync(PlannerplandetailsGetParameter parameter)
        {
            return await this.SendAsync<PlannerplandetailsGetParameter, PlannerplandetailsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplandetails-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplandetailsGetResponse> PlannerplandetailsGetAsync(PlannerplandetailsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerplandetailsGetParameter, PlannerplandetailsGetResponse>(parameter, cancellationToken);
        }
    }
}
