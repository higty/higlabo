using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Modifies a vector store.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}">https://api.openai.com/v1/vector_stores/{vector_store_id}</seealso>
    /// </summary>
    public partial class VectorStoreModifyParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the vector store to modify.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";
        /// <summary>
        /// The name of the vector store.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// The expiration policy for a vector store.
        /// </summary>
        public object? Expires_After { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maximum of 512 characters long.
        /// </summary>
        public object? Metadata { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	name = this.Name,
            	expires_after = this.Expires_After,
            	metadata = this.Metadata,
            };
        }
    }
    public partial class VectorStoreModifyResponse : VectorStoreObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreModifyResponse> VectorStoreModifyAsync(string vector_Store_Id)
        {
            var p = new VectorStoreModifyParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreModifyParameter, VectorStoreModifyResponse>(p, CancellationToken.None);
        }
        public async ValueTask<VectorStoreModifyResponse> VectorStoreModifyAsync(string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreModifyParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreModifyParameter, VectorStoreModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreModifyResponse> VectorStoreModifyAsync(VectorStoreModifyParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreModifyParameter, VectorStoreModifyResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<VectorStoreModifyResponse> VectorStoreModifyAsync(VectorStoreModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreModifyParameter, VectorStoreModifyResponse>(parameter, cancellationToken);
        }
    }
}
