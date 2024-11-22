using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class FunctionsWorkflowsStepsListParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "functions.workflows.steps.list";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Function_Id { get; set; }
    public string? Workflow { get; set; }
    public string? Workflow_App_Id { get; set; }
    public string? Workflow_Id { get; set; }
}
public partial class FunctionsWorkflowsStepsListResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/functions.workflows.steps.list
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/functions.workflows.steps.list
    /// </summary>
    public async ValueTask<FunctionsWorkflowsStepsListResponse> FunctionsWorkflowsStepsListAsync(string? function_Id)
    {
        var p = new FunctionsWorkflowsStepsListParameter();
        p.Function_Id = function_Id;
        return await this.SendAsync<FunctionsWorkflowsStepsListParameter, FunctionsWorkflowsStepsListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/functions.workflows.steps.list
    /// </summary>
    public async ValueTask<FunctionsWorkflowsStepsListResponse> FunctionsWorkflowsStepsListAsync(string? function_Id, CancellationToken cancellationToken)
    {
        var p = new FunctionsWorkflowsStepsListParameter();
        p.Function_Id = function_Id;
        return await this.SendAsync<FunctionsWorkflowsStepsListParameter, FunctionsWorkflowsStepsListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/functions.workflows.steps.list
    /// </summary>
    public async ValueTask<FunctionsWorkflowsStepsListResponse> FunctionsWorkflowsStepsListAsync(FunctionsWorkflowsStepsListParameter parameter)
    {
        return await this.SendAsync<FunctionsWorkflowsStepsListParameter, FunctionsWorkflowsStepsListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/functions.workflows.steps.list
    /// </summary>
    public async ValueTask<FunctionsWorkflowsStepsListResponse> FunctionsWorkflowsStepsListAsync(FunctionsWorkflowsStepsListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<FunctionsWorkflowsStepsListParameter, FunctionsWorkflowsStepsListResponse>(parameter, cancellationToken);
    }
}
