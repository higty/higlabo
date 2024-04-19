using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create a thread.
    /// <seealso href="https://api.openai.com/v1/threads">https://api.openai.com/v1/threads</seealso>
    /// </summary>
    public partial class ThreadsParameter : RestApiParameter, IRestApiParameter
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
        public override object GetRequestBody()
        {
            return new {
            	messages = this.Messages,
            	metadata = this.Metadata,
            };
        }
    }
    public partial class ThreadsResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ThreadsResponse> ThreadsAsync()
        {
            var p = new ThreadsParameter();
            return await this.SendJsonAsync<ThreadsParameter, ThreadsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ThreadsResponse> ThreadsAsync(CancellationToken cancellationToken)
        {
            var p = new ThreadsParameter();
            return await this.SendJsonAsync<ThreadsParameter, ThreadsResponse>(p, cancellationToken);
        }
        public async ValueTask<ThreadsResponse> ThreadsAsync(ThreadsParameter parameter)
        {
            return await this.SendJsonAsync<ThreadsParameter, ThreadsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ThreadsResponse> ThreadsAsync(ThreadsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ThreadsParameter, ThreadsResponse>(parameter, cancellationToken);
        }
    }
}
