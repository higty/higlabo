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
    /// List checkpoints for a fine-tuning job.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/checkpoints">https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/checkpoints</seealso>
    /// </summary>
    public partial class FineTuningCheckpointsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the fine-tuning job to get checkpoints for.
        /// </summary>
        public string Fine_Tuning_Job_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public FineTuningCheckpointsQueryParameter QueryParameter { get; set; } = new FineTuningCheckpointsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs/{Fine_Tuning_Job_Id}/checkpoints";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class FineTuningCheckpointsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Identifier for the last checkpoint ID from the previous pagination request.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Number of checkpoints to retrieve.
        /// </summary>
        public int? Limit { get; set; }

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
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class FineTuningCheckpointsResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningCheckpointsResponse> FineTuningCheckpointsAsync(string fine_Tuning_Job_Id)
        {
            var p = new FineTuningCheckpointsParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningCheckpointsParameter, FineTuningCheckpointsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningCheckpointsResponse> FineTuningCheckpointsAsync(string fine_Tuning_Job_Id, CancellationToken cancellationToken)
        {
            var p = new FineTuningCheckpointsParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningCheckpointsParameter, FineTuningCheckpointsResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningCheckpointsResponse> FineTuningCheckpointsAsync(FineTuningCheckpointsParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningCheckpointsParameter, FineTuningCheckpointsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningCheckpointsResponse> FineTuningCheckpointsAsync(FineTuningCheckpointsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningCheckpointsParameter, FineTuningCheckpointsResponse>(parameter, cancellationToken);
        }
    }
}
