using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels: return $"/teams/{TeamId}/channels";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ChannelChannelMembershipType
        {
            Standard,
            Private,
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels,
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
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsFavoriteByDefault { get; set; }
        public string? Email { get; set; }
        public string? WebUrl { get; set; }
        public ChannelChannelMembershipType MembershipType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public ChatMessage[]? Messages { get; set; }
        public TeamsTab[]? Tabs { get; set; }
        public ConversationMember[]? Members { get; set; }
        public DriveItem? FilesFolder { get; set; }
        public TeamsASyncOperation[]? Operations { get; set; }
    }
    public partial class ChannelPostResponse : RestApiResponse
    {
        public enum ChannelChannelMembershipType
        {
            Standard,
            Private,
        }

        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsFavoriteByDefault { get; set; }
        public string? Email { get; set; }
        public string? WebUrl { get; set; }
        public ChannelChannelMembershipType MembershipType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public ChatMessage[]? Messages { get; set; }
        public TeamsTab[]? Tabs { get; set; }
        public ConversationMember[]? Members { get; set; }
        public DriveItem? FilesFolder { get; set; }
        public TeamsASyncOperation[]? Operations { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostResponse> ChannelPostAsync()
        {
            var p = new ChannelPostParameter();
            return await this.SendAsync<ChannelPostParameter, ChannelPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostResponse> ChannelPostAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelPostParameter();
            return await this.SendAsync<ChannelPostParameter, ChannelPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostResponse> ChannelPostAsync(ChannelPostParameter parameter)
        {
            return await this.SendAsync<ChannelPostParameter, ChannelPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-post?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelPostResponse> ChannelPostAsync(ChannelPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelPostParameter, ChannelPostResponse>(parameter, cancellationToken);
        }
    }
}
