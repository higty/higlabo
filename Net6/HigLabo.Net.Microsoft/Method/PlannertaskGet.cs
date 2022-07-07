using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlannertaskGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Planner_Tasks_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Planner_Tasks_Id: return $"/planner/tasks/{Id}";
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
    public partial class PlannertaskGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskGetResponse> PlannertaskGetAsync()
        {
            var p = new PlannertaskGetParameter();
            return await this.SendAsync<PlannertaskGetParameter, PlannertaskGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskGetResponse> PlannertaskGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlannertaskGetParameter();
            return await this.SendAsync<PlannertaskGetParameter, PlannertaskGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskGetResponse> PlannertaskGetAsync(PlannertaskGetParameter parameter)
        {
            return await this.SendAsync<PlannertaskGetParameter, PlannertaskGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/plannertask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlannertaskGetResponse> PlannertaskGetAsync(PlannertaskGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlannertaskGetParameter, PlannertaskGetResponse>(parameter, cancellationToken);
        }
    }
}
