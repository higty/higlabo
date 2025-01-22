using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete a thread.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}">https://api.openai.com/v1/threads/{thread_id}</seealso>
    /// </summary>
    public partial class ThreadDeleteParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the thread to delete.
        /// </summary>
        public string Thread_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ThreadDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ThreadDeleteResponse> ThreadDeleteAsync(string thread_Id)
        {
            var p = new ThreadDeleteParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ThreadDeleteParameter, ThreadDeleteResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ThreadDeleteResponse> ThreadDeleteAsync(string thread_Id, CancellationToken cancellationToken)
        {
            var p = new ThreadDeleteParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ThreadDeleteParameter, ThreadDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<ThreadDeleteResponse> ThreadDeleteAsync(ThreadDeleteParameter parameter)
        {
            return await this.SendJsonAsync<ThreadDeleteParameter, ThreadDeleteResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ThreadDeleteResponse> ThreadDeleteAsync(ThreadDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ThreadDeleteParameter, ThreadDeleteResponse>(parameter, cancellationToken);
        }
    }
}
