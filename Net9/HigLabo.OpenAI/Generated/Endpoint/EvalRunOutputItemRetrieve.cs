using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get an evaluation run output item by ID.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}/output_items/{output_item_id}">https://api.openai.com/v1/evals/{eval_id}/runs/{run_id}/output_items/{output_item_id}</seealso>
    /// </summary>
    public partial class EvalRunOutputItemRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the evaluation to retrieve runs for.
        /// </summary>
        public string Eval_Id { get; set; } = "";
        /// <summary>
        /// The ID of the output item to retrieve.
        /// </summary>
        public string Output_Item_Id { get; set; } = "";
        /// <summary>
        /// The ID of the run to retrieve.
        /// </summary>
        public string Run_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/evals/{Eval_Id}/runs/{Run_Id}/output_items/{Output_Item_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class EvalRunOutputItemRetrieveResponse : EvalRunOutputItemObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalRunOutputItemRetrieveResponse> EvalRunOutputItemRetrieveAsync(string eval_Id, string output_Item_Id, string run_Id)
        {
            var p = new EvalRunOutputItemRetrieveParameter();
            p.Eval_Id = eval_Id;
            p.Output_Item_Id = output_Item_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunOutputItemRetrieveParameter, EvalRunOutputItemRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunOutputItemRetrieveResponse> EvalRunOutputItemRetrieveAsync(string eval_Id, string output_Item_Id, string run_Id, CancellationToken cancellationToken)
        {
            var p = new EvalRunOutputItemRetrieveParameter();
            p.Eval_Id = eval_Id;
            p.Output_Item_Id = output_Item_Id;
            p.Run_Id = run_Id;
            return await this.SendJsonAsync<EvalRunOutputItemRetrieveParameter, EvalRunOutputItemRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalRunOutputItemRetrieveResponse> EvalRunOutputItemRetrieveAsync(EvalRunOutputItemRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<EvalRunOutputItemRetrieveParameter, EvalRunOutputItemRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunOutputItemRetrieveResponse> EvalRunOutputItemRetrieveAsync(EvalRunOutputItemRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalRunOutputItemRetrieveParameter, EvalRunOutputItemRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
