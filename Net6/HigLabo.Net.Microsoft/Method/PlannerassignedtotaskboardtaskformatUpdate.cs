using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerassignedtotaskboardtaskformatUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Tasks_Id_AssignedToTaskBoardFormat: return $"/planner/tasks/{Id}/assignedToTaskBoardFormat";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Planner_Tasks_Id_AssignedToTaskBoardFormat,
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
        public PlannerOrderHintsByAssignee? OrderHintsByAssignee { get; set; }
        public string? UnassignedOrderHint { get; set; }
    }
    public partial class PlannerassignedtotaskboardtaskformatUpdateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public PlannerOrderHintsByAssignee? OrderHintsByAssignee { get; set; }
        public string? UnassignedOrderHint { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerassignedtotaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerassignedtotaskboardtaskformatUpdateResponse> PlannerassignedtotaskboardtaskformatUpdateAsync()
        {
            var p = new PlannerassignedtotaskboardtaskformatUpdateParameter();
            return await this.SendAsync<PlannerassignedtotaskboardtaskformatUpdateParameter, PlannerassignedtotaskboardtaskformatUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerassignedtotaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerassignedtotaskboardtaskformatUpdateResponse> PlannerassignedtotaskboardtaskformatUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerassignedtotaskboardtaskformatUpdateParameter();
            return await this.SendAsync<PlannerassignedtotaskboardtaskformatUpdateParameter, PlannerassignedtotaskboardtaskformatUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerassignedtotaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerassignedtotaskboardtaskformatUpdateResponse> PlannerassignedtotaskboardtaskformatUpdateAsync(PlannerassignedtotaskboardtaskformatUpdateParameter parameter)
        {
            return await this.SendAsync<PlannerassignedtotaskboardtaskformatUpdateParameter, PlannerassignedtotaskboardtaskformatUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerassignedtotaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerassignedtotaskboardtaskformatUpdateResponse> PlannerassignedtotaskboardtaskformatUpdateAsync(PlannerassignedtotaskboardtaskformatUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerassignedtotaskboardtaskformatUpdateParameter, PlannerassignedtotaskboardtaskformatUpdateResponse>(parameter, cancellationToken);
        }
    }
}
