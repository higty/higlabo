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
    /// List your organization's fine-tuning jobs
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs">https://api.openai.com/v1/fine_tuning/jobs</seealso>
    /// </summary>
    public partial class FineTuningJobsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly FineTuningJobsParameter Empty = new FineTuningJobsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public FineTuningJobsQueryParameter QueryParameter { get; set; } = new FineTuningJobsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class FineTuningJobsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Identifier for the last job from the previous pagination request.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Number of fine-tuning jobs to retrieve.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Optional metadata filter. To filter, use the syntax metadata[k]=v. Alternatively, set metadata=null to indicate no metadata.
        /// </summary>
        public object? Metadata { get; set; }

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
            if (this.Metadata != null)
            {
                sb.Append($"metadata={this.Metadata}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class FineTuningJobsResponse : RestApiDataResponse<List<FineTuningJob>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync()
        {
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(FineTuningJobsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(FineTuningJobsParameter.Empty, cancellationToken);
        }
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync(FineTuningJobsParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync(FineTuningJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(parameter, cancellationToken);
        }
    }
}
