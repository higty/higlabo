using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieve Container File
    /// <seealso href="https://api.openai.com/v1/containers/{container_id}/files/{file_id}">https://api.openai.com/v1/containers/{container_id}/files/{file_id}</seealso>
    /// </summary>
    public partial class ContainerFileRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Container_Id { get; set; } = "";
        public string File_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/containers/{Container_Id}/files/{File_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ContainerFileRetrieveResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainerFileRetrieveResponse> ContainerFileRetrieveAsync(string container_Id, string file_Id)
        {
            var p = new ContainerFileRetrieveParameter();
            p.Container_Id = container_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<ContainerFileRetrieveParameter, ContainerFileRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFileRetrieveResponse> ContainerFileRetrieveAsync(string container_Id, string file_Id, CancellationToken cancellationToken)
        {
            var p = new ContainerFileRetrieveParameter();
            p.Container_Id = container_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<ContainerFileRetrieveParameter, ContainerFileRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ContainerFileRetrieveResponse> ContainerFileRetrieveAsync(ContainerFileRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ContainerFileRetrieveParameter, ContainerFileRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFileRetrieveResponse> ContainerFileRetrieveAsync(ContainerFileRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainerFileRetrieveParameter, ContainerFileRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
