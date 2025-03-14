using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Update attributes on a vector store file.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/files/{file_id}">https://api.openai.com/v1/vector_stores/{vector_store_id}/files/{file_id}</seealso>
    /// </summary>
    public partial class VectorStoreFileAttributeUpdateParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the file to update attributes.
        /// </summary>
        public string File_Id { get; set; } = "";
        /// <summary>
        /// The ID of the vector store the file belongs to.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard. Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters, booleans, or numbers.
        /// </summary>
        public object? Attributes { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/files/{File_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	attributes = this.Attributes,
            };
        }
    }
    public partial class VectorStoreFileAttributeUpdateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFileAttributeUpdateResponse> VectorStoreFileAttributeUpdateAsync(string file_Id, string vector_Store_Id, object? attributes)
        {
            var p = new VectorStoreFileAttributeUpdateParameter();
            p.File_Id = file_Id;
            p.Vector_Store_Id = vector_Store_Id;
            p.Attributes = attributes;
            return await this.SendJsonAsync<VectorStoreFileAttributeUpdateParameter, VectorStoreFileAttributeUpdateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileAttributeUpdateResponse> VectorStoreFileAttributeUpdateAsync(string file_Id, string vector_Store_Id, object? attributes, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFileAttributeUpdateParameter();
            p.File_Id = file_Id;
            p.Vector_Store_Id = vector_Store_Id;
            p.Attributes = attributes;
            return await this.SendJsonAsync<VectorStoreFileAttributeUpdateParameter, VectorStoreFileAttributeUpdateResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFileAttributeUpdateResponse> VectorStoreFileAttributeUpdateAsync(VectorStoreFileAttributeUpdateParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFileAttributeUpdateParameter, VectorStoreFileAttributeUpdateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileAttributeUpdateResponse> VectorStoreFileAttributeUpdateAsync(VectorStoreFileAttributeUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileAttributeUpdateParameter, VectorStoreFileAttributeUpdateResponse>(parameter, cancellationToken);
        }
    }
}
