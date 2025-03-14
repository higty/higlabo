using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Cancels an in-progress batch. The batch will be in status cancelling for up to 10 minutes, before changing to cancelled, where it will have partial results (if any) available in the output file.
    /// <seealso href="https://api.openai.com/v1/batches/{batch_id}/cancel">https://api.openai.com/v1/batches/{batch_id}/cancel</seealso>
    /// </summary>
    public partial class BatchCancelParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the batch to cancel.
        /// </summary>
        public string Batch_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/batches/{Batch_Id}/cancel";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class BatchCancelResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<BatchCancelResponse> BatchCancelAsync(string batch_Id)
        {
            var p = new BatchCancelParameter();
            p.Batch_Id = batch_Id;
            return await this.SendJsonAsync<BatchCancelParameter, BatchCancelResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<BatchCancelResponse> BatchCancelAsync(string batch_Id, CancellationToken cancellationToken)
        {
            var p = new BatchCancelParameter();
            p.Batch_Id = batch_Id;
            return await this.SendJsonAsync<BatchCancelParameter, BatchCancelResponse>(p, cancellationToken);
        }
        public async ValueTask<BatchCancelResponse> BatchCancelAsync(BatchCancelParameter parameter)
        {
            return await this.SendJsonAsync<BatchCancelParameter, BatchCancelResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<BatchCancelResponse> BatchCancelAsync(BatchCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<BatchCancelParameter, BatchCancelResponse>(parameter, cancellationToken);
        }
    }
}
