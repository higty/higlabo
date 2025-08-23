using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List all items for a conversation with the given ID.
    /// <seealso href="https://api.openai.com/v1/conversations/{conversation_id}/items">https://api.openai.com/v1/conversations/{conversation_id}/items</seealso>
    /// </summary>
    public partial class ConversationItemsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the conversation to list items for.
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

        string IRestApiParameter.GetApiPath()
        {
            return $"/conversations/{Conversation_Id}/items";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ConversationItemsResponse : RestApiDataResponse<List<ConversationItemObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ConversationItemsResponse> ConversationItemsAsync(string conversation_Id)
        {
            var p = new ConversationItemsParameter();
            p.Conversation_Id = conversation_Id;
            return await this.SendJsonAsync<ConversationItemsParameter, ConversationItemsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationItemsResponse> ConversationItemsAsync(string conversation_Id, CancellationToken cancellationToken)
        {
            var p = new ConversationItemsParameter();
            p.Conversation_Id = conversation_Id;
            return await this.SendJsonAsync<ConversationItemsParameter, ConversationItemsResponse>(p, cancellationToken);
        }
        public async ValueTask<ConversationItemsResponse> ConversationItemsAsync(ConversationItemsParameter parameter)
        {
            return await this.SendJsonAsync<ConversationItemsParameter, ConversationItemsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationItemsResponse> ConversationItemsAsync(ConversationItemsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ConversationItemsParameter, ConversationItemsResponse>(parameter, cancellationToken);
        }
    }
}
