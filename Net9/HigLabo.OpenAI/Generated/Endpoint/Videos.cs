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
    /// List videos
    /// <seealso href="https://api.openai.com/v1/videos">https://api.openai.com/v1/videos</seealso>
    /// </summary>
    public partial class VideosParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly VideosParameter Empty = new VideosParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public VideosQueryParameter QueryParameter { get; set; } = new VideosQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/videos";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class VideosQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Identifier for the last item from the previous pagination request
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Number of items to retrieve
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order of results by timestamp. Use asc for ascending order or desc for descending order.
        /// </summary>
        public string? Order { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
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
    public partial class VideosResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VideosResponse> VideosAsync()
        {
            return await this.SendJsonAsync<VideosParameter, VideosResponse>(VideosParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideosResponse> VideosAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VideosParameter, VideosResponse>(VideosParameter.Empty, cancellationToken);
        }
        public async ValueTask<VideosResponse> VideosAsync(VideosParameter parameter)
        {
            return await this.SendJsonAsync<VideosParameter, VideosResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideosResponse> VideosAsync(VideosParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VideosParameter, VideosResponse>(parameter, cancellationToken);
        }
    }
}
