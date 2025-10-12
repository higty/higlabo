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
    /// Create a Container File
    /// You can send either a multipart/form-data request with the raw file content, or a JSON request with a file ID.
    /// <seealso href="https://api.openai.com/v1/containers/{container_id}/files">https://api.openai.com/v1/containers/{container_id}/files</seealso>
    /// </summary>
    public partial class ContainerFileCreateParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Container_Id { get; set; } = "";
        /// <summary>
        /// The File object (not file name) to be uploaded.
        /// </summary>
        public FileParameter File { get; private set; } = new FileParameter("file");
        /// <summary>
        /// Name of the file to create.
        /// </summary>
        public string? File_Id { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/containers/{Container_Id}/files";
        }
        public override object GetRequestBody()
        {
            return new {
            	file = this.File,
            	file_id = this.File_Id,
            };
        }
        IEnumerable<FileParameter> IFileParameter.GetFileParameters()
        {
            yield return this.File;
        }
        Dictionary<string, string> IFormDataParameter.CreateFormDataParameter()
        {
            var d = new Dictionary<string, string>();
            d["container_id"] = this.Container_Id;
            if (this.File_Id != null) d["file_id"] = this.File_Id;
            return d;
        }
    }
    public partial class ContainerFileCreateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ContainerFileCreateResponse> ContainerFileCreateAsync(string container_Id)
        {
            var p = new ContainerFileCreateParameter();
            p.Container_Id = container_Id;
            return await this.SendFormDataAsync<ContainerFileCreateParameter, ContainerFileCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFileCreateResponse> ContainerFileCreateAsync(string container_Id, CancellationToken cancellationToken)
        {
            var p = new ContainerFileCreateParameter();
            p.Container_Id = container_Id;
            return await this.SendFormDataAsync<ContainerFileCreateParameter, ContainerFileCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ContainerFileCreateResponse> ContainerFileCreateAsync(ContainerFileCreateParameter parameter)
        {
            return await this.SendFormDataAsync<ContainerFileCreateParameter, ContainerFileCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ContainerFileCreateResponse> ContainerFileCreateAsync(ContainerFileCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendFormDataAsync<ContainerFileCreateParameter, ContainerFileCreateResponse>(parameter, cancellationToken);
        }
    }
}
