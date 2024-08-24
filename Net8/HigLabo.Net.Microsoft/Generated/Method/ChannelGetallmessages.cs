using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
    /// </summary>
    public partial class ChannelGetAllMessagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

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
    public partial class ChannelGetAllMessagesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelGetAllMessagesResponse> ChannelGetAllMessagesAsync()
        {
            var p = new ChannelGetAllMessagesParameter();
            return await this.SendAsync<ChannelGetAllMessagesParameter, ChannelGetAllMessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelGetAllMessagesResponse> ChannelGetAllMessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelGetAllMessagesParameter();
            return await this.SendAsync<ChannelGetAllMessagesParameter, ChannelGetAllMessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelGetAllMessagesResponse> ChannelGetAllMessagesAsync(ChannelGetAllMessagesParameter parameter)
        {
            return await this.SendAsync<ChannelGetAllMessagesParameter, ChannelGetAllMessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-getallmessages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelGetAllMessagesResponse> ChannelGetAllMessagesAsync(ChannelGetAllMessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelGetAllMessagesParameter, ChannelGetAllMessagesResponse>(parameter, cancellationToken);
        }
    }
}
