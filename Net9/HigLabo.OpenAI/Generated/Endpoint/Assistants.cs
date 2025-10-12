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
    /// Returns a list of assistants.
    /// <seealso href="https://api.openai.com/v1/assistants">https://api.openai.com/v1/assistants</seealso>
    /// </summary>
    public partial class AssistantsParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter, IQueryParameterProperty
    {
        internal static readonly AssistantsParameter Empty = new AssistantsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public AssistantsQueryParameter QueryParameter { get; set; } = new AssistantsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class AssistantsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list.
        /// </summary>
        public string? Before { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order.
        /// </summary>
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Before != null)
            {
                sb.Append($"before={WebUtility.UrlEncode(this.Before)}&");
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
    public partial class AssistantsResponse : RestApiDataResponse<List<AssistantObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantsResponse> AssistantsAsync()
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(AssistantsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<AssistantsResponse> AssistantsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(AssistantsParameter.Empty, cancellationToken);
        }
        public async ValueTask<AssistantsResponse> AssistantsAsync(AssistantsParameter parameter)
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<AssistantsResponse> AssistantsAsync(AssistantsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(parameter, cancellationToken);
        }
    }
}
