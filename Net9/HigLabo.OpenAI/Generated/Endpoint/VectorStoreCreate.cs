using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create a vector store.
    /// <seealso href="https://api.openai.com/v1/vector_stores">https://api.openai.com/v1/vector_stores</seealso>
    /// </summary>
    public partial class VectorStoreCreateParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The chunking strategy used to chunk the file(s). If not set, will use the auto strategy. Only applicable if file_ids is non-empty.
        /// </summary>
        public ChunkingStrategy? Chunking_Strategy { get; set; }
        /// <summary>
        /// The expiration policy for a vector store.
        /// </summary>
        public object? Expires_After { get; set; }
        /// <summary>
        /// A list of File IDs that the vector store should use. Useful for tools like file_search that can access files.
        /// </summary>
        public List<string>? File_Ids { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// The name of the vector store.
        /// </summary>
        public string? Name { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores";
        }
        public override object GetRequestBody()
        {
            return new {
            	chunking_strategy = this.Chunking_Strategy,
            	expires_after = this.Expires_After,
            	file_ids = this.File_Ids,
            	metadata = this.Metadata,
            	name = this.Name,
            };
        }
    }
    public partial class VectorStoreCreateResponse : VectorStoreObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreCreateResponse> VectorStoreCreateAsync()
        {
            var p = new VectorStoreCreateParameter();
            return await this.SendJsonAsync<VectorStoreCreateParameter, VectorStoreCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreCreateResponse> VectorStoreCreateAsync(CancellationToken cancellationToken)
        {
            var p = new VectorStoreCreateParameter();
            return await this.SendJsonAsync<VectorStoreCreateParameter, VectorStoreCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreCreateResponse> VectorStoreCreateAsync(VectorStoreCreateParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreCreateParameter, VectorStoreCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreCreateResponse> VectorStoreCreateAsync(VectorStoreCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreCreateParameter, VectorStoreCreateResponse>(parameter, cancellationToken);
        }
    }
}
