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
        public ConversationItemsQueryParameter QueryParameter { get; set; } = new ConversationItemsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/conversations/{Conversation_Id}/items";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ConversationItemsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// An item ID to list items after, used in pagination.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Specify additional output data to include in the model response. Currently supported values are:
        /// web_search_call.action.sources: Include the sources of the web search tool call.
        /// code_interpreter_call.outputs: Includes the outputs of python code execution in code interpreter tool call items.
        /// computer_call_output.output.image_url: Include image urls from the computer call output.
        /// file_search_call.results: Include the search results of the file search tool call.
        /// message.input_image.image_url: Include image urls from the input message.
        /// message.output_text.logprobs: Include logprobs with assistant messages.
        /// reasoning.encrypted_content: Includes an encrypted version of reasoning tokens in reasoning item outputs. This enables reasoning items to be used in multi-turn conversations when using the Responses API statelessly (like when the store parameter is set to false, or when an organization is enrolled in the zero data retention program).
        /// </summary>
        public List<string>? Include { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// The order to return the input items in. Default is desc.
        /// asc: Return the input items in ascending order.
        /// desc: Return the input items in descending order.
        /// </summary>
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Include != null)
            {
                foreach (var item in this.Include)
                {
                    sb.Append($"include[]={item}&");
                }
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class ConversationItemsResponse : RestApiDataResponse<List<ConversationItemObject>>
    {
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
