using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class WorkflowsStepFailedParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "workflows.stepFailed";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public object? Error { get; set; }
    public string? Workflow_Step_Execute_Id { get; set; }
}
public partial class WorkflowsStepFailedResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/workflows.stepFailed
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/workflows.stepFailed
    /// </summary>
    public async ValueTask<WorkflowsStepFailedResponse> WorkflowsStepFailedAsync(object? error, string? workflow_Step_Execute_Id)
    {
        var p = new WorkflowsStepFailedParameter();
        p.Error = error;
        p.Workflow_Step_Execute_Id = workflow_Step_Execute_Id;
        return await this.SendAsync<WorkflowsStepFailedParameter, WorkflowsStepFailedResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/workflows.stepFailed
    /// </summary>
    public async ValueTask<WorkflowsStepFailedResponse> WorkflowsStepFailedAsync(object? error, string? workflow_Step_Execute_Id, CancellationToken cancellationToken)
    {
        var p = new WorkflowsStepFailedParameter();
        p.Error = error;
        p.Workflow_Step_Execute_Id = workflow_Step_Execute_Id;
        return await this.SendAsync<WorkflowsStepFailedParameter, WorkflowsStepFailedResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/workflows.stepFailed
    /// </summary>
    public async ValueTask<WorkflowsStepFailedResponse> WorkflowsStepFailedAsync(WorkflowsStepFailedParameter parameter)
    {
        return await this.SendAsync<WorkflowsStepFailedParameter, WorkflowsStepFailedResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/workflows.stepFailed
    /// </summary>
    public async ValueTask<WorkflowsStepFailedResponse> WorkflowsStepFailedAsync(WorkflowsStepFailedParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<WorkflowsStepFailedParameter, WorkflowsStepFailedResponse>(parameter, cancellationToken);
    }
}
