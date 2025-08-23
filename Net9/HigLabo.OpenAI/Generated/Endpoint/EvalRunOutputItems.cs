using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get a list of output items for an evaluation run.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}/output_items">https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}/output_items</seealso>
    /// </summary>
    public partial class EvalRunOutputItemsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the evaluation to retrieve runs for.
        /// </summary>
        public string Eval_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run to retrieve output items for.
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
            return $"/evals/{Eval_Id}/runs/{Run_Id}/output_items";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class EvalRunOutputItemsResponse : RestApiDataResponse<List<EvalRunOutputItemObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalRunOutputItemsResponse> EvalRunOutputItemsAsync(string eval_Id, string run_Id)
        {
            var p = new EvalRunOutputItemsParameter();
            p.Eval_Id = eval_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunOutputItemsParameter, EvalRunOutputItemsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunOutputItemsResponse> EvalRunOutputItemsAsync(string eval_Id, string run_Id, CancellationToken cancellationToken)
        {
            var p = new EvalRunOutputItemsParameter();
            p.Eval_Id = eval_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunOutputItemsParameter, EvalRunOutputItemsResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalRunOutputItemsResponse> EvalRunOutputItemsAsync(EvalRunOutputItemsParameter parameter)
        {
            return await this.SendJsonAsync<EvalRunOutputItemsParameter, EvalRunOutputItemsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunOutputItemsResponse> EvalRunOutputItemsAsync(EvalRunOutputItemsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalRunOutputItemsParameter, EvalRunOutputItemsResponse>(parameter, cancellationToken);
        }
    }
}
