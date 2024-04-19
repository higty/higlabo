using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create a vector store file batch.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/file_batches">https://api.openai.com/v1/vector_stores/{vector_store_id}/file_batches</seealso>
    /// </summary>
    public partial class VectorStoreFileBatchCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the vector store for which to create a File Batch.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";
        /// <summary>
        /// A list of File IDs that the vector store should use. Useful for tools like file_search that can access files.
        /// </summary>
        public List<string>? File_Ids { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/file_batches";
        }
        public override object GetRequestBody()
        {
            return new {
            	file_ids = this.File_Ids,
            };
        }
    }
    public partial class VectorStoreFileBatchCreateResponse : VectorStoreFileBatchObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFileBatchCreateResponse> VectorStoreFileBatchCreateAsync(string vector_Store_Id, List<string>? file_Ids)
        {
            var p = new VectorStoreFileBatchCreateParameter();
            p.Vector_Store_Id = vector_Store_Id;
            p.File_Ids = file_Ids;
            return await this.SendJsonAsync<VectorStoreFileBatchCreateParameter, VectorStoreFileBatchCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileBatchCreateResponse> VectorStoreFileBatchCreateAsync(string vector_Store_Id, List<string>? file_Ids, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFileBatchCreateParameter();
            p.Vector_Store_Id = vector_Store_Id;
            p.File_Ids = file_Ids;
            return await this.SendJsonAsync<VectorStoreFileBatchCreateParameter, VectorStoreFileBatchCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFileBatchCreateResponse> VectorStoreFileBatchCreateAsync(VectorStoreFileBatchCreateParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFileBatchCreateParameter, VectorStoreFileBatchCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileBatchCreateResponse> VectorStoreFileBatchCreateAsync(VectorStoreFileBatchCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileBatchCreateParameter, VectorStoreFileBatchCreateResponse>(parameter, cancellationToken);
        }
    }
}
