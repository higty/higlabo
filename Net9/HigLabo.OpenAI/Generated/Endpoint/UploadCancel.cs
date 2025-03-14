using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Cancels the Upload. No Parts may be added after an Upload is cancelled.
    /// <seealso href="https://api.openai.com/v1/uploads/{upload_id}/cancel">https://api.openai.com/v1/uploads/{upload_id}/cancel</seealso>
    /// </summary>
    public partial class UploadCancelParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the Upload.
        /// </summary>
        public string Upload_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/uploads/{Upload_Id}/cancel";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class UploadCancelResponse : UploadObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<UploadCancelResponse> UploadCancelAsync(string upload_Id)
        {
            var p = new UploadCancelParameter();
            p.Upload_Id = upload_Id;
            return await this.SendJsonAsync<UploadCancelParameter, UploadCancelResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<UploadCancelResponse> UploadCancelAsync(string upload_Id, CancellationToken cancellationToken)
        {
            var p = new UploadCancelParameter();
            p.Upload_Id = upload_Id;
            return await this.SendJsonAsync<UploadCancelParameter, UploadCancelResponse>(p, cancellationToken);
        }
        public async ValueTask<UploadCancelResponse> UploadCancelAsync(UploadCancelParameter parameter)
        {
            return await this.SendJsonAsync<UploadCancelParameter, UploadCancelResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<UploadCancelResponse> UploadCancelAsync(UploadCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<UploadCancelParameter, UploadCancelResponse>(parameter, cancellationToken);
        }
    }
}
