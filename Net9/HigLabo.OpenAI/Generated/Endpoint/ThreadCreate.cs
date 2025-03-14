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
    public partial class ThreadCreateParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// A list of messages to start the thread with.
        /// </summary>
        public List<Message>? Messages { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// A set of resources that are made available to the assistant's tools in this thread. The resources are specific to the type of tool. For example, the code_interpreter tool requires a list of file IDs, while the file_search tool requires a list of vector store IDs.
        /// </summary>
        public object? Tool_Resources { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads";
        }
        public override object GetRequestBody()
        {
            return new {
            	messages = this.Messages,
            	metadata = this.Metadata,
            	tool_resources = this.Tool_Resources,
            };
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
            return await this.SendJsonAsync<ThreadCreateParameter, ThreadCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ThreadCreateResponse> ThreadCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ThreadCreateParameter();
            return await this.SendJsonAsync<ThreadCreateParameter, ThreadCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ThreadCreateResponse> ThreadCreateAsync(ThreadCreateParameter parameter)
        {
            return await this.SendJsonAsync<ThreadCreateParameter, ThreadCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ThreadCreateResponse> ThreadCreateAsync(ThreadCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ThreadCreateParameter, ThreadCreateResponse>(parameter, cancellationToken);
        }
    }
}
