
namespace HigLabo.Net.Slack
{
    public class WorkflowsStepFailedParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "workflows.stepFailed";
        public string HttpMethod { get; private set; } = "POST";
        public object Error { get; set; }
        public string Workflow_Step_Execute_Id { get; set; } = "";
    }
    public partial class WorkflowsStepFailedResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<WorkflowsStepFailedResponse> WorkflowsStepFailedAsync(object error, string workflow_Step_Execute_Id)
        {
            var p = new WorkflowsStepFailedParameter();
            p.Error = error;
            p.Workflow_Step_Execute_Id = workflow_Step_Execute_Id;
            return await this.SendAsync<WorkflowsStepFailedParameter, WorkflowsStepFailedResponse>(p, CancellationToken.None);
        }
        public async Task<WorkflowsStepFailedResponse> WorkflowsStepFailedAsync(object error, string workflow_Step_Execute_Id, CancellationToken cancellationToken)
        {
            var p = new WorkflowsStepFailedParameter();
            p.Error = error;
            p.Workflow_Step_Execute_Id = workflow_Step_Execute_Id;
            return await this.SendAsync<WorkflowsStepFailedParameter, WorkflowsStepFailedResponse>(p, cancellationToken);
        }
        public async Task<WorkflowsStepFailedResponse> WorkflowsStepFailedAsync(WorkflowsStepFailedParameter parameter)
        {
            return await this.SendAsync<WorkflowsStepFailedParameter, WorkflowsStepFailedResponse>(parameter, CancellationToken.None);
        }
        public async Task<WorkflowsStepFailedResponse> WorkflowsStepFailedAsync(WorkflowsStepFailedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkflowsStepFailedParameter, WorkflowsStepFailedResponse>(parameter, cancellationToken);
        }
    }
}
