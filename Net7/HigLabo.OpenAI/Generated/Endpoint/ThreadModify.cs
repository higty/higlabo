using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Modifies a thread.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}">https://api.openai.com/v1/threads/{thread_id}</seealso>
    /// </summary>
    public partial class ThreadModifyParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the thread to modify. Only the metadata can be modified.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}";
        }
    }
    public partial class ThreadModifyResponse : ThreadObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ThreadModifyResponse> ThreadModifyAsync(string thread_Id, CancellationToken cancellationToken)
        {
            var p = new ThreadModifyParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ThreadModifyParameter, ThreadModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<ThreadModifyResponse> ThreadModifyAsync(ThreadModifyParameter parameter)
        {
            return await this.SendJsonAsync<ThreadModifyParameter, ThreadModifyResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ThreadModifyResponse> ThreadModifyAsync(ThreadModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ThreadModifyParameter, ThreadModifyResponse>(parameter, cancellationToken);
        }
    }
}
