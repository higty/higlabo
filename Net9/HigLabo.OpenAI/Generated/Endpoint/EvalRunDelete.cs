using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete an eval run.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}">https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}</seealso>
    /// </summary>
    public partial class EvalRunDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the evaluation to delete the run from.
        /// </summary>
        public string Eval_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run to delete.
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
    public partial class EvalRunDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalRunDeleteResponse> EvalRunDeleteAsync(string eval_Id, string run_Id)
        {
            var p = new EvalRunDeleteParameter();
            p.Eval_Id = eval_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunDeleteParameter, EvalRunDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunDeleteResponse> EvalRunDeleteAsync(string eval_Id, string run_Id, CancellationToken cancellationToken)
        {
            var p = new EvalRunDeleteParameter();
            p.Eval_Id = eval_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunDeleteParameter, EvalRunDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalRunDeleteResponse> EvalRunDeleteAsync(EvalRunDeleteParameter parameter)
        {
            return await this.SendJsonAsync<EvalRunDeleteParameter, EvalRunDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunDeleteResponse> EvalRunDeleteAsync(EvalRunDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalRunDeleteParameter, EvalRunDeleteResponse>(parameter, cancellationToken);
        }
    }
}
