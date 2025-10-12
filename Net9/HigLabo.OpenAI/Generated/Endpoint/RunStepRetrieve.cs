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
    /// Retrieves a run step.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps/{step_id}">https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps/{step_id}</seealso>
    /// </summary>
    public partial class RunStepRetrieveParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the run to which the run step belongs.
        /// </summary>
        public string Run_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run step to retrieve.
        /// </summary>
        public string Step_Id { get; set; } = "";
        /// <summary>
        /// The ID of the thread to which the run and run step belongs.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public RunStepRetrieveQueryParameter QueryParameter { get; set; } = new RunStepRetrieveQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs/{Run_Id}/steps/{Step_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class RunStepRetrieveQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A list of additional fields to include in the response. Currently the only supported value is step_details.tool_calls[*].file_search.results[*].content to fetch the file search result content.
        /// See the file search tool documentation for more information.
        /// </summary>
        public List<string>? Include { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.Include != null)
            {
                foreach (var item in this.Include)
                {
                    sb.Append($"include[]={item}&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class RunStepRetrieveResponse : RunStepObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RunStepRetrieveResponse> RunStepRetrieveAsync(string run_Id, string step_Id, string thread_Id)
        {
            var p = new RunStepRetrieveParameter();
            p.Run_Id = run_Id;
            p.Step_Id = step_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<RunStepRetrieveParameter, RunStepRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RunStepRetrieveResponse> RunStepRetrieveAsync(string run_Id, string step_Id, string thread_Id, CancellationToken cancellationToken)
        {
            var p = new RunStepRetrieveParameter();
            p.Run_Id = run_Id;
            p.Step_Id = step_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<RunStepRetrieveParameter, RunStepRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<RunStepRetrieveResponse> RunStepRetrieveAsync(RunStepRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<RunStepRetrieveParameter, RunStepRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RunStepRetrieveResponse> RunStepRetrieveAsync(RunStepRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RunStepRetrieveParameter, RunStepRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
