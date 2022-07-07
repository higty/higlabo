using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string TeamId { get; set; }
    }
    public partial class ChannelListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/channel?view=graph-rest-1.0
        /// </summary>
        public partial class Channel
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

        public Channel[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListResponse> ChannelListAsync()
        {
            var p = new ChannelListParameter();
            return await this.SendAsync<ChannelListParameter, ChannelListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListResponse> ChannelListAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelListParameter();
            return await this.SendAsync<ChannelListParameter, ChannelListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListResponse> ChannelListAsync(ChannelListParameter parameter)
        {
            return await this.SendAsync<ChannelListParameter, ChannelListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListResponse> ChannelListAsync(ChannelListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelListParameter, ChannelListResponse>(parameter, cancellationToken);
        }
    }
}
