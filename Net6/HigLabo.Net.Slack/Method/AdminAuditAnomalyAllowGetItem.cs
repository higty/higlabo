
namespace HigLabo.Net.Slack
{
    public class AdminAuditAnomalyAllowGetItemParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.audit.anomaly.allow.getItem";
        public string HttpMethod { get; private set; } = "POST";
    }
    public partial class AdminAuditAnomalyAllowGetItemResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAuditAnomalyAllowGetItemResponse> AdminAuditAnomalyAllowGetItemAsync()
        {
            var p = new AdminAuditAnomalyAllowGetItemParameter();
            return await this.SendAsync<AdminAuditAnomalyAllowGetItemParameter, AdminAuditAnomalyAllowGetItemResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAuditAnomalyAllowGetItemResponse> AdminAuditAnomalyAllowGetItemAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAuditAnomalyAllowGetItemParameter();
            return await this.SendAsync<AdminAuditAnomalyAllowGetItemParameter, AdminAuditAnomalyAllowGetItemResponse>(p, cancellationToken);
        }
        public async Task<AdminAuditAnomalyAllowGetItemResponse> AdminAuditAnomalyAllowGetItemAsync(AdminAuditAnomalyAllowGetItemParameter parameter)
        {
            return await this.SendAsync<AdminAuditAnomalyAllowGetItemParameter, AdminAuditAnomalyAllowGetItemResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAuditAnomalyAllowGetItemResponse> AdminAuditAnomalyAllowGetItemAsync(AdminAuditAnomalyAllowGetItemParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAuditAnomalyAllowGetItemParameter, AdminAuditAnomalyAllowGetItemResponse>(parameter, cancellationToken);
        }
    }
}
