using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a vector store file batch.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/file_batches/{batch_id}">https://api.openai.com/v1/vector_stores/{vector_store_id}/file_batches/{batch_id}</seealso>
    /// </summary>
    public partial class VectorStoreFileBatchRetrieveParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the file batch being retrieved.
        /// </summary>
        public string Batch_Id { get; set; } = "";
        /// <summary>
        /// The ID of the vector store that the file batch belongs to.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/file_batches/{Batch_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class VectorStoreFileBatchRetrieveResponse : VectorStoreFileBatchObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFileBatchRetrieveResponse> VectorStoreFileBatchRetrieveAsync(string batch_Id, string vector_Store_Id)
        {
            var p = new VectorStoreFileBatchRetrieveParameter();
            p.Batch_Id = batch_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileBatchRetrieveParameter, VectorStoreFileBatchRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileBatchRetrieveResponse> VectorStoreFileBatchRetrieveAsync(string batch_Id, string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFileBatchRetrieveParameter();
            p.Batch_Id = batch_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileBatchRetrieveParameter, VectorStoreFileBatchRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFileBatchRetrieveResponse> VectorStoreFileBatchRetrieveAsync(VectorStoreFileBatchRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFileBatchRetrieveParameter, VectorStoreFileBatchRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileBatchRetrieveResponse> VectorStoreFileBatchRetrieveAsync(VectorStoreFileBatchRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileBatchRetrieveParameter, VectorStoreFileBatchRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
