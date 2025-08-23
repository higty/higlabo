using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieve Container File Content
    /// <seealso href="https://api.openai.com/v1/containers/{container_id}/files/{file_id}/content">https://api.openai.com/v1/containers/{container_id}/files/{file_id}/content</seealso>
    /// </summary>
    public partial class ContainerFileContentParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Container_Id { get; set; } = "";
        public string File_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/containers/{Container_Id}/files/{File_Id}/content";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ContainerFileContentResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainerFileContentResponse> ContainerFileContentAsync(string container_Id, string file_Id)
        {
            var p = new ContainerFileContentParameter();
            p.Container_Id = container_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<ContainerFileContentParameter, ContainerFileContentResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFileContentResponse> ContainerFileContentAsync(string container_Id, string file_Id, CancellationToken cancellationToken)
        {
            var p = new ContainerFileContentParameter();
            p.Container_Id = container_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<ContainerFileContentParameter, ContainerFileContentResponse>(p, cancellationToken);
        }
        public async ValueTask<ContainerFileContentResponse> ContainerFileContentAsync(ContainerFileContentParameter parameter)
        {
            return await this.SendJsonAsync<ContainerFileContentParameter, ContainerFileContentResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFileContentResponse> ContainerFileContentAsync(ContainerFileContentParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainerFileContentParameter, ContainerFileContentResponse>(parameter, cancellationToken);
        }
    }
}
