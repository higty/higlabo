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
        public ConversationItemRetrieveQueryParameter QueryParameter { get; set; } = new ConversationItemRetrieveQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/conversations/{Conversation_Id}/items/{Item_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ConversationItemRetrieveQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Additional fields to include in the response. See the include parameter for listing Conversation items above for more information.
        /// </summary>
        public List<string>? Include { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.Include != null)
            {
                foreach (var item in this.Include)
                {
                    sb.Append($"include[]={item}&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class ConversationItemRetrieveResponse : RestApiResponse
    {
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
