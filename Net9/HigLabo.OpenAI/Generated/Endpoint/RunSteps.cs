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
    /// Returns a list of run steps belonging to a run.
    /// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps">https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps</seealso>
    /// </summary>
    public partial class RunStepsParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the run the run steps belong to.
        /// </summary>
        public string Run_Id { get; set; } = "";
        /// <summary>
        /// The ID of the thread the run and run steps belong to.
        /// </summary>
        public string Thread_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public RunStepsQueryParameter QueryParameter { get; set; } = new RunStepsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/threads/{Thread_Id}/runs/{Run_Id}/steps";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class RunStepsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list.
        /// </summary>
        public string? Before { get; set; }
        /// <summary>
        /// A list of additional fields to include in the response. Currently the only supported value is step_details.tool_calls[*].file_search.results[*].content to fetch the file search result content.
        /// See the file search tool documentation for more information.
        /// </summary>
        public List<string>? Include { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order.
        /// </summary>
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Before != null)
            {
                sb.Append($"before={WebUtility.UrlEncode(this.Before)}&");
            }
            if (this.Include != null)
            {
                foreach (var item in this.Include)
                {
                    sb.Append($"include[]={item}&");
                }
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class RunStepsResponse : RestApiDataResponse<List<RunStepObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RunStepsResponse> RunStepsAsync(string run_Id, string thread_Id)
        {
            var p = new RunStepsParameter();
            p.Run_Id = run_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<RunStepsParameter, RunStepsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RunStepsResponse> RunStepsAsync(string run_Id, string thread_Id, CancellationToken cancellationToken)
        {
            var p = new RunStepsParameter();
            p.Run_Id = run_Id;
            p.Thread_Id = thread_Id;
            return await this.SendJsonAsync<RunStepsParameter, RunStepsResponse>(p, cancellationToken);
        }
        public async ValueTask<RunStepsResponse> RunStepsAsync(RunStepsParameter parameter)
        {
            return await this.SendJsonAsync<RunStepsParameter, RunStepsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RunStepsResponse> RunStepsAsync(RunStepsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RunStepsParameter, RunStepsResponse>(parameter, cancellationToken);
        }
    }
}
