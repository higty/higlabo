using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-get?view=graph-rest-1.0
    /// </summary>
    public partial class SharedwithchannelteaminfoGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }
            public string? SharedWithChannelTeamInfoId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_SharedWithTeams_SharedWithChannelTeamInfoId: return $"/teams/{TeamId}/channels/{ChannelId}/sharedWithTeams/{SharedWithChannelTeamInfoId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_SharedWithTeams_SharedWithChannelTeamInfoId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class SharedwithchannelteaminfoGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHostTeam { get; set; }
        public string? TenantId { get; set; }
        public ConversationMember[]? AllowedMembers { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharedwithchannelteaminfoGetResponse> SharedwithchannelteaminfoGetAsync()
        {
            var p = new SharedwithchannelteaminfoGetParameter();
            return await this.SendAsync<SharedwithchannelteaminfoGetParameter, SharedwithchannelteaminfoGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharedwithchannelteaminfoGetResponse> SharedwithchannelteaminfoGetAsync(CancellationToken cancellationToken)
        {
            var p = new SharedwithchannelteaminfoGetParameter();
            return await this.SendAsync<SharedwithchannelteaminfoGetParameter, SharedwithchannelteaminfoGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharedwithchannelteaminfoGetResponse> SharedwithchannelteaminfoGetAsync(SharedwithchannelteaminfoGetParameter parameter)
        {
            return await this.SendAsync<SharedwithchannelteaminfoGetParameter, SharedwithchannelteaminfoGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharedwithchannelteaminfoGetResponse> SharedwithchannelteaminfoGetAsync(SharedwithchannelteaminfoGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SharedwithchannelteaminfoGetParameter, SharedwithchannelteaminfoGetResponse>(parameter, cancellationToken);
        }
    }
}
