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
    /// Returns a list of files.
    /// <seealso href="https://api.openai.com/v1/files">https://api.openai.com/v1/files</seealso>
    /// </summary>
    public partial class FilesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly FilesParameter Empty = new FilesParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public FilesQueryParameter QueryParameter { get; set; } = new FilesQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/files";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class FilesQueryParameter : IQueryParameter
    {
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 10,000, and the default is 10,000.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order.
        /// </summary>
        public string? Order { get; set; }
        /// <summary>
        /// Only return files with the given purpose.
        /// </summary>
        public string? Purpose { get; set; }

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
            if (this.Purpose != null)
            {
                sb.Append($"purpose={WebUtility.UrlEncode(this.Purpose)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class FilesResponse : RestApiDataResponse<List<FileObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FilesResponse> FilesAsync()
        {
            return await this.SendJsonAsync<FilesParameter, FilesResponse>(FilesParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FilesResponse> FilesAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FilesParameter, FilesResponse>(FilesParameter.Empty, cancellationToken);
        }
        public async ValueTask<FilesResponse> FilesAsync(FilesParameter parameter)
        {
            return await this.SendJsonAsync<FilesParameter, FilesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FilesResponse> FilesAsync(FilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FilesParameter, FilesResponse>(parameter, cancellationToken);
        }
    }
}
