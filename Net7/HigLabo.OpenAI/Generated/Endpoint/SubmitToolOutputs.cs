using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// When a run has the status: "requires_action" and required_action.type is submit_tool_outputs, this endpoint can be used to submit the outputs from the tool calls once they're all completed. All outputs must be submitted in a single request.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/submit_tool_outputs">https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/submit_tool_outputs</seealso>
    /// </summary>
    public partial class SubmitToolOutputsParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the thread to which this run belongs.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run that requires the tool output submission.
        /// </summary>
        public string Run_Id { get; set; } = "";
        /// <summary>
        /// A list of tools for which the outputs are being submitted.
        /// </summary>
        public List<string>? Tool_Outputs { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs/{Run_Id}/submit_tool_outputs";
        }
    }
    public partial class SubmitToolOutputsResponse : RunObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<SubmitToolOutputsResponse> SubmitToolOutputsAsync(string thread_Id, string run_Id, List<string>? tool_Outputs)
        {
            var p = new SubmitToolOutputsParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            p.Tool_Outputs = tool_Outputs;
            return await this.SendJsonAsync<SubmitToolOutputsParameter, SubmitToolOutputsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<SubmitToolOutputsResponse> SubmitToolOutputsAsync(string thread_Id, string run_Id, List<string>? tool_Outputs, CancellationToken cancellationToken)
        {
            var p = new SubmitToolOutputsParameter();
            p.Thread_Id = thread_Id;
            p.Run_Id = run_Id;
            p.Tool_Outputs = tool_Outputs;
            return await this.SendJsonAsync<SubmitToolOutputsParameter, SubmitToolOutputsResponse>(p, cancellationToken);
        }
        public async ValueTask<SubmitToolOutputsResponse> SubmitToolOutputsAsync(SubmitToolOutputsParameter parameter)
        {
            return await this.SendJsonAsync<SubmitToolOutputsParameter, SubmitToolOutputsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<SubmitToolOutputsResponse> SubmitToolOutputsAsync(SubmitToolOutputsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<SubmitToolOutputsParameter, SubmitToolOutputsResponse>(parameter, cancellationToken);
        }
    }
}
