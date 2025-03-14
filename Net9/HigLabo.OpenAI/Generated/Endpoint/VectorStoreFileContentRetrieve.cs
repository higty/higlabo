using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieve the parsed contents of a vector store file.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/files/{file_id}/content">https://api.openai.com/v1/vector_stores/{vector_store_id}/files/{file_id}/content</seealso>
    /// </summary>
    public partial class VectorStoreFileContentRetrieveParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the file within the vector store.
        /// </summary>
        public string File_Id { get; set; } = "";
        /// <summary>
        /// The ID of the vector store.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/files/{File_Id}/content";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class VectorStoreFileContentRetrieveResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFileContentRetrieveResponse> VectorStoreFileContentRetrieveAsync(string file_Id, string vector_Store_Id)
        {
            var p = new VectorStoreFileContentRetrieveParameter();
            p.File_Id = file_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileContentRetrieveParameter, VectorStoreFileContentRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileContentRetrieveResponse> VectorStoreFileContentRetrieveAsync(string file_Id, string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFileContentRetrieveParameter();
            p.File_Id = file_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileContentRetrieveParameter, VectorStoreFileContentRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFileContentRetrieveResponse> VectorStoreFileContentRetrieveAsync(VectorStoreFileContentRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFileContentRetrieveParameter, VectorStoreFileContentRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileContentRetrieveResponse> VectorStoreFileContentRetrieveAsync(VectorStoreFileContentRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileContentRetrieveParameter, VectorStoreFileContentRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
