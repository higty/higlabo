using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get an evaluation by ID.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}">https://api.openai.com/v1/evals/{eval_id}</seealso>
    /// </summary>
    public partial class EvalParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the evaluation to retrieve.
        /// </summary>
        public string Eval_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/evals/{Eval_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class EvalResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalResponse> EvalAsync(string eval_Id)
        {
            var p = new EvalParameter();
            p.Eval_Id = eval_Id;
            return await this.SendJsonAsync<EvalParameter, EvalResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalResponse> EvalAsync(string eval_Id, CancellationToken cancellationToken)
        {
            var p = new EvalParameter();
            p.Eval_Id = eval_Id;
            return await this.SendJsonAsync<EvalParameter, EvalResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalResponse> EvalAsync(EvalParameter parameter)
        {
            return await this.SendJsonAsync<EvalParameter, EvalResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalResponse> EvalAsync(EvalParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalParameter, EvalResponse>(parameter, cancellationToken);
        }
    }
}
