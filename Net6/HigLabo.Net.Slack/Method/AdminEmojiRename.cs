
namespace HigLabo.Net.Slack
{
    public partial class AdminEmojiRenameParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.emoji.rename";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Name { get; set; }
        public string New_Name { get; set; }
    }
    public partial class AdminEmojiRenameResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.rename
        /// </summary>
        public async Task<AdminEmojiRenameResponse> AdminEmojiRenameAsync(string name, string new_Name)
        {
            var p = new AdminEmojiRenameParameter();
            p.Name = name;
            p.New_Name = new_Name;
            return await this.SendAsync<AdminEmojiRenameParameter, AdminEmojiRenameResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.rename
        /// </summary>
        public async Task<AdminEmojiRenameResponse> AdminEmojiRenameAsync(string name, string new_Name, CancellationToken cancellationToken)
        {
            var p = new AdminEmojiRenameParameter();
            p.Name = name;
            p.New_Name = new_Name;
            return await this.SendAsync<AdminEmojiRenameParameter, AdminEmojiRenameResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.rename
        /// </summary>
        public async Task<AdminEmojiRenameResponse> AdminEmojiRenameAsync(AdminEmojiRenameParameter parameter)
        {
            return await this.SendAsync<AdminEmojiRenameParameter, AdminEmojiRenameResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.rename
        /// </summary>
        public async Task<AdminEmojiRenameResponse> AdminEmojiRenameAsync(AdminEmojiRenameParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminEmojiRenameParameter, AdminEmojiRenameResponse>(parameter, cancellationToken);
        }
    }
}
