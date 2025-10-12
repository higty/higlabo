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
    /// Updates a project rate limit.
    /// <seealso href="https://api.openai.com/v1/organization/projects/{project_id}/rate_limits/{rate_limit_id}">https://api.openai.com/v1/organization/projects/{project_id}/rate_limits/{rate_limit_id}</seealso>
    /// </summary>
    public partial class OrganizationProjectRateLimitModifyParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Project_Id { get; set; } = "";
        /// <summary>
        /// The ID of the rate limit.
        /// </summary>
        public string Rate_Limit_Id { get; set; } = "";
        /// <summary>
        /// The maximum batch input tokens per day. Only relevant for certain models.
        /// </summary>
        public int? Batch_1_Day_Max_Input_Tokens { get; set; }
        /// <summary>
        /// The maximum audio megabytes per minute. Only relevant for certain models.
        /// </summary>
        public int? Max_Audio_Megabytes_Per_1_Minute { get; set; }
        /// <summary>
        /// The maximum images per minute. Only relevant for certain models.
        /// </summary>
        public int? Max_Images_Per_1_Minute { get; set; }
        /// <summary>
        /// The maximum requests per day. Only relevant for certain models.
        /// </summary>
        public int? Max_Requests_Per_1_Day { get; set; }
        /// <summary>
        /// The maximum requests per minute.
        /// </summary>
        public int? Max_Requests_Per_1_Minute { get; set; }
        /// <summary>
        /// The maximum tokens per minute.
        /// </summary>
        public int? Max_Tokens_Per_1_Minute { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/projects/{Project_Id}/rate_limits/{Rate_Limit_Id}";
        }
        public override object GetRequestBody()
        {
            return new {
            	batch_1_day_max_input_tokens = this.Batch_1_Day_Max_Input_Tokens,
            	max_audio_megabytes_per_1_minute = this.Max_Audio_Megabytes_Per_1_Minute,
            	max_images_per_1_minute = this.Max_Images_Per_1_Minute,
            	max_requests_per_1_day = this.Max_Requests_Per_1_Day,
            	max_requests_per_1_minute = this.Max_Requests_Per_1_Minute,
            	max_tokens_per_1_minute = this.Max_Tokens_Per_1_Minute,
            };
        }
    }
    public partial class OrganizationProjectRateLimitModifyResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationProjectRateLimitModifyResponse> OrganizationProjectRateLimitModifyAsync(string project_Id, string rate_Limit_Id)
        {
            var p = new OrganizationProjectRateLimitModifyParameter();
            p.Project_Id = project_Id;
            p.Rate_Limit_Id = rate_Limit_Id;
            return await this.SendJsonAsync<OrganizationProjectRateLimitModifyParameter, OrganizationProjectRateLimitModifyResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectRateLimitModifyResponse> OrganizationProjectRateLimitModifyAsync(string project_Id, string rate_Limit_Id, CancellationToken cancellationToken)
        {
            var p = new OrganizationProjectRateLimitModifyParameter();
            p.Project_Id = project_Id;
            p.Rate_Limit_Id = rate_Limit_Id;
            return await this.SendJsonAsync<OrganizationProjectRateLimitModifyParameter, OrganizationProjectRateLimitModifyResponse>(p, cancellationToken);
        }
        public async ValueTask<OrganizationProjectRateLimitModifyResponse> OrganizationProjectRateLimitModifyAsync(OrganizationProjectRateLimitModifyParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationProjectRateLimitModifyParameter, OrganizationProjectRateLimitModifyResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationProjectRateLimitModifyResponse> OrganizationProjectRateLimitModifyAsync(OrganizationProjectRateLimitModifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationProjectRateLimitModifyParameter, OrganizationProjectRateLimitModifyResponse>(parameter, cancellationToken);
        }
    }
}
