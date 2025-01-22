using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a thread.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}">https://api.openai.com/v1/threads/{thread_id}</seealso>
    /// </summary>
    public partial class ThreadRetrieveParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the thread to retrieve.
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
    public partial class ThreadRetrieveResponse : ThreadObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ThreadRetrieveResponse> ThreadRetrieveAsync(string thread_Id)
        {
            var p = new ThreadRetrieveParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ThreadRetrieveParameter, ThreadRetrieveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ThreadRetrieveResponse> ThreadRetrieveAsync(string thread_Id, CancellationToken cancellationToken)
        {
            var p = new ThreadRetrieveParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<ThreadRetrieveParameter, ThreadRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ThreadRetrieveResponse> ThreadRetrieveAsync(ThreadRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ThreadRetrieveParameter, ThreadRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ThreadRetrieveResponse> ThreadRetrieveAsync(ThreadRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ThreadRetrieveParameter, ThreadRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
