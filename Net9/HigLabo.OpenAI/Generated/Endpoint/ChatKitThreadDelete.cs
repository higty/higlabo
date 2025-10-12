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
    /// Delete a ChatKit thread
    /// <seealso href="https://api.openai.com/v1/chatkit/threads/{thread_id}">https://api.openai.com/v1/chatkit/threads/{thread_id}</seealso>
    /// </summary>
    public partial class ChatKitThreadDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// Identifier of the ChatKit thread to delete.
        /// </summary>
        public string Thread_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/chatkit/threads/{Thread_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ChatKitThreadDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatKitThreadDeleteResponse> ChatKitThreadDeleteAsync(string thread_Id)
        {
            var p = new ChatKitThreadDeleteParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ChatKitThreadDeleteParameter, ChatKitThreadDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitThreadDeleteResponse> ChatKitThreadDeleteAsync(string thread_Id, CancellationToken cancellationToken)
        {
            var p = new ChatKitThreadDeleteParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ChatKitThreadDeleteParameter, ChatKitThreadDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatKitThreadDeleteResponse> ChatKitThreadDeleteAsync(ChatKitThreadDeleteParameter parameter)
        {
            return await this.SendJsonAsync<ChatKitThreadDeleteParameter, ChatKitThreadDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitThreadDeleteResponse> ChatKitThreadDeleteAsync(ChatKitThreadDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatKitThreadDeleteParameter, ChatKitThreadDeleteResponse>(parameter, cancellationToken);
        }
    }
}
