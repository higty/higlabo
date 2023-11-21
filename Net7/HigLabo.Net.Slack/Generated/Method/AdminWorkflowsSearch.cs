using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.search
    /// </summary>
    public partial class AdminWorkflowsSearchParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.workflows.search";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? App_Id { get; set; }
        public string? Collaborator_Ids { get; set; }
        public string? Cursor { get; set; }
        string? IRestApiPagingParameter.NextPageToken
        {
            get
            {
                return this.Cursor;
            }
            set
            {
                this.Cursor = value;
            }
        }
        public int? Limit { get; set; }
        public bool? No_Collaborators { get; set; }
        public int? Num_Trigger_Ids { get; set; }
        public string? Query { get; set; }
        public Sort Sort { get; set; }
        public SortDirection Sort_Dir { get; set; }
        public string? Source { get; set; }
    }
    public partial class AdminWorkflowsSearchResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.workflows.search
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.search
        /// </summary>
        public async ValueTask<AdminWorkflowsSearchResponse> AdminWorkflowsSearchAsync()
        {
            var p = new AdminWorkflowsSearchParameter();
            return await this.SendAsync<AdminWorkflowsSearchParameter, AdminWorkflowsSearchResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.search
        /// </summary>
        public async ValueTask<AdminWorkflowsSearchResponse> AdminWorkflowsSearchAsync(CancellationToken cancellationToken)
        {
            var p = new AdminWorkflowsSearchParameter();
            return await this.SendAsync<AdminWorkflowsSearchParameter, AdminWorkflowsSearchResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.search
        /// </summary>
        public async ValueTask<AdminWorkflowsSearchResponse> AdminWorkflowsSearchAsync(AdminWorkflowsSearchParameter parameter)
        {
            return await this.SendAsync<AdminWorkflowsSearchParameter, AdminWorkflowsSearchResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.search
        /// </summary>
        public async ValueTask<AdminWorkflowsSearchResponse> AdminWorkflowsSearchAsync(AdminWorkflowsSearchParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminWorkflowsSearchParameter, AdminWorkflowsSearchResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.search
        /// </summary>
        public async Task<List<AdminWorkflowsSearchResponse>> AdminWorkflowsSearchAsync(PagingContext<AdminWorkflowsSearchResponse> context)
        {
            var p = new AdminWorkflowsSearchParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.search
        /// </summary>
        public async Task<List<AdminWorkflowsSearchResponse>> AdminWorkflowsSearchAsync(CancellationToken cancellationToken, PagingContext<AdminWorkflowsSearchResponse> context)
        {
            var p = new AdminWorkflowsSearchParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.search
        /// </summary>
        public async ValueTask<List<AdminWorkflowsSearchResponse>> AdminWorkflowsSearchAsync(AdminWorkflowsSearchParameter parameter, PagingContext<AdminWorkflowsSearchResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.workflows.search
        /// </summary>
        public async ValueTask<List<AdminWorkflowsSearchResponse>> AdminWorkflowsSearchAsync(AdminWorkflowsSearchParameter parameter, PagingContext<AdminWorkflowsSearchResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
