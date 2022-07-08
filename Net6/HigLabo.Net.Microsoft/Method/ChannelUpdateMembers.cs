using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelUpdateMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }
            public string ChannelId { get; set; }
            public string MembershipId { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string[]? Roles { get; set; }
    }
    public partial class ChannelUpdateMembersResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string[]? Roles { get; set; }
        public DateTimeOffset? VisibleHistoryStartDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-update-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelUpdateMembersResponse> ChannelUpdateMembersAsync()
        {
            var p = new ChannelUpdateMembersParameter();
            return await this.SendAsync<ChannelUpdateMembersParameter, ChannelUpdateMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-update-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelUpdateMembersResponse> ChannelUpdateMembersAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelUpdateMembersParameter();
            return await this.SendAsync<ChannelUpdateMembersParameter, ChannelUpdateMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-update-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelUpdateMembersResponse> ChannelUpdateMembersAsync(ChannelUpdateMembersParameter parameter)
        {
            return await this.SendAsync<ChannelUpdateMembersParameter, ChannelUpdateMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-update-members?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelUpdateMembersResponse> ChannelUpdateMembersAsync(ChannelUpdateMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelUpdateMembersParameter, ChannelUpdateMembersResponse>(parameter, cancellationToken);
        }
    }
}
