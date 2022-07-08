using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelGetallmessagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_GetAllMessages: return $"/teams/{TeamId}/channels/getAllMessages";
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
            Teams_TeamId_Channels_GetAllMessages,
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
    public partial class ChannelGetallmessagesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetallmessagesResponse> ChannelGetallmessagesAsync()
        {
            var p = new ChannelGetallmessagesParameter();
            return await this.SendAsync<ChannelGetallmessagesParameter, ChannelGetallmessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetallmessagesResponse> ChannelGetallmessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelGetallmessagesParameter();
            return await this.SendAsync<ChannelGetallmessagesParameter, ChannelGetallmessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetallmessagesResponse> ChannelGetallmessagesAsync(ChannelGetallmessagesParameter parameter)
        {
            return await this.SendAsync<ChannelGetallmessagesParameter, ChannelGetallmessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelGetallmessagesResponse> ChannelGetallmessagesAsync(ChannelGetallmessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelGetallmessagesParameter, ChannelGetallmessagesResponse>(parameter, cancellationToken);
        }
    }
}
