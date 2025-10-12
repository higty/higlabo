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
    /// Get a conversation
    /// <seealso href="https://api.openai.com/v1/conversations/{conversation_id}">https://api.openai.com/v1/conversations/{conversation_id}</seealso>
    /// </summary>
    public partial class ConversationRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the conversation to retrieve.
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
    public partial class ConversationRetrieveResponse : ConversationObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ConversationRetrieveResponse> ConversationRetrieveAsync(string conversation_Id)
        {
            var p = new ConversationRetrieveParameter();
            p.Conversation_Id = conversation_Id;
            return await this.SendJsonAsync<ConversationRetrieveParameter, ConversationRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationRetrieveResponse> ConversationRetrieveAsync(string conversation_Id, CancellationToken cancellationToken)
        {
            var p = new ConversationRetrieveParameter();
            p.Conversation_Id = conversation_Id;
            return await this.SendJsonAsync<ConversationRetrieveParameter, ConversationRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ConversationRetrieveResponse> ConversationRetrieveAsync(ConversationRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ConversationRetrieveParameter, ConversationRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationRetrieveResponse> ConversationRetrieveAsync(ConversationRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ConversationRetrieveParameter, ConversationRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
