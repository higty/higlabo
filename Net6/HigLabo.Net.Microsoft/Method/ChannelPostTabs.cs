using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelPostTabsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }
            public string ChannelId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Tabs: return $"/teams/{TeamId}/channels/{ChannelId}/tabs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Tabs,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
