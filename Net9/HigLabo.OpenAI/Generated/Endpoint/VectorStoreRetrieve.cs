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
    /// Retrieves a vector store.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}">https://api.openai.com/v1/vector_stores/{vector_store_id}</seealso>
    /// </summary>
    public partial class VectorStoreRetrieveParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the vector store to retrieve.
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
    public partial class VectorStoreRetrieveResponse : VectorStoreObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreRetrieveResponse> VectorStoreRetrieveAsync(string vector_Store_Id)
        {
            var p = new VectorStoreRetrieveParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreRetrieveParameter, VectorStoreRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreRetrieveResponse> VectorStoreRetrieveAsync(string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreRetrieveParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreRetrieveParameter, VectorStoreRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreRetrieveResponse> VectorStoreRetrieveAsync(VectorStoreRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreRetrieveParameter, VectorStoreRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreRetrieveResponse> VectorStoreRetrieveAsync(VectorStoreRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreRetrieveParameter, VectorStoreRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
