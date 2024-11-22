using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class FunctionsWorkflowsStepsResponsesExportParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "functions.workflows.steps.responses.export";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Step_Id { get; set; }
    public string? Workflow { get; set; }
    public string? Workflow_App_Id { get; set; }
    public string? Workflow_Id { get; set; }
}
public partial class FunctionsWorkflowsStepsResponsesExportResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/functions.workflows.steps.responses.export
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/functions.workflows.steps.responses.export
    /// </summary>
    public async ValueTask<FunctionsWorkflowsStepsResponsesExportResponse> FunctionsWorkflowsStepsResponsesExportAsync(string? step_Id)
    {
        var p = new FunctionsWorkflowsStepsResponsesExportParameter();
        p.Step_Id = step_Id;
        return await this.SendAsync<FunctionsWorkflowsStepsResponsesExportParameter, FunctionsWorkflowsStepsResponsesExportResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/functions.workflows.steps.responses.export
    /// </summary>
    public async ValueTask<FunctionsWorkflowsStepsResponsesExportResponse> FunctionsWorkflowsStepsResponsesExportAsync(string? step_Id, CancellationToken cancellationToken)
    {
        var p = new FunctionsWorkflowsStepsResponsesExportParameter();
        p.Step_Id = step_Id;
        return await this.SendAsync<FunctionsWorkflowsStepsResponsesExportParameter, FunctionsWorkflowsStepsResponsesExportResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/functions.workflows.steps.responses.export
    /// </summary>
    public async ValueTask<FunctionsWorkflowsStepsResponsesExportResponse> FunctionsWorkflowsStepsResponsesExportAsync(FunctionsWorkflowsStepsResponsesExportParameter parameter)
    {
        return await this.SendAsync<FunctionsWorkflowsStepsResponsesExportParameter, FunctionsWorkflowsStepsResponsesExportResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/functions.workflows.steps.responses.export
    /// </summary>
    public async ValueTask<FunctionsWorkflowsStepsResponsesExportResponse> FunctionsWorkflowsStepsResponsesExportAsync(FunctionsWorkflowsStepsResponsesExportParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<FunctionsWorkflowsStepsResponsesExportParameter, FunctionsWorkflowsStepsResponsesExportResponse>(parameter, cancellationToken);
    }
}
