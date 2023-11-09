using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of runs belonging to a thread.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs">https://api.openai.com/v1/threads/{thread_id}/runs</seealso>
    /// </summary>
    public partial class RunsParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the thread the run belongs to.
        /// </summary>
        public string Thread_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs";
        }
    }
    public partial class RunsResponse : RestApiDataResponse<List<RunObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RunsResponse> RunsAsync(string thread_Id)
        {
            var p = new RunsParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<RunsParameter, RunsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<RunsResponse> RunsAsync(string thread_Id, CancellationToken cancellationToken)
        {
            var p = new RunsParameter();
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<RunsParameter, RunsResponse>(p, cancellationToken);
        }
        public async ValueTask<RunsResponse> RunsAsync(RunsParameter parameter)
        {
            return await this.SendJsonAsync<RunsParameter, RunsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<RunsResponse> RunsAsync(RunsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RunsParameter, RunsResponse>(parameter, cancellationToken);
        }
    }
}
