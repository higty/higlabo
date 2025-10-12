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
    /// List Container files
    /// <seealso href="https://api.openai.com/v1/containers/{container_id}/files">https://api.openai.com/v1/containers/{container_id}/files</seealso>
    /// </summary>
    public partial class ContainerFilesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Container_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public ContainerFilesQueryParameter QueryParameter { get; set; } = new ContainerFilesQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/containers/{Container_Id}/files";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ContainerFilesQueryParameter : IQueryParameter
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
    public partial class ContainerFilesResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainerFilesResponse> ContainerFilesAsync(string container_Id)
        {
            var p = new ContainerFilesParameter();
            p.Container_Id = container_Id;
            return await this.SendJsonAsync<ContainerFilesParameter, ContainerFilesResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFilesResponse> ContainerFilesAsync(string container_Id, CancellationToken cancellationToken)
        {
            var p = new ContainerFilesParameter();
            p.Container_Id = container_Id;
            return await this.SendJsonAsync<ContainerFilesParameter, ContainerFilesResponse>(p, cancellationToken);
        }
        public async ValueTask<ContainerFilesResponse> ContainerFilesAsync(ContainerFilesParameter parameter)
        {
            return await this.SendJsonAsync<ContainerFilesParameter, ContainerFilesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFilesResponse> ContainerFilesAsync(ContainerFilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainerFilesParameter, ContainerFilesResponse>(parameter, cancellationToken);
        }
    }
}
