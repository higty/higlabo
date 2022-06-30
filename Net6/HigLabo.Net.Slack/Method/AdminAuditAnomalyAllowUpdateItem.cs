
namespace HigLabo.Net.Slack
{
    public partial class AdminAuditAnomalyAllowUpdateItemParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.audit.anomaly.allow.updateItem";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Trusted_Asns { get; set; }
        public string Trusted_Cidr { get; set; }
    }
    public partial class AdminAuditAnomalyAllowUpdateItemResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAuditAnomalyAllowUpdateItemResponse> AdminAuditAnomalyAllowUpdateItemAsync()
        {
            var p = new AdminAuditAnomalyAllowUpdateItemParameter();
            return await this.SendAsync<AdminAuditAnomalyAllowUpdateItemParameter, AdminAuditAnomalyAllowUpdateItemResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAuditAnomalyAllowUpdateItemResponse> AdminAuditAnomalyAllowUpdateItemAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAuditAnomalyAllowUpdateItemParameter();
            return await this.SendAsync<AdminAuditAnomalyAllowUpdateItemParameter, AdminAuditAnomalyAllowUpdateItemResponse>(p, cancellationToken);
        }
        public async Task<AdminAuditAnomalyAllowUpdateItemResponse> AdminAuditAnomalyAllowUpdateItemAsync(AdminAuditAnomalyAllowUpdateItemParameter parameter)
        {
            return await this.SendAsync<AdminAuditAnomalyAllowUpdateItemParameter, AdminAuditAnomalyAllowUpdateItemResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAuditAnomalyAllowUpdateItemResponse> AdminAuditAnomalyAllowUpdateItemAsync(AdminAuditAnomalyAllowUpdateItemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAuditAnomalyAllowUpdateItemParameter, AdminAuditAnomalyAllowUpdateItemResponse>(parameter, cancellationToken);
        }
    }
}
