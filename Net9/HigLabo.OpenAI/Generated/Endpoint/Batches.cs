using System.Collections.Generic;
using System.IO;
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
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/batches";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class BatchesResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
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
