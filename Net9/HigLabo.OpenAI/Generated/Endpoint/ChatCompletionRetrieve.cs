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
    /// Get a stored chat completion. Only Chat Completions that have been created with the store parameter set to true will be returned.
    /// <seealso href="https://api.openai.com/v1/chat/completions/{completion_id}">https://api.openai.com/v1/chat/completions/{completion_id}</seealso>
    /// </summary>
    public partial class ChatCompletionRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the chat completion to retrieve.
        /// </summary>
        public string Completion_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/chat/completions/{Completion_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ChatCompletionRetrieveResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatCompletionRetrieveResponse> ChatCompletionRetrieveAsync(string completion_Id)
        {
            var p = new ChatCompletionRetrieveParameter();
            p.Completion_Id = completion_Id;
            return await this.SendJsonAsync<ChatCompletionRetrieveParameter, ChatCompletionRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionRetrieveResponse> ChatCompletionRetrieveAsync(string completion_Id, CancellationToken cancellationToken)
        {
            var p = new ChatCompletionRetrieveParameter();
            p.Completion_Id = completion_Id;
            return await this.SendJsonAsync<ChatCompletionRetrieveParameter, ChatCompletionRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatCompletionRetrieveResponse> ChatCompletionRetrieveAsync(ChatCompletionRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ChatCompletionRetrieveParameter, ChatCompletionRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionRetrieveResponse> ChatCompletionRetrieveAsync(ChatCompletionRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatCompletionRetrieveParameter, ChatCompletionRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
