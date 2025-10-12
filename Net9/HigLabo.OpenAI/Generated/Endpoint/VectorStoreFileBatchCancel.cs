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
    /// Cancel a vector store file batch. This attempts to cancel the processing of files in this batch as soon as possible.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/file_batches/{batch_id}/cancel">https://api.openai.com/v1/vector_stores/{vector_store_id}/file_batches/{batch_id}/cancel</seealso>
    /// </summary>
    public partial class VectorStoreFileBatchCancelParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the file batch to cancel.
        /// </summary>
        public string Batch_Id { get; set; } = "";
        /// <summary>
        /// The ID of the vector store that the file batch belongs to.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/file_batches/{Batch_Id}/cancel";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class VectorStoreFileBatchCancelResponse : VectorStoreFileBatchObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFileBatchCancelResponse> VectorStoreFileBatchCancelAsync(string batch_Id, string vector_Store_Id)
        {
            var p = new VectorStoreFileBatchCancelParameter();
            p.Batch_Id = batch_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileBatchCancelParameter, VectorStoreFileBatchCancelResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileBatchCancelResponse> VectorStoreFileBatchCancelAsync(string batch_Id, string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFileBatchCancelParameter();
            p.Batch_Id = batch_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileBatchCancelParameter, VectorStoreFileBatchCancelResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFileBatchCancelResponse> VectorStoreFileBatchCancelAsync(VectorStoreFileBatchCancelParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFileBatchCancelParameter, VectorStoreFileBatchCancelResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileBatchCancelResponse> VectorStoreFileBatchCancelAsync(VectorStoreFileBatchCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileBatchCancelParameter, VectorStoreFileBatchCancelResponse>(parameter, cancellationToken);
        }
    }
}
