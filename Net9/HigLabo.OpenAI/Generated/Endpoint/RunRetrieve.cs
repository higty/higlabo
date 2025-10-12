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
    /// Retrieves a run.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}">https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}</seealso>
    /// </summary>
    public partial class RunRetrieveParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the run to retrieve.
        /// </summary>
        public string Run_Id { get; set; } = "";
        /// <summary>
        /// The ID of the thread that was run.
        /// </summary>
        public string Thread_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs/{Run_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class RunRetrieveResponse : RunObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RunRetrieveResponse> RunRetrieveAsync(string run_Id, string thread_Id)
        {
            var p = new RunRetrieveParameter();
            p.Run_Id = run_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<RunRetrieveParameter, RunRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RunRetrieveResponse> RunRetrieveAsync(string run_Id, string thread_Id, CancellationToken cancellationToken)
        {
            var p = new RunRetrieveParameter();
            p.Run_Id = run_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<RunRetrieveParameter, RunRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<RunRetrieveResponse> RunRetrieveAsync(RunRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<RunRetrieveParameter, RunRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RunRetrieveResponse> RunRetrieveAsync(RunRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RunRetrieveParameter, RunRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
