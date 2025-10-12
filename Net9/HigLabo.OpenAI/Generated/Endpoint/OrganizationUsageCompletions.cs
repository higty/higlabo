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
    /// Get completions usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/completions">https://api.openai.com/v1/organization/usage/completions</seealso>
    /// </summary>
    public partial class OrganizationUsageCompletionsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageCompletionsParameter Empty = new OrganizationUsageCompletionsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public OrganizationUsageCompletionsQueryParameter QueryParameter { get; set; } = new OrganizationUsageCompletionsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/usage/completions";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationUsageCompletionsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Start time (Unix seconds) of the query time range, inclusive.
        /// </summary>
        public int Start_Time { get; set; }
        /// <summary>
        /// Return only usage for these API keys.
        /// </summary>
        public List<string>? Api_Key_Ids { get; set; }
        /// <summary>
        /// If true, return batch jobs only. If false, return non-batch jobs only. By default, return both.
        /// </summary>
        public bool? Batch { get; set; }
        /// <summary>
        /// Width of each time bucket in response. Currently 1m, 1h and 1d are supported, default to 1d.
        /// </summary>
        public string? Bucket_Width { get; set; }
        /// <summary>
        /// End time (Unix seconds) of the query time range, exclusive.
        /// </summary>
        public int? End_Time { get; set; }
        /// <summary>
        /// Group the usage data by the specified fields. Support fields include project_id, user_id, api_key_id, model, batch or any combination of them.
        /// </summary>
        public List<string>? Group_By { get; set; }
        /// <summary>
        /// Specifies the number of buckets to return.
        /// bucket_width=1d: default: 7, max: 31
        /// bucket_width=1h: default: 24, max: 168
        /// bucket_width=1m: default: 60, max: 1440
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Return only usage for these models.
        /// </summary>
        public List<string>? Models { get; set; }
        /// <summary>
        /// A cursor for use in pagination. Corresponding to the next_page field from the previous response.
        /// </summary>
        public string? Page { get; set; }
        /// <summary>
        /// Return only usage for these projects.
        /// </summary>
        public List<string>? Project_Ids { get; set; }
        /// <summary>
        /// Return only usage for these users.
        /// </summary>
        public List<string>? User_Ids { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.Start_Time != null)
            {
                sb.Append($"start_time={this.Start_Time}&");
            }
            if (this.Api_Key_Ids != null)
            {
                foreach (var item in this.Api_Key_Ids)
                {
                    sb.Append($"api_key_ids[]={item}&");
                }
            }
            if (this.Batch != null)
            {
                sb.Append($"batch={this.Batch}&");
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
            if (this.Models != null)
            {
                foreach (var item in this.Models)
                {
                    sb.Append($"models[]={item}&");
                }
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
            if (this.User_Ids != null)
            {
                foreach (var item in this.User_Ids)
                {
                    sb.Append($"user_ids[]={item}&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationUsageCompletionsResponse : RestApiDataResponse<List<OrganizationUsageCompletionObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageCompletionsResponse> OrganizationUsageCompletionsAsync(int start_Time)
        {
            return await this.SendJsonAsync<OrganizationUsageCompletionsParameter, OrganizationUsageCompletionsResponse>(OrganizationUsageCompletionsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageCompletionsResponse> OrganizationUsageCompletionsAsync(int start_Time, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageCompletionsParameter, OrganizationUsageCompletionsResponse>(OrganizationUsageCompletionsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageCompletionsResponse> OrganizationUsageCompletionsAsync(OrganizationUsageCompletionsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageCompletionsParameter, OrganizationUsageCompletionsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageCompletionsResponse> OrganizationUsageCompletionsAsync(OrganizationUsageCompletionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageCompletionsParameter, OrganizationUsageCompletionsResponse>(parameter, cancellationToken);
        }
    }
}
