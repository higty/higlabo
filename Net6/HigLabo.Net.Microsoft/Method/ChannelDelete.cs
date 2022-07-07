using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId: return $"/teams/{TeamId}/channels/{ChannelId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TeamId { get; set; }
        public string ChannelId { get; set; }
    }
    public partial class ChannelDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteResponse> ChannelDeleteAsync()
        {
            var p = new ChannelDeleteParameter();
            return await this.SendAsync<ChannelDeleteParameter, ChannelDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteResponse> ChannelDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelDeleteParameter();
            return await this.SendAsync<ChannelDeleteParameter, ChannelDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteResponse> ChannelDeleteAsync(ChannelDeleteParameter parameter)
        {
            return await this.SendAsync<ChannelDeleteParameter, ChannelDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteResponse> ChannelDeleteAsync(ChannelDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelDeleteParameter, ChannelDeleteResponse>(parameter, cancellationToken);
        }
    }
}
