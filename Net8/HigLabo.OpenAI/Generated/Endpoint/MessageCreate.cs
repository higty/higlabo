﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create a message.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/messages">https://api.openai.com/v1/threads/{thread_id}/messages</seealso>
    /// </summary>
    public partial class MessageCreateParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the thread to create a message for.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The role of the entity that is creating the message. Allowed values include:
        /// 
        /// user: Indicates the message is sent by an actual user and should be used in most cases to represent user-generated messages.
        /// assistant: Indicates the message is generated by the assistant. Use this value to insert messages from the assistant into the conversation.
        /// </summary>
        public string Role { get; set; } = "";
        public List<MessageCreateContent> Content { get; set; } = new();
        /// <summary>
        /// A list of files attached to the message, and the tools they should be added to.
        /// </summary>
        public List<string>? Attachments { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maximum of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/messages";
        }
        public override object GetRequestBody()
        {
            return new {
            	role = this.Role,
            	content = this.Content,
            	attachments = this.Attachments,
            	metadata = this.Metadata,
            };
        }
    }
    public partial class MessageCreateResponse : MessageObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, List<MessageCreateContent> content)
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = thread_Id;
            p.Role = role;
            p.Content = content;
            return await this.SendJsonAsync<MessageCreateParameter, MessageCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, List<MessageCreateContent> content, CancellationToken cancellationToken)
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = thread_Id;
            p.Role = role;
            p.Content = content;
            return await this.SendJsonAsync<MessageCreateParameter, MessageCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<MessageCreateResponse> MessageCreateAsync(MessageCreateParameter parameter)
        {
            return await this.SendJsonAsync<MessageCreateParameter, MessageCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<MessageCreateResponse> MessageCreateAsync(MessageCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<MessageCreateParameter, MessageCreateResponse>(parameter, cancellationToken);
        }
    }
}
