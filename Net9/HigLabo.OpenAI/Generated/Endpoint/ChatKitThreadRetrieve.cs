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
    /// Retrieve a ChatKit thread
    /// <seealso href="https://api.openai.com/v1/chatkit/threads/{thread_id}">https://api.openai.com/v1/chatkit/threads/{thread_id}</seealso>
    /// </summary>
    public partial class ChatKitThreadRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// Identifier of the ChatKit thread to retrieve.
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
    public partial class ChatKitThreadRetrieveResponse : ChatKitThreadObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatKitThreadRetrieveResponse> ChatKitThreadRetrieveAsync(string thread_Id)
        {
            var p = new ChatKitThreadRetrieveParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ChatKitThreadRetrieveParameter, ChatKitThreadRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitThreadRetrieveResponse> ChatKitThreadRetrieveAsync(string thread_Id, CancellationToken cancellationToken)
        {
            var p = new ChatKitThreadRetrieveParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ChatKitThreadRetrieveParameter, ChatKitThreadRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatKitThreadRetrieveResponse> ChatKitThreadRetrieveAsync(ChatKitThreadRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ChatKitThreadRetrieveParameter, ChatKitThreadRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitThreadRetrieveResponse> ChatKitThreadRetrieveAsync(ChatKitThreadRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatKitThreadRetrieveParameter, ChatKitThreadRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
