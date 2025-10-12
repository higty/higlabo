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
    /// Get images usage details for the organization.
    /// <seealso href="https://api.openai.com/v1/organization/usage/images">https://api.openai.com/v1/organization/usage/images</seealso>
    /// </summary>
    public partial class OrganizationUsageImagesParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationUsageImagesParameter Empty = new OrganizationUsageImagesParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public OrganizationUsageImagesQueryParameter QueryParameter { get; set; } = new OrganizationUsageImagesQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/usage/images";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationUsageImagesQueryParameter : IQueryParameter
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
        /// Width of each time bucket in response. Currently 1m, 1h and 1d are supported, default to 1d.
        /// </summary>
        public string? Bucket_Width { get; set; }
        /// <summary>
        /// End time (Unix seconds) of the query time range, exclusive.
        /// </summary>
        public int? End_Time { get; set; }
        /// <summary>
        /// Group the usage data by the specified fields. Support fields include project_id, user_id, api_key_id, model, size, source or any combination of them.
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
        /// Return only usages for these image sizes. Possible values are 256x256, 512x512, 1024x1024, 1792x1792, 1024x1792 or any combination of them.
        /// </summary>
        public List<string>? Sizes { get; set; }
        /// <summary>
        /// Return only usages for these sources. Possible values are image.generation, image.edit, image.variation or any combination of them.
        /// </summary>
        public List<string>? Sources { get; set; }
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
            if (this.Sizes != null)
            {
                foreach (var item in this.Sizes)
                {
                    sb.Append($"sizes[]={item}&");
                }
            }
            if (this.Sources != null)
            {
                foreach (var item in this.Sources)
                {
                    sb.Append($"sources[]={item}&");
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
    public partial class OrganizationUsageImagesResponse : RestApiDataResponse<List<OrganizationUsageImageObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationUsageImagesResponse> OrganizationUsageImagesAsync(int start_Time)
        {
            return await this.SendJsonAsync<OrganizationUsageImagesParameter, OrganizationUsageImagesResponse>(OrganizationUsageImagesParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageImagesResponse> OrganizationUsageImagesAsync(int start_Time, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageImagesParameter, OrganizationUsageImagesResponse>(OrganizationUsageImagesParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationUsageImagesResponse> OrganizationUsageImagesAsync(OrganizationUsageImagesParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationUsageImagesParameter, OrganizationUsageImagesResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationUsageImagesResponse> OrganizationUsageImagesAsync(OrganizationUsageImagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationUsageImagesParameter, OrganizationUsageImagesResponse>(parameter, cancellationToken);
        }
    }
}
