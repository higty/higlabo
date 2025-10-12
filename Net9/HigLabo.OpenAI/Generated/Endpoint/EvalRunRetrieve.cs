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
    /// Get an evaluation run by ID.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}">https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}</seealso>
    /// </summary>
    public partial class EvalRunRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the evaluation to retrieve runs for.
        /// </summary>
        public string Eval_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run to retrieve.
        /// </summary>
        public string Run_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/evals/{Eval_Id}/runs/{Run_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class EvalRunRetrieveResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalRunRetrieveResponse> EvalRunRetrieveAsync(string eval_Id, string run_Id)
        {
            var p = new EvalRunRetrieveParameter();
            p.Eval_Id = eval_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunRetrieveParameter, EvalRunRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunRetrieveResponse> EvalRunRetrieveAsync(string eval_Id, string run_Id, CancellationToken cancellationToken)
        {
            var p = new EvalRunRetrieveParameter();
            p.Eval_Id = eval_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunRetrieveParameter, EvalRunRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalRunRetrieveResponse> EvalRunRetrieveAsync(EvalRunRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<EvalRunRetrieveParameter, EvalRunRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunRetrieveResponse> EvalRunRetrieveAsync(EvalRunRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalRunRetrieveParameter, EvalRunRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
