using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class WorkflowsUpdateStepParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "workflows.updateStep";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Workflow_Step_Edit_Id { get; set; }
        public object? Inputs { get; set; }
        public string? Outputs { get; set; }
        public string? Step_Image_Url { get; set; }
        public string? Step_Name { get; set; }
    }
    public partial class WorkflowsUpdateStepResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/workflows.updateStep
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/workflows.updateStep
        /// </summary>
        public async ValueTask<WorkflowsUpdateStepResponse> WorkflowsUpdateStepAsync(string? workflow_Step_Edit_Id)
        {
            var p = new WorkflowsUpdateStepParameter();
            p.Workflow_Step_Edit_Id = workflow_Step_Edit_Id;
            return await this.SendAsync<WorkflowsUpdateStepParameter, WorkflowsUpdateStepResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/workflows.updateStep
        /// </summary>
        public async ValueTask<WorkflowsUpdateStepResponse> WorkflowsUpdateStepAsync(string? workflow_Step_Edit_Id, CancellationToken cancellationToken)
        {
            var p = new WorkflowsUpdateStepParameter();
            p.Workflow_Step_Edit_Id = workflow_Step_Edit_Id;
            return await this.SendAsync<WorkflowsUpdateStepParameter, WorkflowsUpdateStepResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/workflows.updateStep
        /// </summary>
        public async ValueTask<WorkflowsUpdateStepResponse> WorkflowsUpdateStepAsync(WorkflowsUpdateStepParameter parameter)
        {
            return await this.SendAsync<WorkflowsUpdateStepParameter, WorkflowsUpdateStepResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/workflows.updateStep
        /// </summary>
        public async ValueTask<WorkflowsUpdateStepResponse> WorkflowsUpdateStepAsync(WorkflowsUpdateStepParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkflowsUpdateStepParameter, WorkflowsUpdateStepResponse>(parameter, cancellationToken);
        }
    }
}
