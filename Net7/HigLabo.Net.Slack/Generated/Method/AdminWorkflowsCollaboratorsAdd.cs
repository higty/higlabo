using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.collaborators.add
    /// </summary>
    public partial class AdminWorkflowsCollaboratorsAddParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.workflows.collaborators.add";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Collaborator_Ids { get; set; }
        public string? Workflow_Ids { get; set; }
    }
    public partial class AdminWorkflowsCollaboratorsAddResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.collaborators.add
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.collaborators.add
        /// </summary>
        public async ValueTask<AdminWorkflowsCollaboratorsAddResponse> AdminWorkflowsCollaboratorsAddAsync(string? collaborator_Ids, string? workflow_Ids)
        {
            var p = new AdminWorkflowsCollaboratorsAddParameter();
            p.Collaborator_Ids = collaborator_Ids;
            p.Workflow_Ids = workflow_Ids;
            return await this.SendAsync<AdminWorkflowsCollaboratorsAddParameter, AdminWorkflowsCollaboratorsAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.collaborators.add
        /// </summary>
        public async ValueTask<AdminWorkflowsCollaboratorsAddResponse> AdminWorkflowsCollaboratorsAddAsync(string? collaborator_Ids, string? workflow_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminWorkflowsCollaboratorsAddParameter();
            p.Collaborator_Ids = collaborator_Ids;
            p.Workflow_Ids = workflow_Ids;
            return await this.SendAsync<AdminWorkflowsCollaboratorsAddParameter, AdminWorkflowsCollaboratorsAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.collaborators.add
        /// </summary>
        public async ValueTask<AdminWorkflowsCollaboratorsAddResponse> AdminWorkflowsCollaboratorsAddAsync(AdminWorkflowsCollaboratorsAddParameter parameter)
        {
            return await this.SendAsync<AdminWorkflowsCollaboratorsAddParameter, AdminWorkflowsCollaboratorsAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.collaborators.add
        /// </summary>
        public async ValueTask<AdminWorkflowsCollaboratorsAddResponse> AdminWorkflowsCollaboratorsAddAsync(AdminWorkflowsCollaboratorsAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminWorkflowsCollaboratorsAddParameter, AdminWorkflowsCollaboratorsAddResponse>(parameter, cancellationToken);
        }
    }
}
