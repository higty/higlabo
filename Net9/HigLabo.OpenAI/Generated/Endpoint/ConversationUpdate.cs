using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Update a conversation's metadata with the given ID.
    /// <seealso href="https://api.openai.com/v1/conversations/{conversation_id}">https://api.openai.com/v1/conversations/{conversation_id}</seealso>
    /// </summary>
    public partial class ConversationUpdateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the conversation to update.
        /// </summary>
        public string Conversation_Id { get; set; } = "";
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard. Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/conversations/{Conversation_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	metadata = this.Metadata,
            };
        }
    }
    public partial class ConversationUpdateResponse : ConversationObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ConversationUpdateResponse> ConversationUpdateAsync(string conversation_Id, object? metadata)
        {
            var p = new ConversationUpdateParameter();
            p.Conversation_Id = conversation_Id;
            p.Metadata = metadata;
            return await this.SendJsonAsync<ConversationUpdateParameter, ConversationUpdateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationUpdateResponse> ConversationUpdateAsync(string conversation_Id, object? metadata, CancellationToken cancellationToken)
        {
            var p = new ConversationUpdateParameter();
            p.Conversation_Id = conversation_Id;
            p.Metadata = metadata;
            return await this.SendJsonAsync<ConversationUpdateParameter, ConversationUpdateResponse>(p, cancellationToken);
        }
        public async ValueTask<ConversationUpdateResponse> ConversationUpdateAsync(ConversationUpdateParameter parameter)
        {
            return await this.SendJsonAsync<ConversationUpdateParameter, ConversationUpdateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationUpdateResponse> ConversationUpdateAsync(ConversationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ConversationUpdateParameter, ConversationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
