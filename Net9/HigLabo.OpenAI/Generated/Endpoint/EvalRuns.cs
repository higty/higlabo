using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get a list of runs for an evaluation.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}/runs">https://api.openai.com/v1/evals/{eval_id}/runs</seealso>
    /// </summary>
    public partial class EvalRunsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the evaluation to retrieve runs for.
        /// </summary>
        public string Eval_Id { get; set; } = "";
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
            return $"/evals/{Eval_Id}/runs";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class EvalRunsResponse : RestApiDataResponse<List<EvalRunObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalRunsResponse> EvalRunsAsync(string eval_Id)
        {
            var p = new EvalRunsParameter();
            p.Eval_Id = eval_Id;
            return await this.SendJsonAsync<EvalRunsParameter, EvalRunsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunsResponse> EvalRunsAsync(string eval_Id, CancellationToken cancellationToken)
        {
            var p = new EvalRunsParameter();
            p.Eval_Id = eval_Id;
            return await this.SendJsonAsync<EvalRunsParameter, EvalRunsResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalRunsResponse> EvalRunsAsync(EvalRunsParameter parameter)
        {
            return await this.SendJsonAsync<EvalRunsParameter, EvalRunsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunsResponse> EvalRunsAsync(EvalRunsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalRunsParameter, EvalRunsResponse>(parameter, cancellationToken);
        }
    }
}
