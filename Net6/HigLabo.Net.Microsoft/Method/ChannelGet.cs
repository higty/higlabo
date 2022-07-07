using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Description,
            DisplayName,
            Id,
            IsFavoriteByDefault,
            Email,
            WebUrl,
            MembershipType,
            CreatedDateTime,
        }
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
        public string ChannelId { get; set; }
    }
    public partial class ChannelGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/channel-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetResponse> ChannelGetAsync()
        {
            var p = new ChannelGetParameter();
            return await this.SendAsync<ChannelGetParameter, ChannelGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetResponse> ChannelGetAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelGetParameter();
            return await this.SendAsync<ChannelGetParameter, ChannelGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetResponse> ChannelGetAsync(ChannelGetParameter parameter)
        {
            return await this.SendAsync<ChannelGetParameter, ChannelGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetResponse> ChannelGetAsync(ChannelGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelGetParameter, ChannelGetResponse>(parameter, cancellationToken);
        }
    }
}
