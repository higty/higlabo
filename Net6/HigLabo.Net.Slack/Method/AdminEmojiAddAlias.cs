﻿
namespace HigLabo.Net.Slack
{
    public partial class AdminEmojiAddAliasParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.emoji.addAlias";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Alias_For { get; set; }
        public string Name { get; set; }
    }
    public partial class AdminEmojiAddAliasResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminEmojiAddAliasResponse> AdminEmojiAddAliasAsync(string alias_For, string name)
        {
            var p = new AdminEmojiAddAliasParameter();
            p.Alias_For = alias_For;
            p.Name = name;
            return await this.SendAsync<AdminEmojiAddAliasParameter, AdminEmojiAddAliasResponse>(p, CancellationToken.None);
        }
        public async Task<AdminEmojiAddAliasResponse> AdminEmojiAddAliasAsync(string alias_For, string name, CancellationToken cancellationToken)
        {
            var p = new AdminEmojiAddAliasParameter();
            p.Alias_For = alias_For;
            p.Name = name;
            return await this.SendAsync<AdminEmojiAddAliasParameter, AdminEmojiAddAliasResponse>(p, cancellationToken);
        }
        public async Task<AdminEmojiAddAliasResponse> AdminEmojiAddAliasAsync(AdminEmojiAddAliasParameter parameter)
        {
            return await this.SendAsync<AdminEmojiAddAliasParameter, AdminEmojiAddAliasResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminEmojiAddAliasResponse> AdminEmojiAddAliasAsync(AdminEmojiAddAliasParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminEmojiAddAliasParameter, AdminEmojiAddAliasResponse>(parameter, cancellationToken);
        }
    }
}