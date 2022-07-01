using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminAuditAnomalyAllowGetItemParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.audit.anomaly.allow.getItem";
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class AdminAuditAnomalyAllowGetItemResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.audit.anomaly.allow.getItem
        /// </summary>
        public async Task<AdminAuditAnomalyAllowGetItemResponse> AdminAuditAnomalyAllowGetItemAsync()
        {
            var p = new AdminAuditAnomalyAllowGetItemParameter();
            return await this.SendAsync<AdminAuditAnomalyAllowGetItemParameter, AdminAuditAnomalyAllowGetItemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.audit.anomaly.allow.getItem
        /// </summary>
        public async Task<AdminAuditAnomalyAllowGetItemResponse> AdminAuditAnomalyAllowGetItemAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAuditAnomalyAllowGetItemParameter();
            return await this.SendAsync<AdminAuditAnomalyAllowGetItemParameter, AdminAuditAnomalyAllowGetItemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.audit.anomaly.allow.getItem
        /// </summary>
        public async Task<AdminAuditAnomalyAllowGetItemResponse> AdminAuditAnomalyAllowGetItemAsync(AdminAuditAnomalyAllowGetItemParameter parameter)
        {
            return await this.SendAsync<AdminAuditAnomalyAllowGetItemParameter, AdminAuditAnomalyAllowGetItemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.audit.anomaly.allow.getItem
        /// </summary>
        public async Task<AdminAuditAnomalyAllowGetItemResponse> AdminAuditAnomalyAllowGetItemAsync(AdminAuditAnomalyAllowGetItemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAuditAnomalyAllowGetItemParameter, AdminAuditAnomalyAllowGetItemResponse>(parameter, cancellationToken);
        }
    }
}
