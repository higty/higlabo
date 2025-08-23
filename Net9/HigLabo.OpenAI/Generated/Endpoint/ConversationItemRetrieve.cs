using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get a single item from a conversation with the given IDs.
    /// <seealso href="https://api.openai.com/v1/conversations/{conversation_id}/items/{item_id}">https://api.openai.com/v1/conversations/{conversation_id}/items/{item_id}</seealso>
    /// </summary>
    public partial class ConversationItemRetrieveParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the conversation that contains the item.
        /// </summary>
        public string Conversation_Id { get; set; } = "";
        /// <summary>
        /// The ID of the item to retrieve.
        /// </summary>
        public string Item_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/conversations/{Conversation_Id}/items/{Item_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ConversationItemRetrieveResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ConversationItemRetrieveResponse> ConversationItemRetrieveAsync(string conversation_Id, string item_Id)
        {
            var p = new ConversationItemRetrieveParameter();
            p.Conversation_Id = conversation_Id;
            p.Item_Id = item_Id;
            return await this.SendJsonAsync<ConversationItemRetrieveParameter, ConversationItemRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationItemRetrieveResponse> ConversationItemRetrieveAsync(string conversation_Id, string item_Id, CancellationToken cancellationToken)
        {
            var p = new ConversationItemRetrieveParameter();
            p.Conversation_Id = conversation_Id;
            p.Item_Id = item_Id;
            return await this.SendJsonAsync<ConversationItemRetrieveParameter, ConversationItemRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ConversationItemRetrieveResponse> ConversationItemRetrieveAsync(ConversationItemRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ConversationItemRetrieveParameter, ConversationItemRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationItemRetrieveResponse> ConversationItemRetrieveAsync(ConversationItemRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ConversationItemRetrieveParameter, ConversationItemRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
