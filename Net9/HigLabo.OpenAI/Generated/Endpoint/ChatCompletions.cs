using System.Collections.Generic;
using System.IO;
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
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/chat/completions";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ChatCompletionsResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
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
