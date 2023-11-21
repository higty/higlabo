using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminAuthPolicyRemoveEntitiesParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.auth.policy.removeEntities";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Entity_Ids { get; set; }
        public string? Entity_Type { get; set; }
        public string? Policy_Name { get; set; }
    }
    public partial class AdminAuthPolicyRemoveEntitiesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.auth.policy.removeEntities
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.removeEntities
        /// </summary>
        public async ValueTask<AdminAuthPolicyRemoveEntitiesResponse> AdminAuthPolicyRemoveEntitiesAsync(string? entity_Ids, string? entity_Type, string? policy_Name)
        {
            var p = new AdminAuthPolicyRemoveEntitiesParameter();
            p.Entity_Ids = entity_Ids;
            p.Entity_Type = entity_Type;
            p.Policy_Name = policy_Name;
            return await this.SendAsync<AdminAuthPolicyRemoveEntitiesParameter, AdminAuthPolicyRemoveEntitiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.removeEntities
        /// </summary>
        public async ValueTask<AdminAuthPolicyRemoveEntitiesResponse> AdminAuthPolicyRemoveEntitiesAsync(string? entity_Ids, string? entity_Type, string? policy_Name, CancellationToken cancellationToken)
        {
            var p = new AdminAuthPolicyRemoveEntitiesParameter();
            p.Entity_Ids = entity_Ids;
            p.Entity_Type = entity_Type;
            p.Policy_Name = policy_Name;
            return await this.SendAsync<AdminAuthPolicyRemoveEntitiesParameter, AdminAuthPolicyRemoveEntitiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.removeEntities
        /// </summary>
        public async ValueTask<AdminAuthPolicyRemoveEntitiesResponse> AdminAuthPolicyRemoveEntitiesAsync(AdminAuthPolicyRemoveEntitiesParameter parameter)
        {
            return await this.SendAsync<AdminAuthPolicyRemoveEntitiesParameter, AdminAuthPolicyRemoveEntitiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.auth.policy.removeEntities
        /// </summary>
        public async ValueTask<AdminAuthPolicyRemoveEntitiesResponse> AdminAuthPolicyRemoveEntitiesAsync(AdminAuthPolicyRemoveEntitiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAuthPolicyRemoveEntitiesParameter, AdminAuthPolicyRemoveEntitiesResponse>(parameter, cancellationToken);
        }
    }
}
