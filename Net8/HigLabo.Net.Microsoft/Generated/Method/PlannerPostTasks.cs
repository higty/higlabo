using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/planner-post-tasks?view=graph-rest-1.0
/// </summary>
public partial class PlannerPostTasksParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Planner_Tasks: return $"/planner/tasks";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Planner_Tasks,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
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
    public string? PlanId { get; set; }
    public string? PreviewType { get; set; }
    public Int32? Priority { get; set; }
    public Int32? ReferenceCount { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public string? Title { get; set; }
    public PlannerAssignedToTaskBoardTaskFormat? AssignedToTaskBoardFormat { get; set; }
    public PlannerBucketTaskBoardTaskFormat? BucketTaskBoardFormat { get; set; }
    public PlannerTaskDetails? Details { get; set; }
    public PlannerProgressTaskBoardTaskFormat? ProgressTaskBoardFormat { get; set; }
}
public partial class PlannerPostTasksResponse : RestApiResponse
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
    public string? PlanId { get; set; }
    public string? PreviewType { get; set; }
    public Int32? Priority { get; set; }
    public Int32? ReferenceCount { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public string? Title { get; set; }
    public PlannerAssignedToTaskBoardTaskFormat? AssignedToTaskBoardFormat { get; set; }
    public PlannerBucketTaskBoardTaskFormat? BucketTaskBoardFormat { get; set; }
    public PlannerTaskDetails? Details { get; set; }
    public PlannerProgressTaskBoardTaskFormat? ProgressTaskBoardFormat { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/planner-post-tasks?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/planner-post-tasks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerPostTasksResponse> PlannerPostTasksAsync()
    {
        var p = new PlannerPostTasksParameter();
        return await this.SendAsync<PlannerPostTasksParameter, PlannerPostTasksResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/planner-post-tasks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerPostTasksResponse> PlannerPostTasksAsync(CancellationToken cancellationToken)
    {
        var p = new PlannerPostTasksParameter();
        return await this.SendAsync<PlannerPostTasksParameter, PlannerPostTasksResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/planner-post-tasks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerPostTasksResponse> PlannerPostTasksAsync(PlannerPostTasksParameter parameter)
    {
        return await this.SendAsync<PlannerPostTasksParameter, PlannerPostTasksResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/planner-post-tasks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerPostTasksResponse> PlannerPostTasksAsync(PlannerPostTasksParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlannerPostTasksParameter, PlannerPostTasksResponse>(parameter, cancellationToken);
    }
}
