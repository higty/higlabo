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
        public EvalRunOutputItemsQueryParameter QueryParameter { get; set; } = new EvalRunOutputItemsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/evals/{Eval_Id}/runs/{Run_Id}/output_items";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class EvalRunOutputItemsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Identifier for the last output item from the previous pagination request.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Number of output items to retrieve.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order for output items by timestamp. Use asc for ascending order or desc for descending order. Defaults to asc.
        /// </summary>
        public string? Order { get; set; }
        /// <summary>
        /// Filter output items by status. Use failed to filter by failed output items or pass to filter by passed output items.
        /// </summary>
        public string? Status { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            if (this.Status != null)
            {
                sb.Append($"status={WebUtility.UrlEncode(this.Status)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class EvalRunOutputItemsResponse : RestApiDataResponse<List<EvalRunOutputItemObject>>
    {
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
