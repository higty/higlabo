
namespace HigLabo.Net.Slack
{
    public class AdminAuthPolicyGetEntitiesParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "admin.auth.policy.getEntities";
        public string HttpMethod { get; private set; } = "POST";
        public string Policy_Name { get; set; } = "";
        public string Cursor { get; set; } = "";
        public string Entity_Type { get; set; } = "";
        public int? Limit { get; set; }
    }
    public partial class AdminAuthPolicyGetEntitiesResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAuthPolicyGetEntitiesResponse> AdminAuthPolicyGetEntitiesAsync(string policy_Name)
        {
            var p = new AdminAuthPolicyGetEntitiesParameter();
            p.Policy_Name = policy_Name;
            return await this.SendAsync<AdminAuthPolicyGetEntitiesParameter, AdminAuthPolicyGetEntitiesResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAuthPolicyGetEntitiesResponse> AdminAuthPolicyGetEntitiesAsync(string policy_Name, CancellationToken cancellationToken)
        {
            var p = new AdminAuthPolicyGetEntitiesParameter();
            p.Policy_Name = policy_Name;
            return await this.SendAsync<AdminAuthPolicyGetEntitiesParameter, AdminAuthPolicyGetEntitiesResponse>(p, cancellationToken);
        }
        public async Task<AdminAuthPolicyGetEntitiesResponse> AdminAuthPolicyGetEntitiesAsync(AdminAuthPolicyGetEntitiesParameter parameter)
        {
            return await this.SendAsync<AdminAuthPolicyGetEntitiesParameter, AdminAuthPolicyGetEntitiesResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAuthPolicyGetEntitiesResponse> AdminAuthPolicyGetEntitiesAsync(AdminAuthPolicyGetEntitiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAuthPolicyGetEntitiesParameter, AdminAuthPolicyGetEntitiesResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminAuthPolicyGetEntitiesResponse>> AdminAuthPolicyGetEntitiesAsync(string policy_Name, PagingContext<AdminAuthPolicyGetEntitiesResponse> context)
        {
            var p = new AdminAuthPolicyGetEntitiesParameter();
            p.Policy_Name = policy_Name;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminAuthPolicyGetEntitiesResponse>> AdminAuthPolicyGetEntitiesAsync(string policy_Name, PagingContext<AdminAuthPolicyGetEntitiesResponse> context, CancellationToken cancellationToken)
        {
            var p = new AdminAuthPolicyGetEntitiesParameter();
            p.Policy_Name = policy_Name;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminAuthPolicyGetEntitiesResponse>> AdminAuthPolicyGetEntitiesAsync(AdminAuthPolicyGetEntitiesParameter parameter, PagingContext<AdminAuthPolicyGetEntitiesResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminAuthPolicyGetEntitiesResponse>> AdminAuthPolicyGetEntitiesAsync(AdminAuthPolicyGetEntitiesParameter parameter, PagingContext<AdminAuthPolicyGetEntitiesResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
