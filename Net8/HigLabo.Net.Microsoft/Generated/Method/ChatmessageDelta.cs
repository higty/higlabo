using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
    /// </summary>
    public partial class ChatmessageDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_Delta: return $"/teams/{TeamId}/channels/{ChannelId}/messages/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_Messages_Delta,
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
    public partial class ChatmessageDeltaResponse : RestApiResponse<ChatMessage>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageDeltaResponse> ChatmessageDeltaAsync()
        {
            var p = new ChatmessageDeltaParameter();
            return await this.SendAsync<ChatmessageDeltaParameter, ChatmessageDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageDeltaResponse> ChatmessageDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageDeltaParameter();
            return await this.SendAsync<ChatmessageDeltaParameter, ChatmessageDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageDeltaResponse> ChatmessageDeltaAsync(ChatmessageDeltaParameter parameter)
        {
            return await this.SendAsync<ChatmessageDeltaParameter, ChatmessageDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageDeltaResponse> ChatmessageDeltaAsync(ChatmessageDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageDeltaParameter, ChatmessageDeltaResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-delta?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ChatMessage> ChatmessageDeltaEnumerateAsync(ChatmessageDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ChatmessageDeltaParameter, ChatmessageDeltaResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ChatMessage>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
