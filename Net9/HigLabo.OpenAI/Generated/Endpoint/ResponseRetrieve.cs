using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a model response with the given ID.
    /// <seealso href="https://api.openai.com/v1/responses/{response_id}">https://api.openai.com/v1/responses/{response_id}</seealso>
    /// </summary>
    public partial class ResponseRetrieveParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the response to retrieve.
        /// </summary>
        public string Response_Id { get; set; } = "";
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
            return $"/responses/{Response_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ResponseRetrieveResponse : ResponseObjectResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ResponseRetrieveResponse> ResponseRetrieveAsync(string response_Id)
        {
            var p = new ResponseRetrieveParameter();
            p.Response_Id = response_Id;
            return await this.SendJsonAsync<ResponseRetrieveParameter, ResponseRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseRetrieveResponse> ResponseRetrieveAsync(string response_Id, CancellationToken cancellationToken)
        {
            var p = new ResponseRetrieveParameter();
            p.Response_Id = response_Id;
            return await this.SendJsonAsync<ResponseRetrieveParameter, ResponseRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ResponseRetrieveResponse> ResponseRetrieveAsync(ResponseRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ResponseRetrieveParameter, ResponseRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseRetrieveResponse> ResponseRetrieveAsync(ResponseRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ResponseRetrieveParameter, ResponseRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
