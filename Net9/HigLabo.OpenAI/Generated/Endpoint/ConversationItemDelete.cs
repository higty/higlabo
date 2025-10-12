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
    /// Delete an item from a conversation with the given IDs.
    /// <seealso href="https://api.openai.com/v1/conversations/{conversation_id}/items/{item_id}">https://api.openai.com/v1/conversations/{conversation_id}/items/{item_id}</seealso>
    /// </summary>
    public partial class ConversationItemDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the conversation that contains the item.
        /// </summary>
        public string Conversation_Id { get; set; } = "";
        /// <summary>
        /// The ID of the item to delete.
        /// </summary>
        public string Item_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/conversations/{Conversation_Id}/items/{Item_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ConversationItemDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ConversationItemDeleteResponse> ConversationItemDeleteAsync(string conversation_Id, string item_Id)
        {
            var p = new ConversationItemDeleteParameter();
            p.Conversation_Id = conversation_Id;
            p.Item_Id = item_Id;
            return await this.SendJsonAsync<ConversationItemDeleteParameter, ConversationItemDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationItemDeleteResponse> ConversationItemDeleteAsync(string conversation_Id, string item_Id, CancellationToken cancellationToken)
        {
            var p = new ConversationItemDeleteParameter();
            p.Conversation_Id = conversation_Id;
            p.Item_Id = item_Id;
            return await this.SendJsonAsync<ConversationItemDeleteParameter, ConversationItemDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<ConversationItemDeleteResponse> ConversationItemDeleteAsync(ConversationItemDeleteParameter parameter)
        {
            return await this.SendJsonAsync<ConversationItemDeleteParameter, ConversationItemDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationItemDeleteResponse> ConversationItemDeleteAsync(ConversationItemDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ConversationItemDeleteParameter, ConversationItemDeleteResponse>(parameter, cancellationToken);
        }
    }
}
