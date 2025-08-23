using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Upload a file that can be used across various endpoints. Individual files can be up to 512 MB, and the size of all files uploaded by one organization can be up to 1 TB.
    /// The Assistants API supports files up to 2 million tokens and of specific file types. See the Assistants Tools guide for details.
    /// The Fine-tuning API only supports .jsonl files. The input also has certain required formats for fine-tuning chat or completions models.
    /// The Batch API only supports .jsonl files up to 200 MB in size. The input also has a specific required format.
    /// Please contact us if you need to increase these storage limits.
    /// <seealso href="https://api.openai.com/v1/files">https://api.openai.com/v1/files</seealso>
    /// </summary>
    public partial class FileUploadParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The File object (not file name) to be uploaded.
        /// </summary>
        public FileParameter File { get; private set; } = new FileParameter("file");
        /// <summary>
        /// The intended purpose of the uploaded file. One of: - assistants: Used in the Assistants API - batch: Used in the Batch API - fine-tune: Used for fine-tuning - vision: Images used for vision fine-tuning - user_data: Flexible file type for any purpose - evals: Used for eval data sets
        /// </summary>
        public string Purpose { get; set; } = "";
        /// <summary>
        /// The expiration policy for a file. By default, files with purpose=batch expire after 30 days and all other files are persisted until they are manually deleted.
        /// </summary>
        public ExpirationPolicy? Expires_After { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/files";
        }
        public override object GetRequestBody()
        {
            return new {
            	file = this.File,
            	purpose = this.Purpose,
            	expires_after = this.Expires_After,
            };
        }
        IEnumerable<FileParameter> IFileParameter.GetFileParameters()
        {
            yield return this.File;
        }
        Dictionary<string, string> IFormDataParameter.CreateFormDataParameter()
        {
            var d = new Dictionary<string, string>();
            d["purpose"] = this.Purpose;
            if (this.Expires_After != null) d["expires_after[anchor]"] = this.Expires_After.Anchor;
            if (this.Expires_After != null && this.Expires_After.Seconds != null) d["expires_after[seconds]"] = this.Expires_After.Seconds.Value.ToString();
            if (this.Expires_After != null && this.Expires_After.Minutes != null) d["expires_after[seconds]"] = this.Expires_After.Minutes.Value.ToString();
            if (this.Expires_After != null && this.Expires_After.Days != null) d["expires_after[seconds]"] = this.Expires_After.Days.Value.ToString();
            return d;
        }
    }
    public partial class FileUploadResponse : FileObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FileUploadResponse> FileUploadAsync(string fileFileName, Stream fileStream, string purpose)
        {
            var p = new FileUploadParameter();
            p.File.SetFile(fileFileName, fileStream);
            p.Purpose = purpose;
            return await this.SendFormDataAsync<FileUploadParameter, FileUploadResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FileUploadResponse> FileUploadAsync(string fileFileName, Stream fileStream, string purpose, CancellationToken cancellationToken)
        {
            var p = new FileUploadParameter();
            p.File.SetFile(fileFileName, fileStream);
            p.Purpose = purpose;
            return await this.SendFormDataAsync<FileUploadParameter, FileUploadResponse>(p, cancellationToken);
        }
        public async ValueTask<FileUploadResponse> FileUploadAsync(FileUploadParameter parameter)
        {
            return await this.SendFormDataAsync<FileUploadParameter, FileUploadResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FileUploadResponse> FileUploadAsync(FileUploadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendFormDataAsync<FileUploadParameter, FileUploadResponse>(parameter, cancellationToken);
        }
    }
}
