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
    /// Modifies a thread.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}">https://api.openai.com/v1/threads/{thread_id}</seealso>
    /// </summary>
    public partial class ThreadModifyParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the thread to modify. Only the metadata can be modified.
        /// </summary>
        public string Thread_Id { get; set; } = "";
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
            return $"/threads/{Thread_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	metadata = this.Metadata,
            	tool_resources = this.Tool_Resources,
            };
        }
    }
    public partial class ThreadModifyResponse : ThreadObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ThreadModifyResponse> ThreadModifyAsync(string thread_Id)
        {
            var p = new ThreadModifyParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ThreadModifyParameter, ThreadModifyResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ThreadModifyResponse> ThreadModifyAsync(string thread_Id, CancellationToken cancellationToken)
        {
            var p = new ThreadModifyParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ThreadModifyParameter, ThreadModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<ThreadModifyResponse> ThreadModifyAsync(ThreadModifyParameter parameter)
        {
            return await this.SendJsonAsync<ThreadModifyParameter, ThreadModifyResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ThreadModifyResponse> ThreadModifyAsync(ThreadModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ThreadModifyParameter, ThreadModifyResponse>(parameter, cancellationToken);
        }
    }
}
