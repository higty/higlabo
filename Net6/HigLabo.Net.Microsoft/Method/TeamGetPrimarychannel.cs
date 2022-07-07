using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamGetPrimarychannelParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            DisplayName,
            Description,
            Classification,
            Specialization,
            Visibility,
            FunSettings,
            GuestSettings,
            InternalId,
            IsArchived,
            MemberSettings,
            MessagingSettings,
            WebUrl,
            CreatedDateTime,
        }
        public enum ApiPath
        {
            Teams_Id_PrimaryChannel,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_PrimaryChannel: return $"/teams/{Id}/primaryChannel";
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
        public string Id { get; set; }
    }
    public partial class TeamGetPrimarychannelResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/team-get-primarychannel?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetPrimarychannelResponse> TeamGetPrimarychannelAsync()
        {
            var p = new TeamGetPrimarychannelParameter();
            return await this.SendAsync<TeamGetPrimarychannelParameter, TeamGetPrimarychannelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get-primarychannel?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetPrimarychannelResponse> TeamGetPrimarychannelAsync(CancellationToken cancellationToken)
        {
            var p = new TeamGetPrimarychannelParameter();
            return await this.SendAsync<TeamGetPrimarychannelParameter, TeamGetPrimarychannelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get-primarychannel?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetPrimarychannelResponse> TeamGetPrimarychannelAsync(TeamGetPrimarychannelParameter parameter)
        {
            return await this.SendAsync<TeamGetPrimarychannelParameter, TeamGetPrimarychannelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-get-primarychannel?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamGetPrimarychannelResponse> TeamGetPrimarychannelAsync(TeamGetPrimarychannelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamGetPrimarychannelParameter, TeamGetPrimarychannelResponse>(parameter, cancellationToken);
        }
    }
}
