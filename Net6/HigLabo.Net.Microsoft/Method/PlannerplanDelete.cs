using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerplanDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Planner_Plans_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Plans_Id: return $"/planner/plans/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class PlannerplanDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanDeleteResponse> PlannerplanDeleteAsync()
        {
            var p = new PlannerplanDeleteParameter();
            return await this.SendAsync<PlannerplanDeleteParameter, PlannerplanDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanDeleteResponse> PlannerplanDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerplanDeleteParameter();
            return await this.SendAsync<PlannerplanDeleteParameter, PlannerplanDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanDeleteResponse> PlannerplanDeleteAsync(PlannerplanDeleteParameter parameter)
        {
            return await this.SendAsync<PlannerplanDeleteParameter, PlannerplanDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanDeleteResponse> PlannerplanDeleteAsync(PlannerplanDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerplanDeleteParameter, PlannerplanDeleteResponse>(parameter, cancellationToken);
        }
    }
}
