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
    /// List stored Chat Completions. Only Chat Completions that have been stored with the store parameter set to true will be returned.
    /// <seealso href="https://api.openai.com/v1/chat/completions">https://api.openai.com/v1/chat/completions</seealso>
    /// </summary>
    public partial class ChatCompletionsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly ChatCompletionsParameter Empty = new ChatCompletionsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public ChatCompletionsQueryParameter QueryParameter { get; set; } = new ChatCompletionsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/chat/completions";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ChatCompletionsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Identifier for the last chat completion from the previous pagination request.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Number of Chat Completions to retrieve.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// A list of metadata keys to filter the Chat Completions by. Example:
        /// metadata[key1]=value1&metadata[key2]=value2
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// The model used to generate the Chat Completions.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// Sort order for Chat Completions by timestamp. Use asc for ascending order or desc for descending order. Defaults to asc.
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
            if (this.Metadata != null)
            {
                sb.Append($"metadata={this.Metadata}&");
            }
            if (this.Model != null)
            {
                sb.Append($"model={WebUtility.UrlEncode(this.Model)}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class ChatCompletionsResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatCompletionsResponse> ChatCompletionsAsync()
        {
            return await this.SendJsonAsync<ChatCompletionsParameter, ChatCompletionsResponse>(ChatCompletionsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionsResponse> ChatCompletionsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatCompletionsParameter, ChatCompletionsResponse>(ChatCompletionsParameter.Empty, cancellationToken);
        }
        public async ValueTask<ChatCompletionsResponse> ChatCompletionsAsync(ChatCompletionsParameter parameter)
        {
            return await this.SendJsonAsync<ChatCompletionsParameter, ChatCompletionsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionsResponse> ChatCompletionsAsync(ChatCompletionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatCompletionsParameter, ChatCompletionsResponse>(parameter, cancellationToken);
        }
    }
}
