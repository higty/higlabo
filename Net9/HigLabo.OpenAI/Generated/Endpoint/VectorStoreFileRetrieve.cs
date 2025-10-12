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
    /// Retrieves a vector store file.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/files/{file_id}">https://api.openai.com/v1/vector_stores/{vector_store_id}/files/{file_id}</seealso>
    /// </summary>
    public partial class VectorStoreFileRetrieveParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the file being retrieved.
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
    public partial class VectorStoreFileRetrieveResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFileRetrieveResponse> VectorStoreFileRetrieveAsync(string file_Id, string vector_Store_Id)
        {
            var p = new VectorStoreFileRetrieveParameter();
            p.File_Id = file_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileRetrieveParameter, VectorStoreFileRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileRetrieveResponse> VectorStoreFileRetrieveAsync(string file_Id, string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFileRetrieveParameter();
            p.File_Id = file_Id;
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFileRetrieveParameter, VectorStoreFileRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFileRetrieveResponse> VectorStoreFileRetrieveAsync(VectorStoreFileRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFileRetrieveParameter, VectorStoreFileRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileRetrieveResponse> VectorStoreFileRetrieveAsync(VectorStoreFileRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileRetrieveParameter, VectorStoreFileRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
