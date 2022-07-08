using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }

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
            Description,
            DisplayName,
            Id,
            IsFavoriteByDefault,
            Email,
            WebUrl,
            MembershipType,
            CreatedDateTime,
            Messages,
            Tabs,
            Members,
            FilesFolder,
            Operations,
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
