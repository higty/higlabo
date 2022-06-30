
namespace HigLabo.Net.Slack
{
    public partial class AdminEmojiAddParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.emoji.add";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Name { get; set; }
        public string Url { get; set; }
    }
    public partial class AdminEmojiAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminEmojiAddResponse> AdminEmojiAddAsync(string name, string url)
        {
            var p = new AdminEmojiAddParameter();
            p.Name = name;
            p.Url = url;
            return await this.SendAsync<AdminEmojiAddParameter, AdminEmojiAddResponse>(p, CancellationToken.None);
        }
        public async Task<AdminEmojiAddResponse> AdminEmojiAddAsync(string name, string url, CancellationToken cancellationToken)
        {
            var p = new AdminEmojiAddParameter();
            p.Name = name;
            p.Url = url;
            return await this.SendAsync<AdminEmojiAddParameter, AdminEmojiAddResponse>(p, cancellationToken);
        }
        public async Task<AdminEmojiAddResponse> AdminEmojiAddAsync(AdminEmojiAddParameter parameter)
        {
            return await this.SendAsync<AdminEmojiAddParameter, AdminEmojiAddResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminEmojiAddResponse> AdminEmojiAddAsync(AdminEmojiAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminEmojiAddParameter, AdminEmojiAddResponse>(parameter, cancellationToken);
        }
    }
}
