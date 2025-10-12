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
        public ResponseInputItemRetrieveQueryParameter QueryParameter { get; set; } = new ResponseInputItemRetrieveQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/responses/{Response_Id}/input_items";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ResponseInputItemRetrieveQueryParameter : IQueryParameter
    {
        /// <summary>
        /// An item ID to list items after, used in pagination.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Additional fields to include in the response. See the include parameter for Response creation above for more information.
        /// </summary>
        public List<string>? Include { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// The order to return the input items in. Default is desc.
        /// asc: Return the input items in ascending order.
        /// desc: Return the input items in descending order.
        /// </summary>
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Include != null)
            {
                foreach (var item in this.Include)
                {
                    sb.Append($"include[]={item}&");
                }
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class ResponseInputItemRetrieveResponse : RestApiDataResponse<List<ResponseInputItem>>
    {
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
