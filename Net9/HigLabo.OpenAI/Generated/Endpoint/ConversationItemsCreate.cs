using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create items in a conversation with the given ID.
    /// <seealso href="https://api.openai.com/v1/conversations/{conversation_id}/items">https://api.openai.com/v1/conversations/{conversation_id}/items</seealso>
    /// </summary>
    public partial class ConversationItemsCreateParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the conversation to add the item to.
        /// </summary>
        public string Conversation_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();
        /// <summary>
        /// The items to add to the conversation. You may add up to 20 items at a time.
        /// </summary>
        public List<string>? Items { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/conversations/{Conversation_Id}/items";
        }
        public override object GetRequestBody()
        {
            return new {
            	items = this.Items,
            };
        }
    }
    public partial class ConversationItemsCreateResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ConversationItemsCreateResponse> ConversationItemsCreateAsync(string conversation_Id, List<string>? items)
        {
            var p = new ConversationItemsCreateParameter();
            p.Conversation_Id = conversation_Id;
            p.Items = items;
            return await this.SendJsonAsync<ConversationItemsCreateParameter, ConversationItemsCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationItemsCreateResponse> ConversationItemsCreateAsync(string conversation_Id, List<string>? items, CancellationToken cancellationToken)
        {
            var p = new ConversationItemsCreateParameter();
            p.Conversation_Id = conversation_Id;
            p.Items = items;
            return await this.SendJsonAsync<ConversationItemsCreateParameter, ConversationItemsCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ConversationItemsCreateResponse> ConversationItemsCreateAsync(ConversationItemsCreateParameter parameter)
        {
            return await this.SendJsonAsync<ConversationItemsCreateParameter, ConversationItemsCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationItemsCreateResponse> ConversationItemsCreateAsync(ConversationItemsCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ConversationItemsCreateParameter, ConversationItemsCreateResponse>(parameter, cancellationToken);
        }
    }
}
