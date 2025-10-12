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
    /// Pause a fine-tune job.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/pause">https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/pause</seealso>
    /// </summary>
    public partial class FineTuningJobPauseParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the fine-tuning job to pause.
        /// </summary>
        public string Fine_Tuning_Job_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs/{Fine_Tuning_Job_Id}/pause";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FineTuningJobPauseResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningJobPauseResponse> FineTuningJobPauseAsync(string fine_Tuning_Job_Id)
        {
            var p = new FineTuningJobPauseParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobPauseParameter, FineTuningJobPauseResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningJobPauseResponse> FineTuningJobPauseAsync(string fine_Tuning_Job_Id, CancellationToken cancellationToken)
        {
            var p = new FineTuningJobPauseParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobPauseParameter, FineTuningJobPauseResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningJobPauseResponse> FineTuningJobPauseAsync(FineTuningJobPauseParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningJobPauseParameter, FineTuningJobPauseResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningJobPauseResponse> FineTuningJobPauseAsync(FineTuningJobPauseParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobPauseParameter, FineTuningJobPauseResponse>(parameter, cancellationToken);
        }
    }
}
