using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelGetallmessagesParameter : IRestApiParameter, IQueryParameterProperty
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
            Teams_TeamId_Channels_GetAllMessages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Channels_GetAllMessages: return $"/teams/{TeamId}/channels/getAllMessages";
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
