using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create a thread.
    /// <seealso href="https://api.openai.com/v1/threads">https://api.openai.com/v1/threads</seealso>
    /// </summary>
    public partial class ThreadCreateParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// A list of messages to start the thread with.
        /// </summary>
        public List<string>? Messages { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads";
        }
    }
    public partial class ThreadCreateResponse : ThreadObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ThreadCreateResponse> ThreadCreateAsync()
        {
            var p = new ThreadCreateParameter();
            return await this.SendJsonAsync<ThreadCreateParameter, ThreadCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ThreadCreateResponse> ThreadCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ThreadCreateParameter();
            return await this.SendJsonAsync<ThreadCreateParameter, ThreadCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ThreadCreateResponse> ThreadCreateAsync(ThreadCreateParameter parameter)
        {
            return await this.SendJsonAsync<ThreadCreateParameter, ThreadCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ThreadCreateResponse> ThreadCreateAsync(ThreadCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ThreadCreateParameter, ThreadCreateResponse>(parameter, cancellationToken);
        }
    }
}
