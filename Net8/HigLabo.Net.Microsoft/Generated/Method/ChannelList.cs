using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
    /// </summary>
    public partial class ChannelListParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            CreatedDateTime,
            Description,
            DisplayName,
            Email,
            Id,
            IsFavoriteByDefault,
            MembershipType,
            TenantId,
            WebUrl,
            FilesFolder,
            Members,
            Messages,
            Operations,
            SharedWithTeams,
            Tabs,
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
    public partial class ChannelListResponse : RestApiResponse
    {
        public Channel[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelListResponse> ChannelListAsync()
        {
            var p = new ChannelListParameter();
            return await this.SendAsync<ChannelListParameter, ChannelListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelListResponse> ChannelListAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelListParameter();
            return await this.SendAsync<ChannelListParameter, ChannelListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelListResponse> ChannelListAsync(ChannelListParameter parameter)
        {
            return await this.SendAsync<ChannelListParameter, ChannelListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelListResponse> ChannelListAsync(ChannelListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelListParameter, ChannelListResponse>(parameter, cancellationToken);
        }
    }
}
