using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.collaborators.remove
    /// </summary>
    public partial class AdminWorkflowsCollaboratorsRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.workflows.collaborators.remove";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Collaborator_Ids { get; set; }
        public string? Workflow_Ids { get; set; }
    }
    public partial class AdminWorkflowsCollaboratorsRemoveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.collaborators.remove
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.collaborators.remove
        /// </summary>
        public async ValueTask<AdminWorkflowsCollaboratorsRemoveResponse> AdminWorkflowsCollaboratorsRemoveAsync(string? collaborator_Ids, string? workflow_Ids)
        {
            var p = new AdminWorkflowsCollaboratorsRemoveParameter();
            p.Collaborator_Ids = collaborator_Ids;
            p.Workflow_Ids = workflow_Ids;
            return await this.SendAsync<AdminWorkflowsCollaboratorsRemoveParameter, AdminWorkflowsCollaboratorsRemoveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.collaborators.remove
        /// </summary>
        public async ValueTask<AdminWorkflowsCollaboratorsRemoveResponse> AdminWorkflowsCollaboratorsRemoveAsync(string? collaborator_Ids, string? workflow_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminWorkflowsCollaboratorsRemoveParameter();
            p.Collaborator_Ids = collaborator_Ids;
            p.Workflow_Ids = workflow_Ids;
            return await this.SendAsync<AdminWorkflowsCollaboratorsRemoveParameter, AdminWorkflowsCollaboratorsRemoveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.collaborators.remove
        /// </summary>
        public async ValueTask<AdminWorkflowsCollaboratorsRemoveResponse> AdminWorkflowsCollaboratorsRemoveAsync(AdminWorkflowsCollaboratorsRemoveParameter parameter)
        {
            return await this.SendAsync<AdminWorkflowsCollaboratorsRemoveParameter, AdminWorkflowsCollaboratorsRemoveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.collaborators.remove
        /// </summary>
        public async ValueTask<AdminWorkflowsCollaboratorsRemoveResponse> AdminWorkflowsCollaboratorsRemoveAsync(AdminWorkflowsCollaboratorsRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminWorkflowsCollaboratorsRemoveParameter, AdminWorkflowsCollaboratorsRemoveResponse>(parameter, cancellationToken);
        }
    }
}
