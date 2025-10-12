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
    /// Cancel an ongoing evaluation run.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}">https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}</seealso>
    /// </summary>
    public partial class EvalRunCancelParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the evaluation whose run you want to cancel.
        /// </summary>
        public string Eval_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run to cancel.
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
    public partial class EvalRunCancelResponse : EvalRunObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalRunCancelResponse> EvalRunCancelAsync(string eval_Id, string run_Id)
        {
            var p = new EvalRunCancelParameter();
            p.Eval_Id = eval_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunCancelParameter, EvalRunCancelResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunCancelResponse> EvalRunCancelAsync(string eval_Id, string run_Id, CancellationToken cancellationToken)
        {
            var p = new EvalRunCancelParameter();
            p.Eval_Id = eval_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunCancelParameter, EvalRunCancelResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalRunCancelResponse> EvalRunCancelAsync(EvalRunCancelParameter parameter)
        {
            return await this.SendJsonAsync<EvalRunCancelParameter, EvalRunCancelResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunCancelResponse> EvalRunCancelAsync(EvalRunCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalRunCancelParameter, EvalRunCancelResponse>(parameter, cancellationToken);
        }
    }
}
