using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerprogresstaskboardtaskformatUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Tasks_Id_ProgressTaskBoardFormat: return $"/planner/tasks/{Id}/progressTaskBoardFormat";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Planner_Tasks_Id_ProgressTaskBoardFormat,
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
        public string? OrderHint { get; set; }
    }
    public partial class PlannerprogresstaskboardtaskformatUpdateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? OrderHint { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerprogresstaskboardtaskformatUpdateResponse> PlannerprogresstaskboardtaskformatUpdateAsync()
        {
            var p = new PlannerprogresstaskboardtaskformatUpdateParameter();
            return await this.SendAsync<PlannerprogresstaskboardtaskformatUpdateParameter, PlannerprogresstaskboardtaskformatUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerprogresstaskboardtaskformatUpdateResponse> PlannerprogresstaskboardtaskformatUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerprogresstaskboardtaskformatUpdateParameter();
            return await this.SendAsync<PlannerprogresstaskboardtaskformatUpdateParameter, PlannerprogresstaskboardtaskformatUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerprogresstaskboardtaskformatUpdateResponse> PlannerprogresstaskboardtaskformatUpdateAsync(PlannerprogresstaskboardtaskformatUpdateParameter parameter)
        {
            return await this.SendAsync<PlannerprogresstaskboardtaskformatUpdateParameter, PlannerprogresstaskboardtaskformatUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerprogresstaskboardtaskformatUpdateResponse> PlannerprogresstaskboardtaskformatUpdateAsync(PlannerprogresstaskboardtaskformatUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerprogresstaskboardtaskformatUpdateParameter, PlannerprogresstaskboardtaskformatUpdateResponse>(parameter, cancellationToken);
        }
    }
}
