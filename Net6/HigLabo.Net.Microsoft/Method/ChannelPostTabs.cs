using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelPostTabsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Tabs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Tabs: return $"/teams/{TeamId}/channels/{ChannelId}/tabs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
        public string ChannelId { get; set; }
    }
    public partial class ChannelPostTabsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostTabsResponse> ChannelPostTabsAsync()
        {
            var p = new ChannelPostTabsParameter();
            return await this.SendAsync<ChannelPostTabsParameter, ChannelPostTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostTabsResponse> ChannelPostTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelPostTabsParameter();
            return await this.SendAsync<ChannelPostTabsParameter, ChannelPostTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostTabsResponse> ChannelPostTabsAsync(ChannelPostTabsParameter parameter)
        {
            return await this.SendAsync<ChannelPostTabsParameter, ChannelPostTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostTabsResponse> ChannelPostTabsAsync(ChannelPostTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelPostTabsParameter, ChannelPostTabsResponse>(parameter, cancellationToken);
        }
    }
}
