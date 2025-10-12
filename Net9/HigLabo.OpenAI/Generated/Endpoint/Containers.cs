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
    /// List Containers
    /// <seealso href="https://api.openai.com/v1/containers">https://api.openai.com/v1/containers</seealso>
    /// </summary>
    public partial class ContainersParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly ContainersParameter Empty = new ContainersParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public ContainersQueryParameter QueryParameter { get; set; } = new ContainersQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/containers";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ContainersQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
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
    public partial class ContainersResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainersResponse> ContainersAsync()
        {
            return await this.SendJsonAsync<ContainersParameter, ContainersResponse>(ContainersParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainersResponse> ContainersAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainersParameter, ContainersResponse>(ContainersParameter.Empty, cancellationToken);
        }
        public async ValueTask<ContainersResponse> ContainersAsync(ContainersParameter parameter)
        {
            return await this.SendJsonAsync<ContainersParameter, ContainersResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainersResponse> ContainersAsync(ContainersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainersParameter, ContainersResponse>(parameter, cancellationToken);
        }
    }
}
