using System.Collections.Generic;
using System.IO;
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
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/chat/completions/{Completion_Id}/messages";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ChatCompletionMessageRetrieveResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
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
