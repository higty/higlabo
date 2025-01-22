using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates an intermediate Upload object that you can add Parts to. Currently, an Upload can accept at most 8 GB in total and expires after an hour after you create it.
    /// Once you complete the Upload, we will create a File object that contains all the parts you uploaded. This File is usable in the rest of our platform as a regular File object.
    /// For certain purposes, the correct mime_type must be specified. Please refer to documentation for the supported MIME types for your use case:
    /// 
    /// Assistants
    /// 
    /// For guidance on the proper filename extensions for each purpose, please follow the documentation on creating a File.
    /// <seealso href="https://api.openai.com/v1/uploads">https://api.openai.com/v1/uploads</seealso>
    /// </summary>
    public partial class UploadCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The name of the file to upload.
        /// </summary>
        public string Filename { get; set; } = "";
        /// <summary>
        /// The intended purpose of the uploaded file.
        /// See the documentation on File purposes.
        /// </summary>
        public string Purpose { get; set; } = "";
        /// <summary>
        /// The number of bytes in the file you are uploading.
        /// </summary>
        public int Bytes { get; set; }
        /// <summary>
        /// The MIME type of the file.
        /// This must fall within the supported MIME types for your file purpose. See the supported MIME types for assistants and vision.
        /// </summary>
        public string Mime_Type { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/uploads";
        }
        public override object GetRequestBody()
        {
            return new {
            	filename = this.Filename,
            	purpose = this.Purpose,
            	bytes = this.Bytes,
            	mime_type = this.Mime_Type,
            };
        }
    }
    public partial class UploadCreateResponse : UploadObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<UploadCreateResponse> UploadCreateAsync(string filename, string purpose, int bytes, string mime_Type)
        {
            var p = new UploadCreateParameter();
            p.Filename = filename;
            p.Purpose = purpose;
            p.Bytes = bytes;
            p.Mime_Type = mime_Type;
            return await this.SendJsonAsync<UploadCreateParameter, UploadCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<UploadCreateResponse> UploadCreateAsync(string filename, string purpose, int bytes, string mime_Type, CancellationToken cancellationToken)
        {
            var p = new UploadCreateParameter();
            p.Filename = filename;
            p.Purpose = purpose;
            p.Bytes = bytes;
            p.Mime_Type = mime_Type;
            return await this.SendJsonAsync<UploadCreateParameter, UploadCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<UploadCreateResponse> UploadCreateAsync(UploadCreateParameter parameter)
        {
            return await this.SendJsonAsync<UploadCreateParameter, UploadCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<UploadCreateResponse> UploadCreateAsync(UploadCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<UploadCreateParameter, UploadCreateResponse>(parameter, cancellationToken);
        }
    }
}
