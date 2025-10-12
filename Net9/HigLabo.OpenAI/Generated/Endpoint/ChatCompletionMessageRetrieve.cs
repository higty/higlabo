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
    /// Get the messages in a stored chat completion. Only Chat Completions that have been created with the store parameter set to true will be returned.
    /// <seealso href="https://api.openai.com/v1/chat/completions/{completion_id}/messages">https://api.openai.com/v1/chat/completions/{completion_id}/messages</seealso>
    /// </summary>
    public partial class ChatCompletionMessageRetrieveParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the chat completion to retrieve messages from.
        /// </summary>
        public string Completion_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public ChatCompletionMessageRetrieveQueryParameter QueryParameter { get; set; } = new ChatCompletionMessageRetrieveQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/chat/completions/{Completion_Id}/messages";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ChatCompletionMessageRetrieveQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Identifier for the last message from the previous pagination request.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Number of messages to retrieve.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order for messages by timestamp. Use asc for ascending order or desc for descending order. Defaults to asc.
        /// </summary>
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
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
    public partial class ChatCompletionMessageRetrieveResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatCompletionMessageRetrieveResponse> ChatCompletionMessageRetrieveAsync(string completion_Id)
        {
            var p = new ChatCompletionMessageRetrieveParameter();
            p.Completion_Id = completion_Id;
            return await this.SendJsonAsync<ChatCompletionMessageRetrieveParameter, ChatCompletionMessageRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionMessageRetrieveResponse> ChatCompletionMessageRetrieveAsync(string completion_Id, CancellationToken cancellationToken)
        {
            var p = new ChatCompletionMessageRetrieveParameter();
            p.Completion_Id = completion_Id;
            return await this.SendJsonAsync<ChatCompletionMessageRetrieveParameter, ChatCompletionMessageRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatCompletionMessageRetrieveResponse> ChatCompletionMessageRetrieveAsync(ChatCompletionMessageRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ChatCompletionMessageRetrieveParameter, ChatCompletionMessageRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionMessageRetrieveResponse> ChatCompletionMessageRetrieveAsync(ChatCompletionMessageRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatCompletionMessageRetrieveParameter, ChatCompletionMessageRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
