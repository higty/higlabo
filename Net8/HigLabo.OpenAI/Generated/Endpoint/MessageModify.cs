using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Modifies a message.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/messages/{message_id}">https://api.openai.com/v1/threads/{thread_id}/messages/{message_id}</seealso>
    /// </summary>
    public partial class MessageModifyParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the thread to which this message belongs.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The ID of the message to modify.
        /// </summary>
        public string Message_Id { get; set; } = "";
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maximum of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/messages/{Message_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	metadata = this.Metadata,
            };
        }
    }
    public partial class MessageModifyResponse : MessageObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<MessageModifyResponse> MessageModifyAsync(string thread_Id, string message_Id)
        {
            var p = new MessageModifyParameter();
            p.Thread_Id = thread_Id;
            p.Message_Id = message_Id;
            return await this.SendJsonAsync<MessageModifyParameter, MessageModifyResponse>(p, CancellationToken.None);
        }
        public async ValueTask<MessageModifyResponse> MessageModifyAsync(string thread_Id, string message_Id, CancellationToken cancellationToken)
        {
            var p = new MessageModifyParameter();
            p.Thread_Id = thread_Id;
            p.Message_Id = message_Id;
            return await this.SendJsonAsync<MessageModifyParameter, MessageModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<MessageModifyResponse> MessageModifyAsync(MessageModifyParameter parameter)
        {
            return await this.SendJsonAsync<MessageModifyParameter, MessageModifyResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<MessageModifyResponse> MessageModifyAsync(MessageModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<MessageModifyParameter, MessageModifyResponse>(parameter, cancellationToken);
        }
    }
}
