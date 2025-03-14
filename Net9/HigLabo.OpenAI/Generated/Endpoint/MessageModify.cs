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
        /// The ID of the message to modify.
        /// </summary>
        public string Message_Id { get; set; } = "";
        /// <summary>
        /// The ID of the thread to which this message belongs.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
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
        public async ValueTask<MessageModifyResponse> MessageModifyAsync(string message_Id, string thread_Id)
        {
            var p = new MessageModifyParameter();
            p.Message_Id = message_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<MessageModifyParameter, MessageModifyResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<MessageModifyResponse> MessageModifyAsync(string message_Id, string thread_Id, CancellationToken cancellationToken)
        {
            var p = new MessageModifyParameter();
            p.Message_Id = message_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<MessageModifyParameter, MessageModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<MessageModifyResponse> MessageModifyAsync(MessageModifyParameter parameter)
        {
            return await this.SendJsonAsync<MessageModifyParameter, MessageModifyResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<MessageModifyResponse> MessageModifyAsync(MessageModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<MessageModifyParameter, MessageModifyResponse>(parameter, cancellationToken);
        }
    }
}
