using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of messages for a given thread.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/messages">https://api.openai.com/v1/threads/{thread_id}/messages</seealso>
    /// </summary>
    public partial class MessagesParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the thread the messages belong to.
        /// </summary>
        public string Thread_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/messages";
        }
    }
    public partial class MessagesResponse : RestApiDataResponse<List<MessageObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<MessagesResponse> MessagesAsync(string thread_Id)
        {
            var p = new MessagesParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<MessagesParameter, MessagesResponse>(p, CancellationToken.None);
        }
        public async ValueTask<MessagesResponse> MessagesAsync(string thread_Id, CancellationToken cancellationToken)
        {
            var p = new MessagesParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<MessagesParameter, MessagesResponse>(p, cancellationToken);
        }
        public async ValueTask<MessagesResponse> MessagesAsync(MessagesParameter parameter)
        {
            return await this.SendJsonAsync<MessagesParameter, MessagesResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<MessagesResponse> MessagesAsync(MessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<MessagesParameter, MessagesResponse>(parameter, cancellationToken);
        }
    }
}
