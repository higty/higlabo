using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Cancels a run that is in_progress.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/cancel">https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/cancel</seealso>
    /// </summary>
    public partial class RunCancelParameter : RestApiParameter, IRestApiParameter
    {
        internal static readonly RunCancelParameter Empty = new RunCancelParameter();

        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the thread to which this run belongs.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run to cancel.
        /// </summary>
        public string Run_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs/{Run_Id}/cancel";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class RunCancelResponse : RunObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RunCancelResponse> RunCancelAsync(string thread_Id, string run_Id)
        {
            var p = new RunCancelParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<RunCancelParameter, RunCancelResponse>(p, CancellationToken.None);
        }
        public async ValueTask<RunCancelResponse> RunCancelAsync(string thread_Id, string run_Id, CancellationToken cancellationToken)
        {
            var p = new RunCancelParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<RunCancelParameter, RunCancelResponse>(p, cancellationToken);
        }
        public async ValueTask<RunCancelResponse> RunCancelAsync(RunCancelParameter parameter)
        {
            return await this.SendJsonAsync<RunCancelParameter, RunCancelResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<RunCancelResponse> RunCancelAsync(RunCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RunCancelParameter, RunCancelResponse>(parameter, cancellationToken);
        }
    }
}
