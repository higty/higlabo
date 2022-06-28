
namespace HigLabo.Net.Slack
{
    public class AdminAuthPolicyAssignEntitiesParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.auth.policy.assignEntities";
        public string HttpMethod { get; private set; } = "POST";
        public string Entity_Ids { get; set; } = "";
        public string Entity_Type { get; set; } = "";
        public string Policy_Name { get; set; } = "";
    }
    public partial class AdminAuthPolicyAssignEntitiesResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAuthPolicyAssignEntitiesResponse> AdminAuthPolicyAssignEntitiesAsync(string entity_Ids, string entity_Type, string policy_Name)
        {
            var p = new AdminAuthPolicyAssignEntitiesParameter();
            p.Entity_Ids = entity_Ids;
            p.Entity_Type = entity_Type;
            p.Policy_Name = policy_Name;
            return await this.SendAsync<AdminAuthPolicyAssignEntitiesParameter, AdminAuthPolicyAssignEntitiesResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAuthPolicyAssignEntitiesResponse> AdminAuthPolicyAssignEntitiesAsync(string entity_Ids, string entity_Type, string policy_Name, CancellationToken cancellationToken)
        {
            var p = new AdminAuthPolicyAssignEntitiesParameter();
            p.Entity_Ids = entity_Ids;
            p.Entity_Type = entity_Type;
            p.Policy_Name = policy_Name;
            return await this.SendAsync<AdminAuthPolicyAssignEntitiesParameter, AdminAuthPolicyAssignEntitiesResponse>(p, cancellationToken);
        }
        public async Task<AdminAuthPolicyAssignEntitiesResponse> AdminAuthPolicyAssignEntitiesAsync(AdminAuthPolicyAssignEntitiesParameter parameter)
        {
            return await this.SendAsync<AdminAuthPolicyAssignEntitiesParameter, AdminAuthPolicyAssignEntitiesResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAuthPolicyAssignEntitiesResponse> AdminAuthPolicyAssignEntitiesAsync(AdminAuthPolicyAssignEntitiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAuthPolicyAssignEntitiesParameter, AdminAuthPolicyAssignEntitiesResponse>(parameter, cancellationToken);
        }
    }
}
