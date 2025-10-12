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
    /// Delete Container
    /// <seealso href="https://api.openai.com/v1/containers/{container_id}">https://api.openai.com/v1/containers/{container_id}</seealso>
    /// </summary>
    public partial class ContainerDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the container to delete.
        /// </summary>
        public string Container_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/containers/{Container_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ContainerDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainerDeleteResponse> ContainerDeleteAsync(string container_Id)
        {
            var p = new ContainerDeleteParameter();
            p.Container_Id = container_Id;
            return await this.SendJsonAsync<ContainerDeleteParameter, ContainerDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerDeleteResponse> ContainerDeleteAsync(string container_Id, CancellationToken cancellationToken)
        {
            var p = new ContainerDeleteParameter();
            p.Container_Id = container_Id;
            return await this.SendJsonAsync<ContainerDeleteParameter, ContainerDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<ContainerDeleteResponse> ContainerDeleteAsync(ContainerDeleteParameter parameter)
        {
            return await this.SendJsonAsync<ContainerDeleteParameter, ContainerDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerDeleteResponse> ContainerDeleteAsync(ContainerDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainerDeleteParameter, ContainerDeleteResponse>(parameter, cancellationToken);
        }
    }
}
