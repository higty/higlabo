
namespace HigLabo.Net.Slack
{
    public class AdminConversationsCreateParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.conversations.create";
        public string HttpMethod { get; private set; } = "POST";
        public bool Is_Private { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public bool? Org_Wide { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminConversationsCreateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsCreateResponse> AdminConversationsCreateAsync(bool is_Private, string name)
        {
            var p = new AdminConversationsCreateParameter();
            p.Is_Private = is_Private;
            p.Name = name;
            return await this.SendAsync<AdminConversationsCreateParameter, AdminConversationsCreateResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsCreateResponse> AdminConversationsCreateAsync(bool is_Private, string name, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsCreateParameter();
            p.Is_Private = is_Private;
            p.Name = name;
            return await this.SendAsync<AdminConversationsCreateParameter, AdminConversationsCreateResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsCreateResponse> AdminConversationsCreateAsync(AdminConversationsCreateParameter parameter)
        {
            return await this.SendAsync<AdminConversationsCreateParameter, AdminConversationsCreateResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsCreateResponse> AdminConversationsCreateAsync(AdminConversationsCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsCreateParameter, AdminConversationsCreateResponse>(parameter, cancellationToken);
        }
    }
}
