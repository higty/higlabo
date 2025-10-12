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
        public EvalRunsQueryParameter QueryParameter { get; set; } = new EvalRunsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/evals/{Eval_Id}/runs";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class EvalRunsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Identifier for the last run from the previous pagination request.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Number of runs to retrieve.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order for runs by timestamp. Use asc for ascending order or desc for descending order. Defaults to asc.
        /// </summary>
        public string? Order { get; set; }
        /// <summary>
        /// Filter runs by status. One of queued | in_progress | failed | completed | canceled.
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
    public partial class EvalRunsResponse : RestApiDataResponse<List<EvalRunObject>>
    {
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
