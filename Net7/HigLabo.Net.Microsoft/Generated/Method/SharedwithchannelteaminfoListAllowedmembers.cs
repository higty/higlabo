using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
    /// </summary>
    public partial class SharedwithchannelteaminfoListAllowedmembersParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Teams_TeamId_Channels_ChannelId_SharedWithTeams_SharedWithChannelTeamInfoId_AllowedMembers: return $"/teams/{TeamId}/channels/{ChannelId}/sharedWithTeams/{SharedWithChannelTeamInfoId}/allowedMembers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_SharedWithTeams_SharedWithChannelTeamInfoId_AllowedMembers,
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
    public partial class SharedwithchannelteaminfoListAllowedmembersResponse : RestApiResponse
    {
        public ConversationMember[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharedwithchannelteaminfoListAllowedmembersResponse> SharedwithchannelteaminfoListAllowedmembersAsync()
        {
            var p = new SharedwithchannelteaminfoListAllowedmembersParameter();
            return await this.SendAsync<SharedwithchannelteaminfoListAllowedmembersParameter, SharedwithchannelteaminfoListAllowedmembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharedwithchannelteaminfoListAllowedmembersResponse> SharedwithchannelteaminfoListAllowedmembersAsync(CancellationToken cancellationToken)
        {
            var p = new SharedwithchannelteaminfoListAllowedmembersParameter();
            return await this.SendAsync<SharedwithchannelteaminfoListAllowedmembersParameter, SharedwithchannelteaminfoListAllowedmembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharedwithchannelteaminfoListAllowedmembersResponse> SharedwithchannelteaminfoListAllowedmembersAsync(SharedwithchannelteaminfoListAllowedmembersParameter parameter)
        {
            return await this.SendAsync<SharedwithchannelteaminfoListAllowedmembersParameter, SharedwithchannelteaminfoListAllowedmembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/sharedwithchannelteaminfo-list-allowedmembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SharedwithchannelteaminfoListAllowedmembersResponse> SharedwithchannelteaminfoListAllowedmembersAsync(SharedwithchannelteaminfoListAllowedmembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SharedwithchannelteaminfoListAllowedmembersParameter, SharedwithchannelteaminfoListAllowedmembersResponse>(parameter, cancellationToken);
        }
    }
}
