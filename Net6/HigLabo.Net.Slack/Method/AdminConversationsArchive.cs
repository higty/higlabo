﻿
namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsArchiveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.archive";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel_Id { get; set; }
    }
    public partial class AdminConversationsArchiveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsArchiveResponse> AdminConversationsArchiveAsync(string channel_Id)
        {
            var p = new AdminConversationsArchiveParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsArchiveParameter, AdminConversationsArchiveResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsArchiveResponse> AdminConversationsArchiveAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsArchiveParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsArchiveParameter, AdminConversationsArchiveResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsArchiveResponse> AdminConversationsArchiveAsync(AdminConversationsArchiveParameter parameter)
        {
            return await this.SendAsync<AdminConversationsArchiveParameter, AdminConversationsArchiveResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsArchiveResponse> AdminConversationsArchiveAsync(AdminConversationsArchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsArchiveParameter, AdminConversationsArchiveResponse>(parameter, cancellationToken);
        }
    }
}