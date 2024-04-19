using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of vector stores.
    /// <seealso href="https://api.openai.com/v1/vector_stores">https://api.openai.com/v1/vector_stores</seealso>
    /// </summary>
    public partial class VectorStoresParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly VectorStoresParameter Empty = new VectorStoresParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
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
            return $"/vector_stores";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class VectorStoresResponse : RestApiDataResponse<List<VectorStoreObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoresResponse> VectorStoresAsync()
        {
            return await this.SendJsonAsync<VectorStoresParameter, VectorStoresResponse>(VectorStoresParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<VectorStoresResponse> VectorStoresAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoresParameter, VectorStoresResponse>(VectorStoresParameter.Empty, cancellationToken);
        }
        public async ValueTask<VectorStoresResponse> VectorStoresAsync(VectorStoresParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoresParameter, VectorStoresResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<VectorStoresResponse> VectorStoresAsync(VectorStoresParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoresParameter, VectorStoresResponse>(parameter, cancellationToken);
        }
    }
}
