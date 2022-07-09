using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerprogresstaskboardtaskformatGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Tasks_Id_ProgressTaskBoardFormat: return $"/planner/tasks/{Id}/progressTaskBoardFormat";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class PlannerprogresstaskboardtaskformatGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? OrderHint { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerprogresstaskboardtaskformatGetResponse> PlannerprogresstaskboardtaskformatGetAsync()
        {
            var p = new PlannerprogresstaskboardtaskformatGetParameter();
            return await this.SendAsync<PlannerprogresstaskboardtaskformatGetParameter, PlannerprogresstaskboardtaskformatGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerprogresstaskboardtaskformatGetResponse> PlannerprogresstaskboardtaskformatGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerprogresstaskboardtaskformatGetParameter();
            return await this.SendAsync<PlannerprogresstaskboardtaskformatGetParameter, PlannerprogresstaskboardtaskformatGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerprogresstaskboardtaskformatGetResponse> PlannerprogresstaskboardtaskformatGetAsync(PlannerprogresstaskboardtaskformatGetParameter parameter)
        {
            return await this.SendAsync<PlannerprogresstaskboardtaskformatGetParameter, PlannerprogresstaskboardtaskformatGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerprogresstaskboardtaskformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerprogresstaskboardtaskformatGetResponse> PlannerprogresstaskboardtaskformatGetAsync(PlannerprogresstaskboardtaskformatGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerprogresstaskboardtaskformatGetParameter, PlannerprogresstaskboardtaskformatGetResponse>(parameter, cancellationToken);
        }
    }
}
