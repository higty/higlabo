using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlanneruserListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Planner_Tasks,
            Users_Id_Planner_Tasks,
            Drive_Root_CreatedByUser_Planner_Tasks,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Planner_Tasks: return $"/me/planner/tasks";
                    case ApiPath.Users_Id_Planner_Tasks: return $"/users/{Id}/planner/tasks";
                    case ApiPath.Drive_Root_CreatedByUser_Planner_Tasks: return $"/drive/root/createdByUser/planner/tasks";
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
    public partial class PlanneruserListTasksResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/plannertask?view=graph-rest-1.0
        /// </summary>
        public partial class PlannerTask
        {
            public Int32? ActiveChecklistItemCount { get; set; }
            public PlannerAppliedCategories? AppliedCategories { get; set; }
            public string? AssigneePriority { get; set; }
            public PlannerAssignments? Assignments { get; set; }
            public string? BucketId { get; set; }
            public Int32? ChecklistItemCount { get; set; }
            public IdentitySet? CompletedBy { get; set; }
            public DateTimeOffset? CompletedDateTime { get; set; }
            public string? ConversationThreadId { get; set; }
            public IdentitySet? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? DueDateTime { get; set; }
            public bool? HasDescription { get; set; }
            public string? Id { get; set; }
            public string? OrderHint { get; set; }
            public Int32? PercentComplete { get; set; }
            public Int32? Priority { get; set; }
            public string? PlanId { get; set; }
            public string? PreviewType { get; set; }
            public Int32? ReferenceCount { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
            public string? Title { get; set; }
        }

        public PlannerTask[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlanneruserListTasksResponse> PlanneruserListTasksAsync()
        {
            var p = new PlanneruserListTasksParameter();
            return await this.SendAsync<PlanneruserListTasksParameter, PlanneruserListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlanneruserListTasksResponse> PlanneruserListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new PlanneruserListTasksParameter();
            return await this.SendAsync<PlanneruserListTasksParameter, PlanneruserListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlanneruserListTasksResponse> PlanneruserListTasksAsync(PlanneruserListTasksParameter parameter)
        {
            return await this.SendAsync<PlanneruserListTasksParameter, PlanneruserListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/planneruser-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlanneruserListTasksResponse> PlanneruserListTasksAsync(PlanneruserListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlanneruserListTasksParameter, PlanneruserListTasksResponse>(parameter, cancellationToken);
        }
    }
}
