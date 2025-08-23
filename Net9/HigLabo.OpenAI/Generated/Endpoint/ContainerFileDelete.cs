using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete Container File
    /// <seealso href="https://api.openai.com/v1/containers/{container_id}/files/{file_id}">https://api.openai.com/v1/containers/{container_id}/files/{file_id}</seealso>
    /// </summary>
    public partial class ContainerFileDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
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
    public partial class ContainerFileDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainerFileDeleteResponse> ContainerFileDeleteAsync(string container_Id, string file_Id)
        {
            var p = new ContainerFileDeleteParameter();
            p.Container_Id = container_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<ContainerFileDeleteParameter, ContainerFileDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFileDeleteResponse> ContainerFileDeleteAsync(string container_Id, string file_Id, CancellationToken cancellationToken)
        {
            var p = new ContainerFileDeleteParameter();
            p.Container_Id = container_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<ContainerFileDeleteParameter, ContainerFileDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<ContainerFileDeleteResponse> ContainerFileDeleteAsync(ContainerFileDeleteParameter parameter)
        {
            return await this.SendJsonAsync<ContainerFileDeleteParameter, ContainerFileDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFileDeleteResponse> ContainerFileDeleteAsync(ContainerFileDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainerFileDeleteParameter, ContainerFileDeleteResponse>(parameter, cancellationToken);
        }
    }
}
