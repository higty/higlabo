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
    /// Upload a ChatKit file
    /// <seealso href="https://api.openai.com/v1/chatkit/files">https://api.openai.com/v1/chatkit/files</seealso>
    /// </summary>
    public partial class ChatKitFileUploadParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// Binary file contents to store with the ChatKit session. Supports PDFs and PNG, JPG, JPEG, GIF, or WEBP images.
        /// </summary>
        public FileParameter File { get; private set; } = new FileParameter("file");

        string IRestApiParameter.GetApiPath()
        {
            return $"/chatkit/files";
        }
        public override object GetRequestBody()
        {
            return new {
            	file = this.File,
            };
        }
        IEnumerable<FileParameter> IFileParameter.GetFileParameters()
        {
            yield return this.File;
        }
        Dictionary<string, string> IFormDataParameter.CreateFormDataParameter()
        {
            var d = new Dictionary<string, string>();
            return d;
        }
    }
    public partial class ChatKitFileUploadResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatKitFileUploadResponse> ChatKitFileUploadAsync(string fileFileName, Stream fileStream)
        {
            var p = new ChatKitFileUploadParameter();
            p.File.SetFile(fileFileName, fileStream);
            return await this.SendFormDataAsync<ChatKitFileUploadParameter, ChatKitFileUploadResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitFileUploadResponse> ChatKitFileUploadAsync(string fileFileName, Stream fileStream, CancellationToken cancellationToken)
        {
            var p = new ChatKitFileUploadParameter();
            p.File.SetFile(fileFileName, fileStream);
            return await this.SendFormDataAsync<ChatKitFileUploadParameter, ChatKitFileUploadResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatKitFileUploadResponse> ChatKitFileUploadAsync(ChatKitFileUploadParameter parameter)
        {
            return await this.SendFormDataAsync<ChatKitFileUploadParameter, ChatKitFileUploadResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitFileUploadResponse> ChatKitFileUploadAsync(ChatKitFileUploadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendFormDataAsync<ChatKitFileUploadParameter, ChatKitFileUploadResponse>(parameter, cancellationToken);
        }
    }
}
