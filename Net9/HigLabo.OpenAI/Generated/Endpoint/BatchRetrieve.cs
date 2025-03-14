using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a batch.
    /// <seealso href="https://api.openai.com/v1/batches/{batch_id}">https://api.openai.com/v1/batches/{batch_id}</seealso>
    /// </summary>
    public partial class BatchRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the batch to retrieve.
        /// </summary>
        public string Batch_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/batches/{Batch_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class BatchRetrieveResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<BatchRetrieveResponse> BatchRetrieveAsync(string batch_Id)
        {
            var p = new BatchRetrieveParameter();
            p.Batch_Id = batch_Id;
            return await this.SendJsonAsync<BatchRetrieveParameter, BatchRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<BatchRetrieveResponse> BatchRetrieveAsync(string batch_Id, CancellationToken cancellationToken)
        {
            var p = new BatchRetrieveParameter();
            p.Batch_Id = batch_Id;
            return await this.SendJsonAsync<BatchRetrieveParameter, BatchRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<BatchRetrieveResponse> BatchRetrieveAsync(BatchRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<BatchRetrieveParameter, BatchRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<BatchRetrieveResponse> BatchRetrieveAsync(BatchRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<BatchRetrieveParameter, BatchRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
