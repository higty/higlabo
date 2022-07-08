using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelPatchTabsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }
            public string ChannelId { get; set; }
            public string TabId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Tabs_TabId: return $"/teams/{TeamId}/channels/{ChannelId}/tabs/{TabId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Tabs_TabId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class ChannelPatchTabsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-patch-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPatchTabsResponse> ChannelPatchTabsAsync()
        {
            var p = new ChannelPatchTabsParameter();
            return await this.SendAsync<ChannelPatchTabsParameter, ChannelPatchTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-patch-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPatchTabsResponse> ChannelPatchTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelPatchTabsParameter();
            return await this.SendAsync<ChannelPatchTabsParameter, ChannelPatchTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-patch-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPatchTabsResponse> ChannelPatchTabsAsync(ChannelPatchTabsParameter parameter)
        {
            return await this.SendAsync<ChannelPatchTabsParameter, ChannelPatchTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-patch-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPatchTabsResponse> ChannelPatchTabsAsync(ChannelPatchTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelPatchTabsParameter, ChannelPatchTabsResponse>(parameter, cancellationToken);
        }
    }
}
