using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelDeleteMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }
            public string? MembershipId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Members_MembershipId: return $"/teams/{TeamId}/channels/{ChannelId}/members/{MembershipId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Members_MembershipId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ChannelDeleteMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteMembersResponse> ChannelDeleteMembersAsync()
        {
            var p = new ChannelDeleteMembersParameter();
            return await this.SendAsync<ChannelDeleteMembersParameter, ChannelDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteMembersResponse> ChannelDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelDeleteMembersParameter();
            return await this.SendAsync<ChannelDeleteMembersParameter, ChannelDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteMembersResponse> ChannelDeleteMembersAsync(ChannelDeleteMembersParameter parameter)
        {
            return await this.SendAsync<ChannelDeleteMembersParameter, ChannelDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelDeleteMembersResponse> ChannelDeleteMembersAsync(ChannelDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelDeleteMembersParameter, ChannelDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
