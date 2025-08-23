using System.Collections.Generic;
using System.IO;
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
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs/{Fine_Tuning_Job_Id}/checkpoints";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FineTuningCheckpointsResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
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
