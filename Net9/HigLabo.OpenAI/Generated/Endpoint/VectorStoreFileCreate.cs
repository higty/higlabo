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
    /// Create a vector store file by attaching a File to a vector store.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/files">https://api.openai.com/v1/vector_stores/{vector_store_id}/files</seealso>
    /// </summary>
    public partial class VectorStoreFileCreateParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the vector store for which to create a File.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";
        /// <summary>
        /// A File ID that the vector store should use. Useful for tools like file_search that can access files.
        /// </summary>
        public string File_Id { get; set; } = "";
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
            return $"/vector_stores/{Vector_Store_Id}/files";
        }
        public override object GetRequestBody()
        {
            return new {
            	file_id = this.File_Id,
            	attributes = this.Attributes,
            	chunking_strategy = this.Chunking_Strategy,
            };
        }
    }
    public partial class VectorStoreFileCreateResponse : VectorStoreFileObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFileCreateResponse> VectorStoreFileCreateAsync(string vector_Store_Id, string file_Id)
        {
            var p = new VectorStoreFileCreateParameter();
            p.Vector_Store_Id = vector_Store_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<VectorStoreFileCreateParameter, VectorStoreFileCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileCreateResponse> VectorStoreFileCreateAsync(string vector_Store_Id, string file_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFileCreateParameter();
            p.Vector_Store_Id = vector_Store_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<VectorStoreFileCreateParameter, VectorStoreFileCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFileCreateResponse> VectorStoreFileCreateAsync(VectorStoreFileCreateParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFileCreateParameter, VectorStoreFileCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileCreateResponse> VectorStoreFileCreateAsync(VectorStoreFileCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileCreateParameter, VectorStoreFileCreateResponse>(parameter, cancellationToken);
        }
    }
}
