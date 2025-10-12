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
        public ResponseRetrieveQueryParameter QueryParameter { get; set; } = new ResponseRetrieveQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/responses/{Response_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class ResponseRetrieveQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Additional fields to include in the response. See the include parameter for Response creation above for more information.
        /// </summary>
        public List<string>? Include { get; set; }
        /// <summary>
        /// When true, stream obfuscation will be enabled. Stream obfuscation adds random characters to an obfuscation field on streaming delta events to normalize payload sizes as a mitigation to certain side-channel attacks. These obfuscation fields are included by default, but add a small amount of overhead to the data stream. You can set include_obfuscation to false to optimize for bandwidth if you trust the network links between your application and the OpenAI API.
        /// </summary>
        public bool? Include_Obfuscation { get; set; }
        /// <summary>
        /// The sequence number of the event after which to start streaming.
        /// </summary>
        public int? Starting_After { get; set; }
        /// <summary>
        /// If set to true, the model response data will be streamed to the client as it is generated using server-sent events. See the Streaming section below for more information.
        /// </summary>
        public bool? Stream { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.Include != null)
            {
                foreach (var item in this.Include)
                {
                    sb.Append($"include[]={item}&");
                }
            }
            if (this.Include_Obfuscation != null)
            {
                sb.Append($"include_obfuscation={this.Include_Obfuscation}&");
            }
            if (this.Starting_After != null)
            {
                sb.Append($"starting_after={this.Starting_After}&");
            }
            if (this.Stream != null)
            {
                sb.Append($"stream={this.Stream}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class ResponseRetrieveResponse : ResponseObjectResponse
    {
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
