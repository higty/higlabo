using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerplanListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PlanId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Planner_Plans_PlanId_Tasks: return $"/planner/plans/{PlanId}/tasks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ActiveChecklistItemCount,
            AppliedCategories,
            AssigneePriority,
            Assignments,
            BucketId,
            ChecklistItemCount,
            CompletedBy,
            CompletedDateTime,
            ConversationThreadId,
            CreatedBy,
            CreatedDateTime,
            DueDateTime,
            HasDescription,
            Id,
            OrderHint,
            PercentComplete,
            Priority,
            PlanId,
            PreviewType,
            ReferenceCount,
            StartDateTime,
            Title,
            AssignedToTaskBoardFormat,
            BucketTaskBoardFormat,
            Details,
            ProgressTaskBoardFormat,
        }
        public enum ApiPath
        {
            Planner_Plans_PlanId_Tasks,
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
    public partial class PlannerplanListTasksResponse : RestApiResponse
    {
        public PlannerTask[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanListTasksResponse> PlannerplanListTasksAsync()
        {
            var p = new PlannerplanListTasksParameter();
            return await this.SendAsync<PlannerplanListTasksParameter, PlannerplanListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanListTasksResponse> PlannerplanListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerplanListTasksParameter();
            return await this.SendAsync<PlannerplanListTasksParameter, PlannerplanListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanListTasksResponse> PlannerplanListTasksAsync(PlannerplanListTasksParameter parameter)
        {
            return await this.SendAsync<PlannerplanListTasksParameter, PlannerplanListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerplan-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerplanListTasksResponse> PlannerplanListTasksAsync(PlannerplanListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerplanListTasksParameter, PlannerplanListTasksResponse>(parameter, cancellationToken);
        }
    }
}
