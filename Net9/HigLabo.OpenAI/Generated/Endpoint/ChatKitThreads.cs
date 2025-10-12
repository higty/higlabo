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
    /// List ChatKit threads
    /// <seealso href="https://api.openai.com/v1/chatkit/threads">https://api.openai.com/v1/chatkit/threads</seealso>
    /// </summary>
    public partial class ChatKitThreadsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly ChatKitThreadsParameter Empty = new ChatKitThreadsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public ChatKitThreadsQueryParameter QueryParameter { get; set; } = new ChatKitThreadsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/chatkit/threads";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ChatKitThreadsQueryParameter : IQueryParameter
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
        /// <summary>
        /// Filter threads that belong to this user identifier. Defaults to null to return all users.
        /// </summary>
        public string? User { get; set; }

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
            if (this.User != null)
            {
                sb.Append($"user={WebUtility.UrlEncode(this.User)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class ChatKitThreadsResponse : RestApiDataResponse<List<ChatKitThreadObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatKitThreadsResponse> ChatKitThreadsAsync()
        {
            return await this.SendJsonAsync<ChatKitThreadsParameter, ChatKitThreadsResponse>(ChatKitThreadsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitThreadsResponse> ChatKitThreadsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatKitThreadsParameter, ChatKitThreadsResponse>(ChatKitThreadsParameter.Empty, cancellationToken);
        }
        public async ValueTask<ChatKitThreadsResponse> ChatKitThreadsAsync(ChatKitThreadsParameter parameter)
        {
            return await this.SendJsonAsync<ChatKitThreadsParameter, ChatKitThreadsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitThreadsResponse> ChatKitThreadsAsync(ChatKitThreadsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatKitThreadsParameter, ChatKitThreadsResponse>(parameter, cancellationToken);
        }
    }
}
