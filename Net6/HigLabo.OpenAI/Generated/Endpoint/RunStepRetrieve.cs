using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a run step.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps/{step_id}">https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps/{step_id}</seealso>
    /// </summary>
    public partial class RunStepRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the thread to which the run and run step belongs.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run to which the run step belongs.
        /// </summary>
        public string Run_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run step to retrieve.
        /// </summary>
        public string Step_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs/{Run_Id}/steps/{Step_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class RunStepRetrieveResponse : RunStepObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RunStepRetrieveResponse> RunStepRetrieveAsync(string thread_Id, string run_Id, string step_Id)
        {
            var p = new RunStepRetrieveParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            p.Step_Id = step_Id;
            return await this.SendJsonAsync<RunStepRetrieveParameter, RunStepRetrieveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<RunStepRetrieveResponse> RunStepRetrieveAsync(string thread_Id, string run_Id, string step_Id, CancellationToken cancellationToken)
        {
            var p = new RunStepRetrieveParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            p.Step_Id = step_Id;
            return await this.SendJsonAsync<RunStepRetrieveParameter, RunStepRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<RunStepRetrieveResponse> RunStepRetrieveAsync(RunStepRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<RunStepRetrieveParameter, RunStepRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<RunStepRetrieveResponse> RunStepRetrieveAsync(RunStepRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RunStepRetrieveParameter, RunStepRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
