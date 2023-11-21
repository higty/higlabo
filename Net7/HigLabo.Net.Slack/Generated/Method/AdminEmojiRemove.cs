using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.emoji.remove
    /// </summary>
    public partial class AdminEmojiRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.emoji.remove";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Name { get; set; }
    }
    public partial class AdminEmojiRemoveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.emoji.remove
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.remove
        /// </summary>
        public async ValueTask<AdminEmojiRemoveResponse> AdminEmojiRemoveAsync(string? name)
        {
            var p = new AdminEmojiRemoveParameter();
            p.Name = name;
            return await this.SendAsync<AdminEmojiRemoveParameter, AdminEmojiRemoveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.remove
        /// </summary>
        public async ValueTask<AdminEmojiRemoveResponse> AdminEmojiRemoveAsync(string? name, CancellationToken cancellationToken)
        {
            var p = new AdminEmojiRemoveParameter();
            p.Name = name;
            return await this.SendAsync<AdminEmojiRemoveParameter, AdminEmojiRemoveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.remove
        /// </summary>
        public async ValueTask<AdminEmojiRemoveResponse> AdminEmojiRemoveAsync(AdminEmojiRemoveParameter parameter)
        {
            return await this.SendAsync<AdminEmojiRemoveParameter, AdminEmojiRemoveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.remove
        /// </summary>
        public async ValueTask<AdminEmojiRemoveResponse> AdminEmojiRemoveAsync(AdminEmojiRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminEmojiRemoveParameter, AdminEmojiRemoveResponse>(parameter, cancellationToken);
        }
    }
}
