using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Completes the Upload.
    /// Within the returned Upload object, there is a nested File object that is ready to use in the rest of the platform.
    /// You can specify the order of the Parts by passing in an ordered list of the Part IDs.
    /// The number of bytes uploaded upon completion must match the number of bytes initially specified when creating the Upload object. No Parts may be added after an Upload is completed.
    /// <seealso href="https://api.openai.com/v1/uploads/{upload_id}/complete">https://api.openai.com/v1/uploads/{upload_id}/complete</seealso>
    /// </summary>
    public partial class UploadCompleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the Upload.
        /// </summary>
        public string Upload_Id { get; set; } = "";
        /// <summary>
        /// The ordered list of Part IDs.
        /// </summary>
        public List<string>? Part_Ids { get; set; }
        /// <summary>
        /// The optional md5 checksum for the file contents to verify if the bytes uploaded matches what you expect.
        /// </summary>
        public string? Md5 { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/uploads/{Upload_Id}/complete";
        }
        public override object GetRequestBody()
        {
            return new {
            	part_ids = this.Part_Ids,
            	md5 = this.Md5,
            };
        }
    }
    public partial class UploadCompleteResponse : UploadObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<UploadCompleteResponse> UploadCompleteAsync(string upload_Id, List<string>? part_Ids)
        {
            var p = new UploadCompleteParameter();
            p.Upload_Id = upload_Id;
            p.Part_Ids = part_Ids;
            return await this.SendJsonAsync<UploadCompleteParameter, UploadCompleteResponse>(p, CancellationToken.None);
        }
        public async ValueTask<UploadCompleteResponse> UploadCompleteAsync(string upload_Id, List<string>? part_Ids, CancellationToken cancellationToken)
        {
            var p = new UploadCompleteParameter();
            p.Upload_Id = upload_Id;
            p.Part_Ids = part_Ids;
            return await this.SendJsonAsync<UploadCompleteParameter, UploadCompleteResponse>(p, cancellationToken);
        }
        public async ValueTask<UploadCompleteResponse> UploadCompleteAsync(UploadCompleteParameter parameter)
        {
            return await this.SendJsonAsync<UploadCompleteParameter, UploadCompleteResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<UploadCompleteResponse> UploadCompleteAsync(UploadCompleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<UploadCompleteParameter, UploadCompleteResponse>(parameter, cancellationToken);
        }
    }
}
