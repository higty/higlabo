using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelDeleteTabsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Tabs_TabId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Tabs_TabId: return $"/teams/{TeamId}/channels/{ChannelId}/tabs/{TabId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TeamId { get; set; }
        public string ChannelId { get; set; }
        public string TabId { get; set; }
    }
    public partial class ChannelDeleteTabsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteTabsResponse> ChannelDeleteTabsAsync()
        {
            var p = new ChannelDeleteTabsParameter();
            return await this.SendAsync<ChannelDeleteTabsParameter, ChannelDeleteTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteTabsResponse> ChannelDeleteTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelDeleteTabsParameter();
            return await this.SendAsync<ChannelDeleteTabsParameter, ChannelDeleteTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteTabsResponse> ChannelDeleteTabsAsync(ChannelDeleteTabsParameter parameter)
        {
            return await this.SendAsync<ChannelDeleteTabsParameter, ChannelDeleteTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteTabsResponse> ChannelDeleteTabsAsync(ChannelDeleteTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelDeleteTabsParameter, ChannelDeleteTabsResponse>(parameter, cancellationToken);
        }
    }
}
