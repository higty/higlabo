using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.permissions.lookup
    /// </summary>
    public partial class AdminWorkflowsPermissionsLookupParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.workflows.permissions.lookup";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Workflow_Ids { get; set; }
        public int? Max_Workflow_Triggers { get; set; }
    }
    public partial class AdminWorkflowsPermissionsLookupResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.permissions.lookup
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.permissions.lookup
        /// </summary>
        public async ValueTask<AdminWorkflowsPermissionsLookupResponse> AdminWorkflowsPermissionsLookupAsync(string? workflow_Ids)
        {
            var p = new AdminWorkflowsPermissionsLookupParameter();
            p.Workflow_Ids = workflow_Ids;
            return await this.SendAsync<AdminWorkflowsPermissionsLookupParameter, AdminWorkflowsPermissionsLookupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.permissions.lookup
        /// </summary>
        public async ValueTask<AdminWorkflowsPermissionsLookupResponse> AdminWorkflowsPermissionsLookupAsync(string? workflow_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminWorkflowsPermissionsLookupParameter();
            p.Workflow_Ids = workflow_Ids;
            return await this.SendAsync<AdminWorkflowsPermissionsLookupParameter, AdminWorkflowsPermissionsLookupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.permissions.lookup
        /// </summary>
        public async ValueTask<AdminWorkflowsPermissionsLookupResponse> AdminWorkflowsPermissionsLookupAsync(AdminWorkflowsPermissionsLookupParameter parameter)
        {
            return await this.SendAsync<AdminWorkflowsPermissionsLookupParameter, AdminWorkflowsPermissionsLookupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.permissions.lookup
        /// </summary>
        public async ValueTask<AdminWorkflowsPermissionsLookupResponse> AdminWorkflowsPermissionsLookupAsync(AdminWorkflowsPermissionsLookupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminWorkflowsPermissionsLookupParameter, AdminWorkflowsPermissionsLookupResponse>(parameter, cancellationToken);
        }
    }
}
