using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of vector store files in a batch.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/file_batches/{batch_id}/files">https://api.openai.com/v1/vector_stores/{vector_store_id}/file_batches/{batch_id}/files</seealso>
    /// </summary>
    public partial class VectorStoreFileBatchesParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the file batch that the files belong to.
        /// </summary>
        public string Batch_Id { get; set; } = "";
        /// <summary>
        /// The ID of the vector store that the files belong to.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";
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
            return $"/vector_stores/{Vector_Store_Id}/file_batches/{Batch_Id}/files";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class VectorStoreFileBatchesResponse : RestApiDataResponse<List<VectorStoreFileBatchObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFileBatchesResponse> VectorStoreFileBatchesAsync(string batch_Id, string vector_Store_Id)
        {
            var p = new VectorStoreFileBatchesParameter();
            p.Batch_Id = batch_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileBatchesParameter, VectorStoreFileBatchesResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileBatchesResponse> VectorStoreFileBatchesAsync(string batch_Id, string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFileBatchesParameter();
            p.Batch_Id = batch_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileBatchesParameter, VectorStoreFileBatchesResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFileBatchesResponse> VectorStoreFileBatchesAsync(VectorStoreFileBatchesParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFileBatchesParameter, VectorStoreFileBatchesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileBatchesResponse> VectorStoreFileBatchesAsync(VectorStoreFileBatchesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileBatchesParameter, VectorStoreFileBatchesResponse>(parameter, cancellationToken);
        }
    }
}
