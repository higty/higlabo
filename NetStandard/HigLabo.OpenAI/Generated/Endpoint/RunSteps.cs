using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of run steps belonging to a run.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps">https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps</seealso>
    /// </summary>
    public partial class RunStepsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
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
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs/{Run_Id}/steps";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class RunStepsResponse : RestApiDataResponse<List<RunStepObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
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
