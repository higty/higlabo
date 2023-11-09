using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create a message.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/messages">https://api.openai.com/v1/threads/{thread_id}/messages</seealso>
    /// </summary>
    public partial class MessageCreateParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the thread to create a message for.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The role of the entity that is creating the message. Currently only user is supported.
        /// </summary>
        public string Role { get; set; } = "";
        /// <summary>
        /// The content of the message.
        /// </summary>
        public string Content { get; set; } = "";
        /// <summary>
        /// A list of File IDs that the message should use. There can be a maximum of 10 files attached to a message. Useful for tools like retrieval and code_interpreter that can access and use files.
        /// </summary>
        public List<string>? File_Ids { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/messages";
        }
    }
    public partial class MessageCreateResponse : MessageObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, string content)
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = thread_Id;
            p.Role = role;
            p.Content = content;
            return await this.SendJsonAsync<MessageCreateParameter, MessageCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<MessageCreateResponse> MessageCreateAsync(string thread_Id, string role, string content, CancellationToken cancellationToken)
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
