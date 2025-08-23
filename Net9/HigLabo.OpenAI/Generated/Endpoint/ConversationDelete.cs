using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete a conversation with the given ID.
    /// <seealso href="https://api.openai.com/v1/conversations/{conversation_id}">https://api.openai.com/v1/conversations/{conversation_id}</seealso>
    /// </summary>
    public partial class ConversationDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the conversation to delete.
        /// </summary>
        public string Conversation_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/conversations/{Conversation_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ConversationDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ConversationDeleteResponse> ConversationDeleteAsync(string conversation_Id)
        {
            var p = new ConversationDeleteParameter();
            p.Conversation_Id = conversation_Id;
            return await this.SendJsonAsync<ConversationDeleteParameter, ConversationDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationDeleteResponse> ConversationDeleteAsync(string conversation_Id, CancellationToken cancellationToken)
        {
            var p = new ConversationDeleteParameter();
            p.Conversation_Id = conversation_Id;
            return await this.SendJsonAsync<ConversationDeleteParameter, ConversationDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<ConversationDeleteResponse> ConversationDeleteAsync(ConversationDeleteParameter parameter)
        {
            return await this.SendJsonAsync<ConversationDeleteParameter, ConversationDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationDeleteResponse> ConversationDeleteAsync(ConversationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ConversationDeleteParameter, ConversationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
