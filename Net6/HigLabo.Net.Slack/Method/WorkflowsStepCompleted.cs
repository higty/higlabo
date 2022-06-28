
namespace HigLabo.Net.Slack
{
    public class WorkflowsStepCompletedParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "workflows.stepCompleted";
        public string HttpMethod { get; private set; } = "POST";
        public string Workflow_Step_Execute_Id { get; set; } = "";
        public object? Outputs { get; set; }
    }
    public partial class WorkflowsStepCompletedResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<WorkflowsStepCompletedResponse> WorkflowsStepCompletedAsync(string workflow_Step_Execute_Id)
        {
            var p = new WorkflowsStepCompletedParameter();
            p.Workflow_Step_Execute_Id = workflow_Step_Execute_Id;
            return await this.SendAsync<WorkflowsStepCompletedParameter, WorkflowsStepCompletedResponse>(p, CancellationToken.None);
        }
        public async Task<WorkflowsStepCompletedResponse> WorkflowsStepCompletedAsync(string workflow_Step_Execute_Id, CancellationToken cancellationToken)
        {
            var p = new WorkflowsStepCompletedParameter();
            p.Workflow_Step_Execute_Id = workflow_Step_Execute_Id;
            return await this.SendAsync<WorkflowsStepCompletedParameter, WorkflowsStepCompletedResponse>(p, cancellationToken);
        }
        public async Task<WorkflowsStepCompletedResponse> WorkflowsStepCompletedAsync(WorkflowsStepCompletedParameter parameter)
        {
            return await this.SendAsync<WorkflowsStepCompletedParameter, WorkflowsStepCompletedResponse>(parameter, CancellationToken.None);
        }
        public async Task<WorkflowsStepCompletedResponse> WorkflowsStepCompletedAsync(WorkflowsStepCompletedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkflowsStepCompletedParameter, WorkflowsStepCompletedResponse>(parameter, cancellationToken);
        }
    }
}
