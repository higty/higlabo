
namespace HigLabo.Net.Slack
{
    public class AdminEmojiRemoveParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.emoji.remove";
        public string HttpMethod { get; private set; } = "GET";
        public string Name { get; set; } = "";
    }
    public partial class AdminEmojiRemoveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminEmojiRemoveResponse> AdminEmojiRemoveAsync(string name)
        {
            var p = new AdminEmojiRemoveParameter();
            p.Name = name;
            return await this.SendAsync<AdminEmojiRemoveParameter, AdminEmojiRemoveResponse>(p, CancellationToken.None);
        }
        public async Task<AdminEmojiRemoveResponse> AdminEmojiRemoveAsync(string name, CancellationToken cancellationToken)
        {
            var p = new AdminEmojiRemoveParameter();
            p.Name = name;
            return await this.SendAsync<AdminEmojiRemoveParameter, AdminEmojiRemoveResponse>(p, cancellationToken);
        }
        public async Task<AdminEmojiRemoveResponse> AdminEmojiRemoveAsync(AdminEmojiRemoveParameter parameter)
        {
            return await this.SendAsync<AdminEmojiRemoveParameter, AdminEmojiRemoveResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminEmojiRemoveResponse> AdminEmojiRemoveAsync(AdminEmojiRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminEmojiRemoveParameter, AdminEmojiRemoveResponse>(parameter, cancellationToken);
        }
    }
}
