using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List ChatKit thread items
    /// <seealso href="https://api.openai.com/v1/chatkit/threads/{thread_id}/items">https://api.openai.com/v1/chatkit/threads/{thread_id}/items</seealso>
    /// </summary>
    public partial class ChatKitThreadItemsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// Identifier of the ChatKit thread whose items are requested.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public ChatKitThreadItemsQueryParameter QueryParameter { get; set; } = new ChatKitThreadItemsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/chatkit/threads/{Thread_Id}/items";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ChatKitThreadItemsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// List items created after this thread item ID. Defaults to null for the first page.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// List items created before this thread item ID. Defaults to null for the newest results.
        /// </summary>
        public string? Before { get; set; }
        /// <summary>
        /// Maximum number of thread items to return. Defaults to 20.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order for results by creation time. Defaults to desc.
        /// </summary>
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Before != null)
            {
                sb.Append($"before={WebUtility.UrlEncode(this.Before)}&");
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class ChatKitThreadItemsResponse : RestApiDataResponse<List<ChatKitThreadItemsObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatKitThreadItemsResponse> ChatKitThreadItemsAsync(string thread_Id)
        {
            var p = new ChatKitThreadItemsParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ChatKitThreadItemsParameter, ChatKitThreadItemsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitThreadItemsResponse> ChatKitThreadItemsAsync(string thread_Id, CancellationToken cancellationToken)
        {
            var p = new ChatKitThreadItemsParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ChatKitThreadItemsParameter, ChatKitThreadItemsResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatKitThreadItemsResponse> ChatKitThreadItemsAsync(ChatKitThreadItemsParameter parameter)
        {
            return await this.SendJsonAsync<ChatKitThreadItemsParameter, ChatKitThreadItemsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitThreadItemsResponse> ChatKitThreadItemsAsync(ChatKitThreadItemsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatKitThreadItemsParameter, ChatKitThreadItemsResponse>(parameter, cancellationToken);
        }
    }
}
