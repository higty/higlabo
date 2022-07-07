using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelPostParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Channels,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels: return $"/teams/{TeamId}/channels";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
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
        public Enum? MembershipType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
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
