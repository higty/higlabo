using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieve Container
    /// <seealso href="https://api.openai.com/v1/containers/{container_id}">https://api.openai.com/v1/containers/{container_id}</seealso>
    /// </summary>
    public partial class ContainerRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
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
    public partial class ContainerRetrieveResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainerRetrieveResponse> ContainerRetrieveAsync(string container_Id)
        {
            var p = new ContainerRetrieveParameter();
            p.Container_Id = container_Id;
            return await this.SendJsonAsync<ContainerRetrieveParameter, ContainerRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerRetrieveResponse> ContainerRetrieveAsync(string container_Id, CancellationToken cancellationToken)
        {
            var p = new ContainerRetrieveParameter();
            p.Container_Id = container_Id;
            return await this.SendJsonAsync<ContainerRetrieveParameter, ContainerRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ContainerRetrieveResponse> ContainerRetrieveAsync(ContainerRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ContainerRetrieveParameter, ContainerRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerRetrieveResponse> ContainerRetrieveAsync(ContainerRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainerRetrieveParameter, ContainerRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
