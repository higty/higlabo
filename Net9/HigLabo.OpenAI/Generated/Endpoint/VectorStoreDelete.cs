using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete a vector store.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}">https://api.openai.com/v1/vector_stores/{vector_store_id}</seealso>
    /// </summary>
    public partial class VectorStoreDeleteParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the vector store to delete.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class VectorStoreDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreDeleteResponse> VectorStoreDeleteAsync(string vector_Store_Id)
        {
            var p = new VectorStoreDeleteParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreDeleteParameter, VectorStoreDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreDeleteResponse> VectorStoreDeleteAsync(string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreDeleteParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreDeleteParameter, VectorStoreDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreDeleteResponse> VectorStoreDeleteAsync(VectorStoreDeleteParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreDeleteParameter, VectorStoreDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreDeleteResponse> VectorStoreDeleteAsync(VectorStoreDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreDeleteParameter, VectorStoreDeleteResponse>(parameter, cancellationToken);
        }
    }
}
