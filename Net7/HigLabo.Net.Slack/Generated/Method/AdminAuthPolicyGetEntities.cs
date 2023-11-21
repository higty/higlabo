using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.auth.policy.getEntities
    /// </summary>
    public partial class AdminAuthPolicyGetEntitiesParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.auth.policy.getEntities";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Policy_Name { get; set; }
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
        public string? Entity_Type { get; set; }
        public int? Limit { get; set; }
    }
    public partial class AdminAuthPolicyGetEntitiesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.auth.policy.getEntities
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.getEntities
        /// </summary>
        public async ValueTask<AdminAuthPolicyGetEntitiesResponse> AdminAuthPolicyGetEntitiesAsync(string? policy_Name)
        {
            var p = new AdminAuthPolicyGetEntitiesParameter();
            p.Policy_Name = policy_Name;
            return await this.SendAsync<AdminAuthPolicyGetEntitiesParameter, AdminAuthPolicyGetEntitiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.getEntities
        /// </summary>
        public async ValueTask<AdminAuthPolicyGetEntitiesResponse> AdminAuthPolicyGetEntitiesAsync(string? policy_Name, CancellationToken cancellationToken)
        {
            var p = new AdminAuthPolicyGetEntitiesParameter();
            p.Policy_Name = policy_Name;
            return await this.SendAsync<AdminAuthPolicyGetEntitiesParameter, AdminAuthPolicyGetEntitiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.getEntities
        /// </summary>
        public async ValueTask<AdminAuthPolicyGetEntitiesResponse> AdminAuthPolicyGetEntitiesAsync(AdminAuthPolicyGetEntitiesParameter parameter)
        {
            return await this.SendAsync<AdminAuthPolicyGetEntitiesParameter, AdminAuthPolicyGetEntitiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.getEntities
        /// </summary>
        public async ValueTask<AdminAuthPolicyGetEntitiesResponse> AdminAuthPolicyGetEntitiesAsync(AdminAuthPolicyGetEntitiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAuthPolicyGetEntitiesParameter, AdminAuthPolicyGetEntitiesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.getEntities
        /// </summary>
        public async Task<List<AdminAuthPolicyGetEntitiesResponse>> AdminAuthPolicyGetEntitiesAsync(string? policy_Name, PagingContext<AdminAuthPolicyGetEntitiesResponse> context)
        {
            var p = new AdminAuthPolicyGetEntitiesParameter();
            p.Policy_Name = policy_Name;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.getEntities
        /// </summary>
        public async Task<List<AdminAuthPolicyGetEntitiesResponse>> AdminAuthPolicyGetEntitiesAsync(string? policy_Name, PagingContext<AdminAuthPolicyGetEntitiesResponse> context, CancellationToken cancellationToken)
        {
            var p = new AdminAuthPolicyGetEntitiesParameter();
            p.Policy_Name = policy_Name;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.getEntities
        /// </summary>
        public async ValueTask<List<AdminAuthPolicyGetEntitiesResponse>> AdminAuthPolicyGetEntitiesAsync(AdminAuthPolicyGetEntitiesParameter parameter, PagingContext<AdminAuthPolicyGetEntitiesResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.getEntities
        /// </summary>
        public async ValueTask<List<AdminAuthPolicyGetEntitiesResponse>> AdminAuthPolicyGetEntitiesAsync(AdminAuthPolicyGetEntitiesParameter parameter, PagingContext<AdminAuthPolicyGetEntitiesResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
