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
    /// List evaluations for a project.
    /// <seealso href="https://api.openai.com/v1/evals">https://api.openai.com/v1/evals</seealso>
    /// </summary>
    public partial class EvalsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly EvalsParameter Empty = new EvalsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public EvalsQueryParameter QueryParameter { get; set; } = new EvalsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/evals";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class EvalsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Identifier for the last eval from the previous pagination request.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Number of evals to retrieve.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order for evals by timestamp. Use asc for ascending order or desc for descending order.
        /// </summary>
        public string? Order { get; set; }
        /// <summary>
        /// Evals can be ordered by creation time or last updated time. Use created_at for creation time or updated_at for last updated time.
        /// </summary>
        public string? Order_By { get; set; }

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
            if (this.Order_By != null)
            {
                sb.Append($"order_by={WebUtility.UrlEncode(this.Order_By)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class EvalsResponse : RestApiDataResponse<List<EvalObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalsResponse> EvalsAsync()
        {
            return await this.SendJsonAsync<EvalsParameter, EvalsResponse>(EvalsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalsResponse> EvalsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalsParameter, EvalsResponse>(EvalsParameter.Empty, cancellationToken);
        }
        public async ValueTask<EvalsResponse> EvalsAsync(EvalsParameter parameter)
        {
            return await this.SendJsonAsync<EvalsParameter, EvalsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalsResponse> EvalsAsync(EvalsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalsParameter, EvalsResponse>(parameter, cancellationToken);
        }
    }
}
