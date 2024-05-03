using System.Collections.Generic;
using System.IO;
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

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/files";
        }
        public override object GetRequestBody()
        {
            return new {
            	file_id = this.File_Id,
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
            return await this.SendJsonAsync<VectorStoreFileCreateParameter, VectorStoreFileCreateResponse>(p, CancellationToken.None);
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
            return await this.SendJsonAsync<VectorStoreFileCreateParameter, VectorStoreFileCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<VectorStoreFileCreateResponse> VectorStoreFileCreateAsync(VectorStoreFileCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFileCreateParameter, VectorStoreFileCreateResponse>(parameter, cancellationToken);
        }
    }
}
