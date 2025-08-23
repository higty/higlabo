using System.Collections.Generic;
using System.IO;
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
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/containers/{Container_Id}/files";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ContainerFilesResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
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
