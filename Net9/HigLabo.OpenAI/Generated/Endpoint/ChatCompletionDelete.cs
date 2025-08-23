using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete a stored chat completion. Only Chat Completions that have been created with the store parameter set to true can be deleted.
    /// <seealso href="https://api.openai.com/v1/chat/completions/{completion_id}">https://api.openai.com/v1/chat/completions/{completion_id}</seealso>
    /// </summary>
    public partial class ChatCompletionDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the chat completion to delete.
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
    public partial class ChatCompletionDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatCompletionDeleteResponse> ChatCompletionDeleteAsync(string completion_Id)
        {
            var p = new ChatCompletionDeleteParameter();
            p.Completion_Id = completion_Id;
            return await this.SendJsonAsync<ChatCompletionDeleteParameter, ChatCompletionDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionDeleteResponse> ChatCompletionDeleteAsync(string completion_Id, CancellationToken cancellationToken)
        {
            var p = new ChatCompletionDeleteParameter();
            p.Completion_Id = completion_Id;
            return await this.SendJsonAsync<ChatCompletionDeleteParameter, ChatCompletionDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatCompletionDeleteResponse> ChatCompletionDeleteAsync(ChatCompletionDeleteParameter parameter)
        {
            return await this.SendJsonAsync<ChatCompletionDeleteParameter, ChatCompletionDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionDeleteResponse> ChatCompletionDeleteAsync(ChatCompletionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatCompletionDeleteParameter, ChatCompletionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
