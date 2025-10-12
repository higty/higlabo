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
    /// Cancels a model response with the given ID. Only responses created with the background parameter set to true can be cancelled. Learn more.
    /// <seealso href="https://api.openai.com/v1/responses/{response_id}/cancel">https://api.openai.com/v1/responses/{response_id}/cancel</seealso>
    /// </summary>
    public partial class ResponseCcancelParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the response to cancel.
        /// </summary>
        public string Response_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/responses/{Response_Id}/cancel";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ResponseCcancelResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ResponseCcancelResponse> ResponseCcancelAsync(string response_Id)
        {
            var p = new ResponseCcancelParameter();
            p.Response_Id = response_Id;
            return await this.SendJsonAsync<ResponseCcancelParameter, ResponseCcancelResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseCcancelResponse> ResponseCcancelAsync(string response_Id, CancellationToken cancellationToken)
        {
            var p = new ResponseCcancelParameter();
            p.Response_Id = response_Id;
            return await this.SendJsonAsync<ResponseCcancelParameter, ResponseCcancelResponse>(p, cancellationToken);
        }
        public async ValueTask<ResponseCcancelResponse> ResponseCcancelAsync(ResponseCcancelParameter parameter)
        {
            return await this.SendJsonAsync<ResponseCcancelParameter, ResponseCcancelResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseCcancelResponse> ResponseCcancelAsync(ResponseCcancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ResponseCcancelParameter, ResponseCcancelResponse>(parameter, cancellationToken);
        }
    }
}
