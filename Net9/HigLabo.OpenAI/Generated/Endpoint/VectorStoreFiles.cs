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
    /// Returns a list of vector store files.
    /// <seealso href="https://api.openai.com/v1/vector_stores/{vector_store_id}/files">https://api.openai.com/v1/vector_stores/{vector_store_id}/files</seealso>
    /// </summary>
    public partial class VectorStoreFilesParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the vector store that the files belong to.
        /// </summary>
        public string Vector_Store_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public VectorStoreFilesQueryParameter QueryParameter { get; set; } = new VectorStoreFilesQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/vector_stores/{Vector_Store_Id}/files";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class VectorStoreFilesQueryParameter : IQueryParameter
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
        /// Filter by file status. One of in_progress, completed, failed, cancelled.
        /// </summary>
        public string? Filter { get; set; }
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
            if (this.Filter != null)
            {
                sb.Append($"filter={WebUtility.UrlEncode(this.Filter)}&");
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
    public partial class VectorStoreFilesResponse : RestApiDataResponse<List<VectorStoreFileObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VectorStoreFilesResponse> VectorStoreFilesAsync(string vector_Store_Id)
        {
            var p = new VectorStoreFilesParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFilesParameter, VectorStoreFilesResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFilesResponse> VectorStoreFilesAsync(string vector_Store_Id, CancellationToken cancellationToken)
        {
            var p = new VectorStoreFilesParameter();
            p.Vector_Store_Id = vector_Store_Id;
            return await this.SendJsonAsync<VectorStoreFilesParameter, VectorStoreFilesResponse>(p, cancellationToken);
        }
        public async ValueTask<VectorStoreFilesResponse> VectorStoreFilesAsync(VectorStoreFilesParameter parameter)
        {
            return await this.SendJsonAsync<VectorStoreFilesParameter, VectorStoreFilesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VectorStoreFilesResponse> VectorStoreFilesAsync(VectorStoreFilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VectorStoreFilesParameter, VectorStoreFilesResponse>(parameter, cancellationToken);
        }
    }
}
