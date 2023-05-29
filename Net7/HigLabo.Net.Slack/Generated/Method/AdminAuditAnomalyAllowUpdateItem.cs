using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminAuditAnomalyAllowUpdateItemParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.audit.anomaly.allow.updateItem";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Trusted_Asns { get; set; }
        public string? Trusted_Cidr { get; set; }
    }
    public partial class AdminAuditAnomalyAllowUpdateItemResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.audit.anomaly.allow.updateItem
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.audit.anomaly.allow.updateItem
        /// </summary>
        public async Task<AdminAuditAnomalyAllowUpdateItemResponse> AdminAuditAnomalyAllowUpdateItemAsync()
        {
            var p = new AdminAuditAnomalyAllowUpdateItemParameter();
            return await this.SendAsync<AdminAuditAnomalyAllowUpdateItemParameter, AdminAuditAnomalyAllowUpdateItemResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.audit.anomaly.allow.updateItem
        /// </summary>
        public async Task<AdminAuditAnomalyAllowUpdateItemResponse> AdminAuditAnomalyAllowUpdateItemAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAuditAnomalyAllowUpdateItemParameter();
            return await this.SendAsync<AdminAuditAnomalyAllowUpdateItemParameter, AdminAuditAnomalyAllowUpdateItemResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.audit.anomaly.allow.updateItem
        /// </summary>
        public async Task<AdminAuditAnomalyAllowUpdateItemResponse> AdminAuditAnomalyAllowUpdateItemAsync(AdminAuditAnomalyAllowUpdateItemParameter parameter)
        {
            return await this.SendAsync<AdminAuditAnomalyAllowUpdateItemParameter, AdminAuditAnomalyAllowUpdateItemResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.audit.anomaly.allow.updateItem
        /// </summary>
        public async Task<AdminAuditAnomalyAllowUpdateItemResponse> AdminAuditAnomalyAllowUpdateItemAsync(AdminAuditAnomalyAllowUpdateItemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAuditAnomalyAllowUpdateItemParameter, AdminAuditAnomalyAllowUpdateItemResponse>(parameter, cancellationToken);
        }
    }
}
