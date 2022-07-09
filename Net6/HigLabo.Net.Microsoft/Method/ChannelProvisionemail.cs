using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelProvisionemailParameter : IRestApiParameter
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
                    case ApiPath.Teams_TeamId_Channels_ChannelId_ProvisionEmail: return $"/teams/{TeamId}/channels/{ChannelId}/provisionEmail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_ProvisionEmail,
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
        public string? Email { get; set; }
    }
    public partial class ChannelProvisionemailResponse : RestApiResponse
    {
        public string? Email { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-provisionemail?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelProvisionemailResponse> ChannelProvisionemailAsync()
        {
            var p = new ChannelProvisionemailParameter();
            return await this.SendAsync<ChannelProvisionemailParameter, ChannelProvisionemailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-provisionemail?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelProvisionemailResponse> ChannelProvisionemailAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelProvisionemailParameter();
            return await this.SendAsync<ChannelProvisionemailParameter, ChannelProvisionemailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-provisionemail?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelProvisionemailResponse> ChannelProvisionemailAsync(ChannelProvisionemailParameter parameter)
        {
            return await this.SendAsync<ChannelProvisionemailParameter, ChannelProvisionemailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-provisionemail?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelProvisionemailResponse> ChannelProvisionemailAsync(ChannelProvisionemailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelProvisionemailParameter, ChannelProvisionemailResponse>(parameter, cancellationToken);
        }
    }
}
