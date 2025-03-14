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
    public partial class Vector_storesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly Vector_storesParameter Empty = new Vector_storesParameter();

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
    public partial class Vector_storesResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<Vector_storesResponse> Vector_storesAsync()
        {
            return await this.SendJsonAsync<Vector_storesParameter, Vector_storesResponse>(Vector_storesParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<Vector_storesResponse> Vector_storesAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<Vector_storesParameter, Vector_storesResponse>(Vector_storesParameter.Empty, cancellationToken);
        }
        public async ValueTask<Vector_storesResponse> Vector_storesAsync(Vector_storesParameter parameter)
        {
            return await this.SendJsonAsync<Vector_storesParameter, Vector_storesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<Vector_storesResponse> Vector_storesAsync(Vector_storesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<Vector_storesParameter, Vector_storesResponse>(parameter, cancellationToken);
        }
    }
}
