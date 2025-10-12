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
    /// List your organization's batches.
    /// <seealso href="https://api.openai.com/v1/batches">https://api.openai.com/v1/batches</seealso>
    /// </summary>
    public partial class BatchesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly BatchesParameter Empty = new BatchesParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public BatchesQueryParameter QueryParameter { get; set; } = new BatchesQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/batches";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class BatchesQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }

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
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class BatchesResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<BatchesResponse> BatchesAsync()
        {
            return await this.SendJsonAsync<BatchesParameter, BatchesResponse>(BatchesParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<BatchesResponse> BatchesAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<BatchesParameter, BatchesResponse>(BatchesParameter.Empty, cancellationToken);
        }
        public async ValueTask<BatchesResponse> BatchesAsync(BatchesParameter parameter)
        {
            return await this.SendJsonAsync<BatchesParameter, BatchesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<BatchesResponse> BatchesAsync(BatchesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<BatchesParameter, BatchesResponse>(parameter, cancellationToken);
        }
    }
}
