using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminEmojiAddAliasParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.emoji.addAlias";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Alias_For { get; set; }
        public string? Name { get; set; }
    }
    public partial class AdminEmojiAddAliasResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.emoji.addAlias
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.addAlias
        /// </summary>
        public async ValueTask<AdminEmojiAddAliasResponse> AdminEmojiAddAliasAsync(string? alias_For, string? name)
        {
            var p = new AdminEmojiAddAliasParameter();
            p.Alias_For = alias_For;
            p.Name = name;
            return await this.SendAsync<AdminEmojiAddAliasParameter, AdminEmojiAddAliasResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.addAlias
        /// </summary>
        public async ValueTask<AdminEmojiAddAliasResponse> AdminEmojiAddAliasAsync(string? alias_For, string? name, CancellationToken cancellationToken)
        {
            var p = new AdminEmojiAddAliasParameter();
            p.Alias_For = alias_For;
            p.Name = name;
            return await this.SendAsync<AdminEmojiAddAliasParameter, AdminEmojiAddAliasResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.addAlias
        /// </summary>
        public async ValueTask<AdminEmojiAddAliasResponse> AdminEmojiAddAliasAsync(AdminEmojiAddAliasParameter parameter)
        {
            return await this.SendAsync<AdminEmojiAddAliasParameter, AdminEmojiAddAliasResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.emoji.addAlias
        /// </summary>
        public async ValueTask<AdminEmojiAddAliasResponse> AdminEmojiAddAliasAsync(AdminEmojiAddAliasParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminEmojiAddAliasParameter, AdminEmojiAddAliasResponse>(parameter, cancellationToken);
        }
    }
}
