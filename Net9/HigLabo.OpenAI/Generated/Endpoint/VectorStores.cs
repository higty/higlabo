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
    /// Returns a list of vector stores.
    /// <seealso href="https://api.openai.com/v1/vector_stores">https://api.openai.com/v1/vector_stores</seealso>
    /// </summary>
    public partial class VectorStoresParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter, IQueryParameterProperty
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
        public VectorStoresQueryParameter QueryParameter { get; set; } = new VectorStoresQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class VectorStoresQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list.
        /// </summary>
        public string? Before { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order.
        /// </summary>
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Before != null)
            {
                sb.Append($"before={WebUtility.UrlEncode(this.Before)}&");
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class VectorStoresResponse : RestApiDataResponse<List<VectorStoreObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoresResponse> VectorStoresAsync()
        {
            return await this.SendJsonAsync<VectorStoresParameter, VectorStoresResponse>(VectorStoresParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoresResponse> VectorStoresAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoresParameter, VectorStoresResponse>(VectorStoresParameter.Empty, cancellationToken);
        }
        public async ValueTask<VectorStoresResponse> VectorStoresAsync(VectorStoresParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoresParameter, VectorStoresResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoresResponse> VectorStoresAsync(VectorStoresParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoresParameter, VectorStoresResponse>(parameter, cancellationToken);
        }
    }
}
