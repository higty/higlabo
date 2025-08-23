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
    public partial class VectorStoreFileBatchCreateParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
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
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard. Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters, booleans, or numbers.
        /// </summary>
        public object? Attributes { get; set; }
        /// <summary>
        /// The chunking strategy used to chunk the file(s). If not set, will use the auto strategy.
        /// </summary>
        public object? Chunking_Strategy { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/file_batches";
        }
        public override object GetRequestBody()
        {
            return new {
            	file_ids = this.File_Ids,
            	attributes = this.Attributes,
            	chunking_strategy = this.Chunking_Strategy,
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
            return await this.SendJsonAsync<VectorStoreFileBatchCreateParameter, VectorStoreFileBatchCreateResponse>(p, System.Threading.CancellationToken.None);
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
            return await this.SendJsonAsync<VectorStoreFileBatchCreateParameter, VectorStoreFileBatchCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileBatchCreateResponse> VectorStoreFileBatchCreateAsync(VectorStoreFileBatchCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileBatchCreateParameter, VectorStoreFileBatchCreateResponse>(parameter, cancellationToken);
        }
    }
}
