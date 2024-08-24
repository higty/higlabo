using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
    /// </summary>
    public partial class ChatGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ChatId { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Chats_ChatId: return $"/me/chats/{ChatId}";
                    case ApiPath.Users_UserIdOrUserPrincipalName_Chats_ChatId: return $"/users/{UserIdOrUserPrincipalName}/chats/{ChatId}";
                    case ApiPath.Chats_ChatId: return $"/chats/{ChatId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Chats_ChatId,
            Users_UserIdOrUserPrincipalName_Chats_ChatId,
            Chats_ChatId,
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
    public partial class ChatGetResponse : RestApiResponse<Chat>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatGetResponse> ChatGetAsync()
        {
            var p = new ChatGetParameter();
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatGetResponse> ChatGetAsync(CancellationToken cancellationToken)
        {
            var p = new ChatGetParameter();
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatGetResponse> ChatGetAsync(ChatGetParameter parameter)
        {
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatGetResponse> ChatGetAsync(ChatGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatGetParameter, ChatGetResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chat-get?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Chat> ChatGetEnumerateAsync(ChatGetParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ChatGetParameter, ChatGetResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Chat>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
