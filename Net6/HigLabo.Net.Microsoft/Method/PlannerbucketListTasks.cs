using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannerbucketListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Planner_Buckets_Id_Tasks,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Buckets_Id_Tasks: return $"/planner/buckets/{Id}/tasks";
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
    public partial class PlannerbucketListTasksResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketListTasksResponse> PlannerbucketListTasksAsync()
        {
            var p = new PlannerbucketListTasksParameter();
            return await this.SendAsync<PlannerbucketListTasksParameter, PlannerbucketListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketListTasksResponse> PlannerbucketListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new PlannerbucketListTasksParameter();
            return await this.SendAsync<PlannerbucketListTasksParameter, PlannerbucketListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketListTasksResponse> PlannerbucketListTasksAsync(PlannerbucketListTasksParameter parameter)
        {
            return await this.SendAsync<PlannerbucketListTasksParameter, PlannerbucketListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannerbucket-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannerbucketListTasksResponse> PlannerbucketListTasksAsync(PlannerbucketListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannerbucketListTasksParameter, PlannerbucketListTasksResponse>(parameter, cancellationToken);
        }
    }
}
