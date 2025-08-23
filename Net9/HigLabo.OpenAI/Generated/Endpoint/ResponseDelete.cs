using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Deletes a model response with the given ID.
    /// <seealso href="https://api.openai.com/v1/responses/{response_id}">https://api.openai.com/v1/responses/{response_id}</seealso>
    /// </summary>
    public partial class ResponseDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the response to delete.
        /// </summary>
        public string Response_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/responses/{Response_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ResponseDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ResponseDeleteResponse> ResponseDeleteAsync(string response_Id)
        {
            var p = new ResponseDeleteParameter();
            p.Response_Id = response_Id;
            return await this.SendJsonAsync<ResponseDeleteParameter, ResponseDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseDeleteResponse> ResponseDeleteAsync(string response_Id, CancellationToken cancellationToken)
        {
            var p = new ResponseDeleteParameter();
            p.Response_Id = response_Id;
            return await this.SendJsonAsync<ResponseDeleteParameter, ResponseDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<ResponseDeleteResponse> ResponseDeleteAsync(ResponseDeleteParameter parameter)
        {
            return await this.SendJsonAsync<ResponseDeleteParameter, ResponseDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseDeleteResponse> ResponseDeleteAsync(ResponseDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ResponseDeleteParameter, ResponseDeleteResponse>(parameter, cancellationToken);
        }
    }
}
