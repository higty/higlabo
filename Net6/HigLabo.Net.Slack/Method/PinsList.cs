﻿
namespace HigLabo.Net.Slack
{
    public partial class PinsListParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "pins.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Channel { get; set; }
    }
    public partial class PinsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<PinsListResponse> PinsListAsync(string channel)
        {
            var p = new PinsListParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsListParameter, PinsListResponse>(p, CancellationToken.None);
        }
        public async Task<PinsListResponse> PinsListAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new PinsListParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsListParameter, PinsListResponse>(p, cancellationToken);
        }
        public async Task<PinsListResponse> PinsListAsync(PinsListParameter parameter)
        {
            return await this.SendAsync<PinsListParameter, PinsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<PinsListResponse> PinsListAsync(PinsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PinsListParameter, PinsListResponse>(parameter, cancellationToken);
        }
    }
}