using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of run steps belonging to a run.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps">https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps</seealso>
    /// </summary>
    public partial class RunStepsParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the thread the run and run steps belong to.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run the run steps belong to.
        /// </summary>
        public string Run_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs/{Run_Id}/steps";
        }
    }
    public partial class RunStepsResponse : RestApiDataResponse<List<RunStepObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RunStepsResponse> RunStepsAsync(string thread_Id, string run_Id)
        {
            var p = new RunStepsParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<RunStepsParameter, RunStepsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<RunStepsResponse> RunStepsAsync(string thread_Id, string run_Id, CancellationToken cancellationToken)
        {
            var p = new RunStepsParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<RunStepsParameter, RunStepsResponse>(p, cancellationToken);
        }
        public async ValueTask<RunStepsResponse> RunStepsAsync(RunStepsParameter parameter)
        {
            return await this.SendJsonAsync<RunStepsParameter, RunStepsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<RunStepsResponse> RunStepsAsync(RunStepsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RunStepsParameter, RunStepsResponse>(parameter, cancellationToken);
        }
    }
}
