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
    /// Get costs details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/costs">https://api.openai.com/v1/organization/costs</seealso>
    /// </summary>
    public partial class OrganizationCostsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationCostsParameter Empty = new OrganizationCostsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public OrganizationCostsQueryParameter QueryParameter { get; set; } = new OrganizationCostsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/costs";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationCostsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Start time (Unix seconds) of the query time range, inclusive.
        /// </summary>
        public int Start_Time { get; set; }
        /// <summary>
        /// Width of each time bucket in response. Currently only 1d is supported, default to 1d.
        /// </summary>
        public string? Bucket_Width { get; set; }
        /// <summary>
        /// End time (Unix seconds) of the query time range, exclusive.
        /// </summary>
        public int? End_Time { get; set; }
        /// <summary>
        /// Group the costs by the specified fields. Support fields include project_id, line_item and any combination of them.
        /// </summary>
        public List<string>? Group_By { get; set; }
        /// <summary>
        /// A limit on the number of buckets to be returned. Limit can range between 1 and 180, and the default is 7.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// A cursor for use in pagination. Corresponding to the next_page field from the previous response.
        /// </summary>
        public string? Page { get; set; }
        /// <summary>
        /// Return only costs for these projects.
        /// </summary>
        public List<string>? Project_Ids { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.Start_Time != null)
            {
                sb.Append($"start_time={this.Start_Time}&");
            }
            if (this.Bucket_Width != null)
            {
                sb.Append($"bucket_width={WebUtility.UrlEncode(this.Bucket_Width)}&");
            }
            if (this.End_Time != null)
            {
                sb.Append($"end_time={this.End_Time}&");
            }
            if (this.Group_By != null)
            {
                foreach (var item in this.Group_By)
                {
                    sb.Append($"group_by[]={item}&");
                }
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Page != null)
            {
                sb.Append($"page={WebUtility.UrlEncode(this.Page)}&");
            }
            if (this.Project_Ids != null)
            {
                foreach (var item in this.Project_Ids)
                {
                    sb.Append($"project_ids[]={item}&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationCostsResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationCostsResponse> OrganizationCostsAsync(int start_Time)
        {
            return await this.SendJsonAsync<OrganizationCostsParameter, OrganizationCostsResponse>(OrganizationCostsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCostsResponse> OrganizationCostsAsync(int start_Time, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCostsParameter, OrganizationCostsResponse>(OrganizationCostsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationCostsResponse> OrganizationCostsAsync(OrganizationCostsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationCostsParameter, OrganizationCostsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationCostsResponse> OrganizationCostsAsync(OrganizationCostsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationCostsParameter, OrganizationCostsResponse>(parameter, cancellationToken);
        }
    }
}
