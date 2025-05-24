using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of input items for a given response.
    /// <seealso href="https://api.openai.com/v1/responses/{response_id}/input_items">https://api.openai.com/v1/responses/{response_id}/input_items</seealso>
    /// </summary>
    public partial class ResponseInputItemRetrieveParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the response to retrieve input items for.
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
            return $"/responses/{Response_Id}/input_items";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ResponseInputItemRetrieveResponse : RestApiDataResponse<List<ResponseInputItem>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ResponseInputItemRetrieveResponse> ResponseInputItemRetrieveAsync(string response_Id)
        {
            var p = new ResponseInputItemRetrieveParameter();
            p.Response_Id = response_Id;
            return await this.SendJsonAsync<ResponseInputItemRetrieveParameter, ResponseInputItemRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseInputItemRetrieveResponse> ResponseInputItemRetrieveAsync(string response_Id, CancellationToken cancellationToken)
        {
            var p = new ResponseInputItemRetrieveParameter();
            p.Response_Id = response_Id;
            return await this.SendJsonAsync<ResponseInputItemRetrieveParameter, ResponseInputItemRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ResponseInputItemRetrieveResponse> ResponseInputItemRetrieveAsync(ResponseInputItemRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ResponseInputItemRetrieveParameter, ResponseInputItemRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ResponseInputItemRetrieveResponse> ResponseInputItemRetrieveAsync(ResponseInputItemRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ResponseInputItemRetrieveParameter, ResponseInputItemRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
