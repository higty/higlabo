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
    /// Modify a stored chat completion. Only Chat Completions that have been created with the store parameter set to true can be modified. Currently, the only supported modification is to update the metadata field.
    /// <seealso href="https://api.openai.com/v1/chat/completions/{completion_id}">https://api.openai.com/v1/chat/completions/{completion_id}</seealso>
    /// </summary>
    public partial class ChatCompletionUpdateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the chat completion to update.
        /// </summary>
        public string Completion_Id { get; set; } = "";
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/chat/completions/{Completion_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	metadata = this.Metadata,
            };
        }
    }
    public partial class ChatCompletionUpdateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatCompletionUpdateResponse> ChatCompletionUpdateAsync(string completion_Id, object? metadata)
        {
            var p = new ChatCompletionUpdateParameter();
            p.Completion_Id = completion_Id;
            p.Metadata = metadata;
            return await this.SendJsonAsync<ChatCompletionUpdateParameter, ChatCompletionUpdateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionUpdateResponse> ChatCompletionUpdateAsync(string completion_Id, object? metadata, CancellationToken cancellationToken)
        {
            var p = new ChatCompletionUpdateParameter();
            p.Completion_Id = completion_Id;
            p.Metadata = metadata;
            return await this.SendJsonAsync<ChatCompletionUpdateParameter, ChatCompletionUpdateResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatCompletionUpdateResponse> ChatCompletionUpdateAsync(ChatCompletionUpdateParameter parameter)
        {
            return await this.SendJsonAsync<ChatCompletionUpdateParameter, ChatCompletionUpdateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatCompletionUpdateResponse> ChatCompletionUpdateAsync(ChatCompletionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatCompletionUpdateParameter, ChatCompletionUpdateResponse>(parameter, cancellationToken);
        }
    }
}
