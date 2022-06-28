
namespace HigLabo.Net.Slack
{
    public class AdminEmojiRenameParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.emoji.rename";
        public string HttpMethod { get; private set; } = "GET";
        public string Name { get; set; } = "";
        public string New_Name { get; set; } = "";
    }
    public partial class AdminEmojiRenameResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminEmojiRenameResponse> AdminEmojiRenameAsync(string name, string new_Name)
        {
            var p = new AdminEmojiRenameParameter();
            p.Name = name;
            p.New_Name = new_Name;
            return await this.SendAsync<AdminEmojiRenameParameter, AdminEmojiRenameResponse>(p, CancellationToken.None);
        }
        public async Task<AdminEmojiRenameResponse> AdminEmojiRenameAsync(string name, string new_Name, CancellationToken cancellationToken)
        {
            var p = new AdminEmojiRenameParameter();
            p.Name = name;
            p.New_Name = new_Name;
            return await this.SendAsync<AdminEmojiRenameParameter, AdminEmojiRenameResponse>(p, cancellationToken);
        }
        public async Task<AdminEmojiRenameResponse> AdminEmojiRenameAsync(AdminEmojiRenameParameter parameter)
        {
            return await this.SendAsync<AdminEmojiRenameParameter, AdminEmojiRenameResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminEmojiRenameResponse> AdminEmojiRenameAsync(AdminEmojiRenameParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminEmojiRenameParameter, AdminEmojiRenameResponse>(parameter, cancellationToken);
        }
    }
}
