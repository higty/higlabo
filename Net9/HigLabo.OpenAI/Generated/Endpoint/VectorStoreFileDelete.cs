using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete a vector store file. This will remove the file from the vector store but the file itself will not be deleted. To delete the file, use the delete file endpoint.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/files/{file_id}">https://api.openai.com/v1/vector_stores/{vector_store_id}/files/{file_id}</seealso>
    /// </summary>
    public partial class VectorStoreFileDeleteParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the file to delete.
        /// </summary>
        public string File_Id { get; set; } = "";
        /// <summary>
        /// The ID of the vector store that the file belongs to.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/files/{File_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class VectorStoreFileDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFileDeleteResponse> VectorStoreFileDeleteAsync(string file_Id, string vector_Store_Id)
        {
            var p = new VectorStoreFileDeleteParameter();
            p.File_Id = file_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileDeleteParameter, VectorStoreFileDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileDeleteResponse> VectorStoreFileDeleteAsync(string file_Id, string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFileDeleteParameter();
            p.File_Id = file_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileDeleteParameter, VectorStoreFileDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFileDeleteResponse> VectorStoreFileDeleteAsync(VectorStoreFileDeleteParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFileDeleteParameter, VectorStoreFileDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileDeleteResponse> VectorStoreFileDeleteAsync(VectorStoreFileDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileDeleteParameter, VectorStoreFileDeleteResponse>(parameter, cancellationToken);
        }
    }
}
