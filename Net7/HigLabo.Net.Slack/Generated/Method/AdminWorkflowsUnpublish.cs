using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.unpublish
    /// </summary>
    public partial class AdminWorkflowsUnpublishParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.workflows.unpublish";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Workflow_Ids { get; set; }
    }
    public partial class AdminWorkflowsUnpublishResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.unpublish
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.unpublish
        /// </summary>
        public async ValueTask<AdminWorkflowsUnpublishResponse> AdminWorkflowsUnpublishAsync(string? workflow_Ids)
        {
            var p = new AdminWorkflowsUnpublishParameter();
            p.Workflow_Ids = workflow_Ids;
            return await this.SendAsync<AdminWorkflowsUnpublishParameter, AdminWorkflowsUnpublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.unpublish
        /// </summary>
        public async ValueTask<AdminWorkflowsUnpublishResponse> AdminWorkflowsUnpublishAsync(string? workflow_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminWorkflowsUnpublishParameter();
            p.Workflow_Ids = workflow_Ids;
            return await this.SendAsync<AdminWorkflowsUnpublishParameter, AdminWorkflowsUnpublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.unpublish
        /// </summary>
        public async ValueTask<AdminWorkflowsUnpublishResponse> AdminWorkflowsUnpublishAsync(AdminWorkflowsUnpublishParameter parameter)
        {
            return await this.SendAsync<AdminWorkflowsUnpublishParameter, AdminWorkflowsUnpublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.unpublish
        /// </summary>
        public async ValueTask<AdminWorkflowsUnpublishResponse> AdminWorkflowsUnpublishAsync(AdminWorkflowsUnpublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminWorkflowsUnpublishParameter, AdminWorkflowsUnpublishResponse>(parameter, cancellationToken);
        }
    }
}
