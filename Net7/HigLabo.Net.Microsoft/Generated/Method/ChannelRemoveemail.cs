using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-removeemail?view=graph-rest-1.0
    /// </summary>
    public partial class ChannelRemoveemailParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_RemoveEmail: return $"/teams/{TeamId}/channels/{ChannelId}/removeEmail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_RemoveEmail,
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
    public partial class ChannelRemoveemailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-removeemail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-removeemail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelRemoveemailResponse> ChannelRemoveemailAsync()
        {
            var p = new ChannelRemoveemailParameter();
            return await this.SendAsync<ChannelRemoveemailParameter, ChannelRemoveemailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-removeemail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelRemoveemailResponse> ChannelRemoveemailAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelRemoveemailParameter();
            return await this.SendAsync<ChannelRemoveemailParameter, ChannelRemoveemailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-removeemail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelRemoveemailResponse> ChannelRemoveemailAsync(ChannelRemoveemailParameter parameter)
        {
            return await this.SendAsync<ChannelRemoveemailParameter, ChannelRemoveemailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-removeemail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelRemoveemailResponse> ChannelRemoveemailAsync(ChannelRemoveemailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelRemoveemailParameter, ChannelRemoveemailResponse>(parameter, cancellationToken);
        }
    }
}
