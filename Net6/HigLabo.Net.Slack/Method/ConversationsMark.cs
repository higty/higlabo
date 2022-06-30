﻿
namespace HigLabo.Net.Slack
{
    public partial class ConversationsMarkParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.mark";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string Ts { get; set; }
    }
    public partial class ConversationsMarkResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsMarkResponse> ConversationsMarkAsync(string channel, string ts)
        {
            var p = new ConversationsMarkParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendAsync<ConversationsMarkParameter, ConversationsMarkResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsMarkResponse> ConversationsMarkAsync(string channel, string ts, CancellationToken cancellationToken)
        {
            var p = new ConversationsMarkParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendAsync<ConversationsMarkParameter, ConversationsMarkResponse>(p, cancellationToken);
        }
        public async Task<ConversationsMarkResponse> ConversationsMarkAsync(ConversationsMarkParameter parameter)
        {
            return await this.SendAsync<ConversationsMarkParameter, ConversationsMarkResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsMarkResponse> ConversationsMarkAsync(ConversationsMarkParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsMarkParameter, ConversationsMarkResponse>(parameter, cancellationToken);
        }
    }
}