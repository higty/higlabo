using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete an evaluation.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}">https://api.openai.com/v1/evals/{eval_id}</seealso>
    /// </summary>
    public partial class EvalDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the evaluation to delete.
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
    public partial class EvalDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalDeleteResponse> EvalDeleteAsync(string eval_Id)
        {
            var p = new EvalDeleteParameter();
            p.Eval_Id = eval_Id;
            return await this.SendJsonAsync<EvalDeleteParameter, EvalDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalDeleteResponse> EvalDeleteAsync(string eval_Id, CancellationToken cancellationToken)
        {
            var p = new EvalDeleteParameter();
            p.Eval_Id = eval_Id;
            return await this.SendJsonAsync<EvalDeleteParameter, EvalDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalDeleteResponse> EvalDeleteAsync(EvalDeleteParameter parameter)
        {
            return await this.SendJsonAsync<EvalDeleteParameter, EvalDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalDeleteResponse> EvalDeleteAsync(EvalDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalDeleteParameter, EvalDeleteResponse>(parameter, cancellationToken);
        }
    }
}
