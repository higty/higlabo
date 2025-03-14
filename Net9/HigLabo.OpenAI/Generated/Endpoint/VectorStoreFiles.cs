using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of vector store files.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/files">https://api.openai.com/v1/vector_stores/{vector_store_id}/files</seealso>
    /// </summary>
    public partial class VectorStoreFilesParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the vector store that the files belong to.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/files";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class VectorStoreFilesResponse : RestApiDataResponse<List<VectorStoreFileObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFilesResponse> VectorStoreFilesAsync(string vector_Store_Id)
        {
            var p = new VectorStoreFilesParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFilesParameter, VectorStoreFilesResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFilesResponse> VectorStoreFilesAsync(string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFilesParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFilesParameter, VectorStoreFilesResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFilesResponse> VectorStoreFilesAsync(VectorStoreFilesParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFilesParameter, VectorStoreFilesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFilesResponse> VectorStoreFilesAsync(VectorStoreFilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFilesParameter, VectorStoreFilesResponse>(parameter, cancellationToken);
        }
    }
}
