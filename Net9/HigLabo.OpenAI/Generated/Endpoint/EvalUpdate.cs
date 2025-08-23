using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Update certain properties of an evaluation.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}">https://api.openai.com/v1/evals/{eval_id}</seealso>
    /// </summary>
    public partial class EvalUpdateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the evaluation to update.
        /// </summary>
        public string Eval_Id { get; set; } = "";
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// Rename the evaluation.
        /// </summary>
        public string? Name { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/evals/{Eval_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	metadata = this.Metadata,
            	name = this.Name,
            };
        }
    }
    public partial class EvalUpdateResponse : EvalObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalUpdateResponse> EvalUpdateAsync(string eval_Id)
        {
            var p = new EvalUpdateParameter();
            p.Eval_Id = eval_Id;
            return await this.SendJsonAsync<EvalUpdateParameter, EvalUpdateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalUpdateResponse> EvalUpdateAsync(string eval_Id, CancellationToken cancellationToken)
        {
            var p = new EvalUpdateParameter();
            p.Eval_Id = eval_Id;
            return await this.SendJsonAsync<EvalUpdateParameter, EvalUpdateResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalUpdateResponse> EvalUpdateAsync(EvalUpdateParameter parameter)
        {
            return await this.SendJsonAsync<EvalUpdateParameter, EvalUpdateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalUpdateResponse> EvalUpdateAsync(EvalUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalUpdateParameter, EvalUpdateResponse>(parameter, cancellationToken);
        }
    }
}
