using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Modifies a run.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}">https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}</seealso>
    /// </summary>
    public partial class RunModifyParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the thread that was run.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run to modify.
        /// </summary>
        public string Run_Id { get; set; } = "";
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs/{Run_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	metadata = this.Metadata,
            };
        }
    }
    public partial class RunModifyResponse : RunObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RunModifyResponse> RunModifyAsync(string thread_Id, string run_Id)
        {
            var p = new RunModifyParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<RunModifyParameter, RunModifyResponse>(p, CancellationToken.None);
        }
        public async ValueTask<RunModifyResponse> RunModifyAsync(string thread_Id, string run_Id, CancellationToken cancellationToken)
        {
            var p = new RunModifyParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<RunModifyParameter, RunModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<RunModifyResponse> RunModifyAsync(RunModifyParameter parameter)
        {
            return await this.SendJsonAsync<RunModifyParameter, RunModifyResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<RunModifyResponse> RunModifyAsync(RunModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RunModifyParameter, RunModifyResponse>(parameter, cancellationToken);
        }
    }
}
