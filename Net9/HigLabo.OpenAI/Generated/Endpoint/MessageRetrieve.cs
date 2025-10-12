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
    /// Retrieve a message.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/messages/{message_id}">https://api.openai.com/v1/threads/{thread_id}/messages/{message_id}</seealso>
    /// </summary>
    public partial class MessageRetrieveParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the message to retrieve.
        /// </summary>
        public string Message_Id { get; set; } = "";
        /// <summary>
        /// The ID of the thread to which this message belongs.
        /// </summary>
        public string Thread_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/messages/{Message_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class MessageRetrieveResponse : MessageObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<MessageRetrieveResponse> MessageRetrieveAsync(string message_Id, string thread_Id)
        {
            var p = new MessageRetrieveParameter();
            p.Message_Id = message_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<MessageRetrieveParameter, MessageRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<MessageRetrieveResponse> MessageRetrieveAsync(string message_Id, string thread_Id, CancellationToken cancellationToken)
        {
            var p = new MessageRetrieveParameter();
            p.Message_Id = message_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<MessageRetrieveParameter, MessageRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<MessageRetrieveResponse> MessageRetrieveAsync(MessageRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<MessageRetrieveParameter, MessageRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<MessageRetrieveResponse> MessageRetrieveAsync(MessageRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<MessageRetrieveParameter, MessageRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
