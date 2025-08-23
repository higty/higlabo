using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create Container
    /// <seealso href="https://api.openai.com/v1/containers">https://api.openai.com/v1/containers</seealso>
    /// </summary>
    public partial class ContainerCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// Name of the container to create.
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// Container expiration time in seconds relative to the 'anchor' time.
        /// </summary>
        public ExpirationPolicy? Expires_After { get; set; }
        /// <summary>
        /// IDs of files to copy to the container.
        /// </summary>
        public List<string>? File_Ids { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/containers";
        }
        public override object GetRequestBody()
        {
            return new {
            	name = this.Name,
            	expires_after = this.Expires_After,
            	file_ids = this.File_Ids,
            };
        }
    }
    public partial class ContainerCreateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainerCreateResponse> ContainerCreateAsync(string name)
        {
            var p = new ContainerCreateParameter();
            p.Name = name;
            return await this.SendJsonAsync<ContainerCreateParameter, ContainerCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerCreateResponse> ContainerCreateAsync(string name, CancellationToken cancellationToken)
        {
            var p = new ContainerCreateParameter();
            p.Name = name;
            return await this.SendJsonAsync<ContainerCreateParameter, ContainerCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ContainerCreateResponse> ContainerCreateAsync(ContainerCreateParameter parameter)
        {
            return await this.SendJsonAsync<ContainerCreateParameter, ContainerCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerCreateResponse> ContainerCreateAsync(ContainerCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ContainerCreateParameter, ContainerCreateResponse>(parameter, cancellationToken);
        }
    }
}
