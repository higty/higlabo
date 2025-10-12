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
    /// Create a conversation.
    /// <seealso href="https://api.openai.com/v1/conversations">https://api.openai.com/v1/conversations</seealso>
    /// </summary>
    public partial class ConversationsParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// Initial items to include in the conversation context. You may add up to 20 items at a time.
        /// </summary>
        public List<string>? Items { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard. Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/conversations";
        }
        public override object GetRequestBody()
        {
            return new {
            	items = this.Items,
            	metadata = this.Metadata,
            };
        }
    }
    public partial class ConversationsResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ConversationsResponse> ConversationsAsync()
        {
            var p = new ConversationsParameter();
            return await this.SendJsonAsync<ConversationsParameter, ConversationsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationsResponse> ConversationsAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationsParameter();
            return await this.SendJsonAsync<ConversationsParameter, ConversationsResponse>(p, cancellationToken);
        }
        public async ValueTask<ConversationsResponse> ConversationsAsync(ConversationsParameter parameter)
        {
            return await this.SendJsonAsync<ConversationsParameter, ConversationsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ConversationsResponse> ConversationsAsync(ConversationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ConversationsParameter, ConversationsResponse>(parameter, cancellationToken);
        }
    }
}
