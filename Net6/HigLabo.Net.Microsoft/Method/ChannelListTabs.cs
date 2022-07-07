using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelListTabsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Channels_Id_Tabs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Channels_Id_Tabs: return $"/teams/{TeamsId}/channels/{ChannelsId}/tabs";
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
        public string TeamsId { get; set; }
        public string ChannelsId { get; set; }
    }
    public partial class ChannelListTabsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/teamstab?view=graph-rest-1.0
        /// </summary>
        public partial class TeamsTab
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? WebUrl { get; set; }
            public TeamsTabConfiguration? Configuration { get; set; }
        }

        public TeamsTab[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListTabsResponse> ChannelListTabsAsync()
        {
            var p = new ChannelListTabsParameter();
            return await this.SendAsync<ChannelListTabsParameter, ChannelListTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListTabsResponse> ChannelListTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelListTabsParameter();
            return await this.SendAsync<ChannelListTabsParameter, ChannelListTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListTabsResponse> ChannelListTabsAsync(ChannelListTabsParameter parameter)
        {
            return await this.SendAsync<ChannelListTabsParameter, ChannelListTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelListTabsResponse> ChannelListTabsAsync(ChannelListTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelListTabsParameter, ChannelListTabsResponse>(parameter, cancellationToken);
        }
    }
}
