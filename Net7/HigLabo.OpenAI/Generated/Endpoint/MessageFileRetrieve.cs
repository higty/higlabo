using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a message file.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/messages/{message_id}/files/{file_id}">https://api.openai.com/v1/threads/{thread_id}/messages/{message_id}/files/{file_id}</seealso>
    /// </summary>
    public partial class MessageFileRetrieveParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the thread to which the message and File belong.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The ID of the message the file belongs to.
        /// </summary>
        public string Message_Id { get; set; } = "";
        /// <summary>
        /// The ID of the file being retrieved.
        /// </summary>
        public string File_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/messages/{Message_Id}/files/{File_Id}";
        }
    }
    public partial class MessageFileRetrieveResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<MessageFileRetrieveResponse> MessageFileRetrieveAsync(string thread_Id, string message_Id, string file_Id)
        {
            var p = new MessageFileRetrieveParameter();
            p.Thread_Id = thread_Id;
            p.Message_Id = message_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<MessageFileRetrieveParameter, MessageFileRetrieveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<MessageFileRetrieveResponse> MessageFileRetrieveAsync(string thread_Id, string message_Id, string file_Id, CancellationToken cancellationToken)
        {
            var p = new MessageFileRetrieveParameter();
            p.Thread_Id = thread_Id;
            p.Message_Id = message_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<MessageFileRetrieveParameter, MessageFileRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<MessageFileRetrieveResponse> MessageFileRetrieveAsync(MessageFileRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<MessageFileRetrieveParameter, MessageFileRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<MessageFileRetrieveResponse> MessageFileRetrieveAsync(MessageFileRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<MessageFileRetrieveParameter, MessageFileRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
